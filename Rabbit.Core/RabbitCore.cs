using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Web.Script.Serialization;

namespace Rabbit.Core
{
    public class RabbitCore
    {
        ConnectionFactory Factory;
        string ExchangeName;
        string Type;
        string[] QueueName;


        /// <param name="exchangeName">消息转发器名称</param>
        /// <param name="type">转发器类型：topic、headers、fanout、direct</param>
        /// <param name="queueName">创建的队列名称，可多个</param>
        public RabbitCore(string exchangeName, string type, params string[] queueName)
        {
            ExchangeName = exchangeName;
            Type = type;
            QueueName = queueName;
            Factory = new ConnectionFactory() { HostName = "localhost" };
        }

        /// <summary>
        /// 初始化创建消息转发器和队列
        /// </summary>
        /// <param name="exchangeName">消息转发器名称</param>
        /// <param name="type">转发器类型：topic、headers、fanout、direct</param>
        /// <param name="queueName">创建的队列名称，可多个</param>
        public void Init()
        {
            using (IConnection conn = Factory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    //全局 不要在同一时间给一个消费者超过一条消息
                    channel.BasicQos(0, 1, false);

                    //定义一个exchange
                    channel.ExchangeDeclare(ExchangeName, Type, durable: true, autoDelete: false, arguments: null);

                    //定义两个queue
                    foreach (string item in QueueName)
                    {
                        channel.QueueDeclare(item,
                            durable: true,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);
                    }

                    //定义 exchange 到 queue 的binding
                    foreach (string item in QueueName)
                    {
                        channel.QueueBind(item, ExchangeName, routingKey: item);
                    }
                }
            }
        }

        /// <summary>
        /// 发送消息到多个队列
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="exchangeName">消息转发器</param>
        /// <param name="queueName">队列名称，可多个</param>
        public void SendMessage(string msg)
        {
            using (IConnection conn = Factory.CreateConnection())
            using (IModel channel = conn.CreateModel())
            {
                var props = channel.CreateBasicProperties();
                props.Persistent = true;

                var msgBody = Encoding.UTF8.GetBytes(msg);

                //1. 发送消息到exchange ，但加上routingkey
                foreach (string item in QueueName)
                {
                    channel.BasicPublish(ExchangeName, routingKey: item, mandatory: false, basicProperties: props, body: msgBody);
                }

            }
        }

        /// <summary>
        /// 发送字符串消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="queueName"></param>
        public void SendMessageToQueue(string msg, string queueName)
        {
            using (IConnection conn = Factory.CreateConnection())
            using (IModel channel = conn.CreateModel())
            {
                var props = channel.CreateBasicProperties();
                props.Persistent = true;

                var msgBody = Encoding.UTF8.GetBytes(msg);

                //发送消息到exchange ，但加上routingkey
                channel.BasicPublish(ExchangeName, routingKey: queueName, mandatory: false, basicProperties: props, body: msgBody);
            }
        }

        /// <summary>
        /// 发送对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg">对象</param>
        /// <param name="queueName">指定队列名称</param>
        public void SendMessageToQueue<T>(T msg, string queueName) where T : class
        {
            using (IConnection conn = Factory.CreateConnection())
            using (IModel channel = conn.CreateModel())
            {
                var props = channel.CreateBasicProperties();
                props.Persistent = true;//消息持久化

                string jsonStr = new JavaScriptSerializer().Serialize(msg);
                var msgBody = Encoding.UTF8.GetBytes(jsonStr);

                //发送消息到exchange ，但加上routingkey
                channel.BasicPublish(ExchangeName, routingKey: queueName, mandatory: false, basicProperties: props, body: msgBody);
            }
        }



        /// <summary>
        /// 消费队列消息
        /// </summary>
        /// <param name="callBack">回调</param>
        public void ReceiveMessage(Expression<Action<string>> callBack)
        {
            using (IConnection connection = Factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                foreach (string item in QueueName)
                {
                    channel.QueueDeclare(item,
                            durable: true, //持久化
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);


                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        callBack.Compile().Invoke(message + ",Exchange:" + ea.Exchange + ",routingKey:" + ea.RoutingKey);
                    };



                    channel.BasicConsume(queue: item,
                                     autoAck: true,
                                     consumer: consumer);
                }

            }
        }

        /// <summary>
        /// 接受指定队列中的对象消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="callBack"></param>
        /// <param name="queueName">指定队列名称</param>
        public void ReceiveMessage<T>(Expression<Action<T>> callBack, string queueName) where T : class
        {
            using (IConnection connection = Factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {

                channel.QueueDeclare(queueName,
                        durable: true, //持久化
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);


                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var JsonStr = Encoding.UTF8.GetString(body);
                    T obj = new JavaScriptSerializer().Deserialize<T>(JsonStr);
                    callBack.Compile().Invoke(obj);
                };



                channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);


            }
        }
        
    }
}
