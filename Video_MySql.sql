/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2018/11/14 14:44:57                          */
/*==============================================================*/


drop table if exists ActiveAccountInfo;

drop table if exists ActiveVipInfo;

drop table if exists AdvertisingInfo;

drop table if exists ComboInfo;

drop table if exists NoticeInfo;

drop table if exists RechargeRecoder;

drop table if exists SendMailLog;

drop table if exists UserInfo;

drop table if exists UserVisitsInfo;

drop table if exists VideoCate;

drop table if exists VideoInfo;

/*==============================================================*/
/* User: dbo                                                    */
/*==============================================================*/
create user dbo;

/*==============================================================*/
/* Table: ActiveAccountInfo                                     */
/*==============================================================*/
create table ActiveAccountInfo
(
   Id                   int not null auto_increment,
   GUID                 varchar(32) not null,
   Account              varchar(50) not null,
   TimeSpan             varchar(100) not null,
   Token                varchar(32) not null,
   IsActive             bool not null,
   ActiveTime           datetime,
   CreateTime           datetime not null,
   primary key (Id)
);

/*==============================================================*/
/* Table: ActiveVipInfo                                         */
/*==============================================================*/
create table ActiveVipInfo
(
   Id                   int not null auto_increment,
   u_id                 int not null,
   u_name               varchar(30) not null,
   c_days               int not null,
   c_num                int not null,
   active_code          varchar(32) not null,
   IsPay                bool not null,
   pay_time             datetime not null,
   create_time          datetime not null,
   primary key (Id)
);

/*==============================================================*/
/* Table: AdvertisingInfo                                       */
/*==============================================================*/
create table AdvertisingInfo
(
   Id                   int not null auto_increment,
   a_id                 varchar(32),
   a_name               national varchar(30),
   a_type               int comment '图片、视频',
   a_src                varchar(150),
   a_second             int comment '秒',
   a_status             int comment '0 无效 1 有效',
   primary key (Id)
);

/*==============================================================*/
/* Table: ComboInfo                                             */
/*==============================================================*/
create table ComboInfo
(
   Id                   int not null auto_increment,
   c_id                 varchar(32),
   c_title              national varchar(20),
   c_intro              national varchar(30),
   c_num                int,
   c_days               int,
   c_status             int comment '0 无效 1 生效',
   primary key (Id)
);

/*==============================================================*/
/* Table: NoticeInfo                                            */
/*==============================================================*/
create table NoticeInfo
(
   Id                   int not null auto_increment,
   n_id                 varchar(32),
   n_title              national varchar(50),
   n_content            varchar(1),
   n_beginTime          datetime,
   n_endTime            datetime,
   n_status             int comment '0 无效 1 有效',
   n_createTime         datetime,
   primary key (Id)
);

/*==============================================================*/
/* Table: RechargeRecoder                                       */
/*==============================================================*/
create table RechargeRecoder
(
   Id                   int not null auto_increment,
   r_id                 varchar(32),
   r_u_id               varchar(32),
   r_c_id               varchar(32),
   r_c_title            national varchar(20),
   r_money              numeric(18,2),
   r_c_days             int,
   r_createTime         datetime,
   r_u_expriseTime      datetime,
   primary key (Id)
);

/*==============================================================*/
/* Table: SendMailLog                                           */
/*==============================================================*/
create table SendMailLog
(
   Id                   int not null auto_increment,
   Email                varchar(50) not null,
   Title                national varchar(100),
   SendTime             datetime not null,
   SendContent          national varchar(2000) not null,
   IsSuccess            bool not null,
   Remark               national varchar(200) not null,
   CreateTime           datetime not null,
   primary key (Id)
);

/*==============================================================*/
/* Table: UserInfo                                              */
/*==============================================================*/
create table UserInfo
(
   Id                   int not null auto_increment,
   u_gid                varchar(32) comment '唯一Id',
   u_name               varchar(30),
   u_pwd                varchar(32),
   u_level              int comment '0普通用户；1 周用户 ；2 月用户；3 年用户',
   u_expriseTime        datetime,
   u_regTime            datetime,
   u_status             int comment '0 无效；1 正常',
   primary key (Id)
);

/*==============================================================*/
/* Table: UserVisitsInfo                                        */
/*==============================================================*/
create table UserVisitsInfo
(
   Id                   int not null auto_increment,
   u_id                 varchar(32),
   v_id                 varchar(32),
   v_ip                 varchar(20),
   platform             varchar(30),
   v_url                varchar(150),
   v_time               datetime,
   primary key (Id)
);

/*==============================================================*/
/* Table: VideoCate                                             */
/*==============================================================*/
create table VideoCate
(
   c_id                 int not null auto_increment,
   c_name               national varchar(50),
   primary key (c_id)
);

/*==============================================================*/
/* Table: VideoInfo                                             */
/*==============================================================*/
create table VideoInfo
(
   Id                   int not null auto_increment,
   v_id                 varchar(32) comment '唯一Id',
   v_c_id               int,
   v_c_name             national varchar(50) comment '分类名称',
   v_titile             national varchar(100),
   v_intro              national varchar(200),
   v_coverImgSrc        varchar(150),
   v_playSrc            varchar(150),
   v_min_playSrc        varchar(150) default '',
   v_timeLength         varchar(10) comment 'HH:mm:ss',
   v_createTime         datetime,
   v_status             int,
   v_totalSecond        int default (0),
   primary key (Id)
);

