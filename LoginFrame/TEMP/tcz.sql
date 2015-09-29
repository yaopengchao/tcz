/*
Navicat MySQL Data Transfer

Source Server         : 听触诊软件
Source Server Version : 50624
Source Host           : localhost:3306
Source Database       : tcz

Target Server Type    : MYSQL
Target Server Version : 50624
File Encoding         : 65001

Date: 2015-09-23 15:27:32
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `ex_examination`
-- ----------------------------
DROP TABLE IF EXISTS `ex_examination`;
CREATE TABLE `ex_examination` (
  `EXAMINATION_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `EXAM_CAT` varchar(64) DEFAULT NULL COMMENT '考试种类',
  `EXAM_NAME` varchar(128) DEFAULT NULL COMMENT '考试名称',
  `START_TIME` varchar(20) DEFAULT NULL COMMENT '开始时间',
  `TOTAL_MINS` int(11) DEFAULT NULL COMMENT '考试时长',
  `SCORES` int(11) DEFAULT NULL COMMENT '总分',
  `EX_TYPE` varchar(20) DEFAULT NULL COMMENT '类型,1:考试,2:自我测试',
  PRIMARY KEY (`EXAMINATION_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='试卷';

-- ----------------------------
-- Records of ex_examination
-- ----------------------------

-- ----------------------------
-- Table structure for `ex_examination_detail`
-- ----------------------------
DROP TABLE IF EXISTS `ex_examination_detail`;
CREATE TABLE `ex_examination_detail` (
  `EXAMINATION_DETAIL_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `EXAMINATION_ID` int(11) DEFAULT NULL COMMENT '试卷表主键',
  `TOPIC_ID` int(11) DEFAULT NULL COMMENT '题目',
  `TOPIC_ORDER` int(11) DEFAULT NULL COMMENT '题目顺序',
  PRIMARY KEY (`EXAMINATION_DETAIL_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='试卷明细';

-- ----------------------------
-- Records of ex_examination_detail
-- ----------------------------

-- ----------------------------
-- Table structure for `ex_exam_result`
-- ----------------------------
DROP TABLE IF EXISTS `ex_exam_result`;
CREATE TABLE `ex_exam_result` (
  `EXAM_RESULT_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `USER_ID` int(11) DEFAULT NULL COMMENT '用户表主键',
  `EXAMINATION_ID` int(11) DEFAULT NULL COMMENT '试卷表主键',
  `EXAMINATION_DETAIL_ID` int(11) DEFAULT NULL COMMENT '试卷明细表主键',
  `TOPIC_ID` int(11) DEFAULT NULL COMMENT '题目表主键',
  `ANSWERS` varchar(64) DEFAULT NULL COMMENT '答题结果',
  PRIMARY KEY (`EXAM_RESULT_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='考试明细';

-- ----------------------------
-- Records of ex_exam_result
-- ----------------------------

-- ----------------------------
-- Table structure for `ex_topic`
-- ----------------------------
DROP TABLE IF EXISTS `ex_topic`;
CREATE TABLE `ex_topic` (
  `TOPIC_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `CONTENT` text COMMENT '题干',
  `TOPIC_TYPE` varchar(64) DEFAULT NULL COMMENT '种类,1:理论类,2:操作类',
  `TOPIC_CATEGORY` varchar(64) DEFAULT NULL COMMENT '分类,同flash课件分类',
  `ANSWERS` varchar(64) DEFAULT NULL COMMENT '答案',
  `CREATE_TIME` varchar(64) DEFAULT NULL COMMENT '创建时间',
  PRIMARY KEY (`TOPIC_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='题目';

-- ----------------------------
-- Records of ex_topic
-- ----------------------------

-- ----------------------------
-- Table structure for `ex_topic_detail`
-- ----------------------------
DROP TABLE IF EXISTS `ex_topic_detail`;
CREATE TABLE `ex_topic_detail` (
  `TOPIC_DETAIL_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `TOPIC_ID` int(11) DEFAULT NULL COMMENT '题目表主键',
  `ITEM_PRE` varchar(64) DEFAULT NULL COMMENT '选项符号',
  `ITEM_DETAIL` text COMMENT '选项内容',
  `AGREEMENT` varchar(255) DEFAULT NULL COMMENT '协议',
  `ITEM_ORDER` varchar(64) DEFAULT NULL COMMENT '选项顺序',
  PRIMARY KEY (`TOPIC_DETAIL_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='题目选项';

-- ----------------------------
-- Records of ex_topic_detail
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_class`
-- ----------------------------
DROP TABLE IF EXISTS `sys_class`;
CREATE TABLE `sys_class` (
  `CLASS_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '班级表主键，唯一标识',
  `CLASS_NAME` varchar(32) DEFAULT NULL COMMENT '班级名称',
  PRIMARY KEY (`CLASS_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_class
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_user`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `USER_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '用户唯一标识，主键',
  `LOGIN_ID` varchar(32) DEFAULT NULL COMMENT '登录名',
  `USER_NAME` varchar(32) DEFAULT NULL COMMENT '姓名',
  `USER_TYPE` char(1) DEFAULT NULL COMMENT '用户类型，1：管理员；2：教师；3：学生',
  `PWD` varchar(64) DEFAULT NULL COMMENT '密码',
  `CREATE_DATE` varchar(20) DEFAULT NULL COMMENT '创建日期',
  PRIMARY KEY (`USER_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='用户';

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('1', 'admin', '管理员', '1', 'admin', '2015-09-15 12:00:00');

-- ----------------------------
-- Table structure for `sys_user_class`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_class`;
CREATE TABLE `sys_user_class` (
  `USER_CLASS_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '用户班级关联表主键，唯一标识',
  `USER_ID` int(11) DEFAULT NULL COMMENT '用户表主键',
  `CLASS_ID` int(11) DEFAULT NULL COMMENT '班级表主键',
  PRIMARY KEY (`USER_CLASS_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user_class
-- ----------------------------

-- ----------------------------
-- Table structure for `sys_user_favorites`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_favorites`;
CREATE TABLE `sys_user_favorites` (
  `DATA_ID` int(11) NOT NULL AUTO_INCREMENT,
  `LOGIN_ID` varchar(255) NOT NULL COMMENT '用户登录ID',
  `LESSON_ID` int(11) NOT NULL COMMENT '课件ID',
  PRIMARY KEY (`DATA_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user_favorites
-- ----------------------------
INSERT INTO `sys_user_favorites` VALUES ('1', 'admin', '1');
INSERT INTO `sys_user_favorites` VALUES ('2', 'admin', '2');
INSERT INTO `sys_user_favorites` VALUES ('3', 'admin', '13');

-- ----------------------------
-- Table structure for `sys_user_type`
-- ----------------------------
DROP TABLE IF EXISTS `sys_user_type`;
CREATE TABLE `sys_user_type` (
  `USER_TYPE` int(255) NOT NULL,
  `USER_TYPE_NAME` varchar(255) NOT NULL,
  `USER_TYPE_DESC` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`USER_TYPE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sys_user_type
-- ----------------------------
INSERT INTO `sys_user_type` VALUES ('1', '管理员', '管理员角色');
INSERT INTO `sys_user_type` VALUES ('2', '教师', '教师角色');
INSERT INTO `sys_user_type` VALUES ('3', '学生', '学生角色');

-- ----------------------------
-- Table structure for `tcz_agreement`
-- ----------------------------
DROP TABLE IF EXISTS `tcz_agreement`;
CREATE TABLE `tcz_agreement` (
  `AGREEMENT_ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '协议ID',
  `AGREEMENT_NAME` varchar(255) DEFAULT NULL COMMENT '协议中文名称',
  `AGREEMENT_ENAME` varchar(255) DEFAULT NULL COMMENT '协议英文名称',
  `AGREEMENT_TYPE` varchar(255) DEFAULT NULL COMMENT '协议类型(1 系统级,2 应用级)',
  `AGREEMENT` varchar(255) DEFAULT NULL COMMENT '协议字符串',
  PRIMARY KEY (`AGREEMENT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tcz_agreement
-- ----------------------------
INSERT INTO `tcz_agreement` VALUES ('1', '开机验证码', 'KJYZM', '1', 'FF  0000  0000  0000  PASSWORD  FD');
INSERT INTO `tcz_agreement` VALUES ('2', '获取命令', 'HQML', '1', 'FF  0000  0000  0000  GetID  FD');
INSERT INTO `tcz_agreement` VALUES ('3', '触诊通信标识码返回', 'CZTXBSMFH', '1', 'FF  0000  0000  0000  CZ  FD');
INSERT INTO `tcz_agreement` VALUES ('4', '归零', 'GL', '1', 'FF  0000  0000  0000  00000000  FD');
INSERT INTO `tcz_agreement` VALUES ('5', '归零成功', 'GLCG', '1', 'FF  0000  0000  0000  11111111  FD');
INSERT INTO `tcz_agreement` VALUES ('6', '归零失败', 'GLSB', '1', 'FF  0000  0000  0000  00000000  FD');
INSERT INTO `tcz_agreement` VALUES ('7', '肝脏无肿大', 'GZWZD', '2', 'FF  0000  0000  0000  GanS0000  FD');
INSERT INTO `tcz_agreement` VALUES ('8', '肝脏有肿大1', 'GZYZD1', '2', 'FF  0000  0000  0000  GanS0001  FD');
INSERT INTO `tcz_agreement` VALUES ('9', '肝脏有肿大2', 'GZYZD2', '2', 'FF  0000  0000  0000  GanS0002  FD');
INSERT INTO `tcz_agreement` VALUES ('10', '肝脏有肿大3', 'GZYZD3', '2', 'FF  0000  0000  0000  GanS0003  FD');
INSERT INTO `tcz_agreement` VALUES ('11', '肝脏有肿大4', 'GZYZD4', '2', 'FF  0000  0000  0000  GanS0004  FD');
INSERT INTO `tcz_agreement` VALUES ('12', '肝脏有肿大5', 'GZYZD5', '2', 'FF  0000  0000  0000  GanS0005  FD');
INSERT INTO `tcz_agreement` VALUES ('13', '肝脏有肿大6', 'GZYZD6', '2', 'FF  0000  0000  0000  GanS0006  FD');
INSERT INTO `tcz_agreement` VALUES ('14', '肝脏有肿大7', 'GZYZD7', '2', 'FF  0000  0000  0000  GanS0007  FD');
INSERT INTO `tcz_agreement` VALUES ('15', '肝脏有肿大成功', 'GZYZDCG', '1', 'FF  0000  0000  0000  PiZD1000  FD');
INSERT INTO `tcz_agreement` VALUES ('16', '肝脏有肿大失败', 'GZYZDSB', '1', 'FF  0000  0000  0000  PiZD1111  FD');
INSERT INTO `tcz_agreement` VALUES ('17', '肝脏质地质软', 'GZZDZR', '2', 'FF  0000  0000  0000  GanZ0001  FD');
INSERT INTO `tcz_agreement` VALUES ('18', '肝脏质地质硬', 'GZZDZY', '2', 'FF  0000  0000  0000  GanZ0000  FD');
INSERT INTO `tcz_agreement` VALUES ('19', '肝脏质地成功', 'GZZDCG', '1', 'FF  0000  0000  0000  GanZ1000  FD');
INSERT INTO `tcz_agreement` VALUES ('20', '肝脏质地失败', 'GZZDSB', '1', 'FF  0000  0000  0000  GanZ1111  FD');
INSERT INTO `tcz_agreement` VALUES ('21', '脾脏无肿大', 'PZWZD', '2', 'FF  0000  0000  0000  PiZD0000  FD');
INSERT INTO `tcz_agreement` VALUES ('22', '脾脏有肿大1', 'PZYZD1', '2', 'FF  0000  0000  0000  PiZD0001  FD');
INSERT INTO `tcz_agreement` VALUES ('23', '脾脏有肿大2', 'PZYZD2', '2', 'FF  0000  0000  0000  PiZD0002  FD');
INSERT INTO `tcz_agreement` VALUES ('24', '脾脏有肿大3', 'PZYZD3', '2', 'FF  0000  0000  0000  PiZD0003  FD');
INSERT INTO `tcz_agreement` VALUES ('25', '脾脏有肿大4', 'PZYZD4', '2', 'FF  0000  0000  0000  PiZD0004  FD');
INSERT INTO `tcz_agreement` VALUES ('26', '脾脏有肿大5', 'PZYZD5', '2', 'FF  0000  0000  0000  PiZD0005  FD');
INSERT INTO `tcz_agreement` VALUES ('27', '脾脏有肿大6', 'PZYZD6', '2', 'FF  0000  0000  0000  PiZD0006  FD');
INSERT INTO `tcz_agreement` VALUES ('28', '脾脏有肿大7', 'PZYZD7', '2', 'FF  0000  0000  0000  PiZD0007  FD');
INSERT INTO `tcz_agreement` VALUES ('29', '脾脏有肿大成功', 'PZYZDCG', '1', 'FF  0000  0000  0000  PiZD1000  FD');
INSERT INTO `tcz_agreement` VALUES ('30', '脾脏有肿大失败', 'PZYZDSB', '1', 'FF  0000  0000  0000  PiZD1111  FD');
INSERT INTO `tcz_agreement` VALUES ('31', '胆囊无肿大', 'DNWZD', '2', 'FF  0000  0000  0000  DNZD0001  FD');
INSERT INTO `tcz_agreement` VALUES ('32', '胆囊有肿大', 'DNYZD', '2', 'FF  0000  0000  0000  DNZD0000  FD');
INSERT INTO `tcz_agreement` VALUES ('33', '胆囊有肿大成功', 'DNYZDCG', '1', 'FF  0000  0000  0000  DNZD1000  FD');
INSERT INTO `tcz_agreement` VALUES ('34', '胆囊有肿大失败', 'DNYZDSB', '1', 'FF  0000  0000  0000  DNZD1111  FD');
INSERT INTO `tcz_agreement` VALUES ('35', '胆囊有触痛', 'DNYCT', '2', 'FF  0000  0000  0000  DNCT0001  FD');
INSERT INTO `tcz_agreement` VALUES ('36', '胆囊无触痛', 'DNWCT', '2', 'FF  0000  0000  0000  DNCT0000 FD');
INSERT INTO `tcz_agreement` VALUES ('37', '胆囊触痛成功', 'DNCTCG', '1', 'FF  0000  0000  0000  DNCT1000  FD');
INSERT INTO `tcz_agreement` VALUES ('38', '胆囊触痛失败', 'DNCTSB', '1', 'FF  0000  0000  0000  DNCT1111  FD');
INSERT INTO `tcz_agreement` VALUES ('39', '胆囊墨菲氏征有', 'DNMFSZY', '2', 'FF  0000  0000  0000  MURP0001  FD');
INSERT INTO `tcz_agreement` VALUES ('40', '胆囊墨菲氏征无', 'DNMFSZW', '2', 'FF  0000  0000  0000  MURP0000  FD');
INSERT INTO `tcz_agreement` VALUES ('41', '胆囊墨菲氏征成功', 'DNMFSZCG', '1', 'FF  0000  0000  0000  MURP1000  FD');
INSERT INTO `tcz_agreement` VALUES ('42', '胆囊墨菲氏征失败', 'DNMFSZSB', '1', 'FF  0000  0000  0000  MURP1111  FD');
INSERT INTO `tcz_agreement` VALUES ('43', '胃部压痛有', 'WBYTY', '2', 'FF  0000  0000  0000  WBYT0001  FD');
INSERT INTO `tcz_agreement` VALUES ('44', '胃部压痛无', 'WBYTW', '2', 'FF  0000  0000  0000  WBYT0000  FD');
INSERT INTO `tcz_agreement` VALUES ('45', '胃部压痛成功', 'WBYTCG', '1', 'FF  0000  0000  0000  WBYT1000  FD');
INSERT INTO `tcz_agreement` VALUES ('46', '胃部压痛失败', 'WBYTSB', '1', 'FF  0000  0000  0000  WBYT1111  FD');
INSERT INTO `tcz_agreement` VALUES ('47', '十二指肠有', 'SEZCY', '2', 'FF  0000  0000  0000  SEZC0001  FD');
INSERT INTO `tcz_agreement` VALUES ('48', '十二指肠无', 'SEZCW', '2', 'FF  0000  0000  0000  SEZC0000  FD');
INSERT INTO `tcz_agreement` VALUES ('49', '十二指肠成功', 'SEZCCG', '1', 'FF  0000  0000  0000  SEZC1000  FD');
INSERT INTO `tcz_agreement` VALUES ('50', '十二指肠失败', 'SEZCSB', '1', 'FF  0000  0000  0000  SEZC1111  FD');
INSERT INTO `tcz_agreement` VALUES ('51', '胰腺有', 'YXY', '2', 'FF  0000  0000  0000  YXYT0001  FD');
INSERT INTO `tcz_agreement` VALUES ('52', '胰腺无', 'YXW', '2', 'FF  0000  0000  0000  YXYT0000  FD');
INSERT INTO `tcz_agreement` VALUES ('53', '胰腺成功', 'YXCG', '1', 'FF  0000  0000  0000  YXYT1000  FD');
INSERT INTO `tcz_agreement` VALUES ('54', '胰腺失败', 'YXSB', '1', 'FF  0000  0000  0000  YXYT1111  FD');
INSERT INTO `tcz_agreement` VALUES ('55', '阑尾有', 'LWY', '2', 'FF  0000  0000  0000  LWYT0001  FD');
INSERT INTO `tcz_agreement` VALUES ('56', '阑尾无', 'LWW', '2', 'FF  0000  0000  0000  LWYT0000  FD');
INSERT INTO `tcz_agreement` VALUES ('57', '阑尾成功', 'LWCG', '1', 'FF  0000  0000  0000  LWYT1000  FD');
INSERT INTO `tcz_agreement` VALUES ('58', '阑尾失败', 'LWSB', '1', 'FF  0000  0000  0000  LWYT1111  FD');
INSERT INTO `tcz_agreement` VALUES ('59', '小肠有', 'XCY', '2', 'FF  0000  0000  0000  XCYT0001  FD');
INSERT INTO `tcz_agreement` VALUES ('60', '小肠无', 'XCW', '2', 'FF  0000  0000  0000  XCYT0000  FD');
INSERT INTO `tcz_agreement` VALUES ('61', '小肠成功', 'XCCG', '1', 'FF  0000  0000  0000  XCYT1000  FD');
INSERT INTO `tcz_agreement` VALUES ('62', '小肠失败', 'XCSB', '1', 'FF  0000  0000  0000  XCYT1111  FD');
INSERT INTO `tcz_agreement` VALUES ('63', '乙状结肠有', 'YZJCY', '2', 'FF  0000  0000  0000  YZJC0001  FD');
INSERT INTO `tcz_agreement` VALUES ('64', '乙状结肠无', 'YZJCW', '2', 'FF  0000  0000  0000  YZJC0000  FD');
INSERT INTO `tcz_agreement` VALUES ('65', '乙状结肠成功', 'YZJCCG', '1', 'FF  0000  0000  0000  YZJC1000  FD');
INSERT INTO `tcz_agreement` VALUES ('66', '乙状结肠失败', 'YZJCSB', '1', 'FF  0000  0000  0000  YZJC1111  FD');
INSERT INTO `tcz_agreement` VALUES ('67', '胰腺反跳痛有', 'YXFTTY', '2', 'FF  0000  0000  0000  FTTY0001  FD');
INSERT INTO `tcz_agreement` VALUES ('68', '胰腺反跳痛无', 'YXFTTW', '2', 'FF  0000  0000  0000  FTTY0000  FD');
INSERT INTO `tcz_agreement` VALUES ('69', '胰腺反跳痛成功', 'YXFTTCG', '1', 'FF  0000  0000  0000  FTTY1000  FD');
INSERT INTO `tcz_agreement` VALUES ('70', '胰腺反跳痛失败', 'YXFTTSB', '1', 'FF  0000  0000  0000  FTTY1111  FD');
INSERT INTO `tcz_agreement` VALUES ('71', '阑尾反跳痛有', 'LWFTTY', '2', 'FF  0000  0000  0000  FTTL0001  FD');
INSERT INTO `tcz_agreement` VALUES ('72', '阑尾反跳痛无', 'LWFTTW', '2', 'FF  0000  0000  0000  FTTL0000  FD');
INSERT INTO `tcz_agreement` VALUES ('73', '阑尾反跳痛成功', 'LWFTTCG', '1', 'FF  0000  0000  0000  FTTL1000  FD');
INSERT INTO `tcz_agreement` VALUES ('74', '阑尾反跳痛失败', 'LWFTTSB', '1', 'FF  0000  0000  0000  FTTL1111  FD');
INSERT INTO `tcz_agreement` VALUES ('75', '小肠反跳痛有', 'XCFTTY', '2', 'FF  0000  0000  0000  FTTX0001  FD');
INSERT INTO `tcz_agreement` VALUES ('76', '小肠反跳痛无', 'XCFTTW', '2', 'FF  0000  0000  0000  FTTX0000  FD');
INSERT INTO `tcz_agreement` VALUES ('77', '小肠反跳痛成功', 'XCFTTCG', '1', 'FF  0000  0000  0000 FTTX1000  FD');
INSERT INTO `tcz_agreement` VALUES ('78', '小肠反跳痛失败', 'XCFTTSB', '1', 'FF  0000  0000  0000  FTTX1111  FD');
INSERT INTO `tcz_agreement` VALUES ('79', '脉搏设置', 'MBSZ', '2', 'FF  0000  0000  0000  MBTD0@  FD');
INSERT INTO `tcz_agreement` VALUES ('80', '脉搏设置成功', 'MBSZCG', '1', 'FF  0000  0000  0000  MBTD1000  FD');
INSERT INTO `tcz_agreement` VALUES ('81', '脉搏设置失败', 'MBSZSB', '1', 'FF  0000  0000  0000  MBTD1111  FD');
INSERT INTO `tcz_agreement` VALUES ('82', '血压设置收缩压', 'XYSZSSY', '2', 'FF  0000  0000  0000  SSXY0@  FD');
INSERT INTO `tcz_agreement` VALUES ('83', '血压设置收缩压成功', 'XYSZSSYCG', '1', 'FF  0000  0000  0000  SSXY1000  FD');
INSERT INTO `tcz_agreement` VALUES ('84', '血压设置收缩压失败', 'XYSZSSYSB', '1', 'FF  0000  0000  0000  SSXY1111  FD');
INSERT INTO `tcz_agreement` VALUES ('85', '血压设置舒张压', 'XYSZSZY', '2', 'FF  0000  0000  0000  SZXY0@  FD');
INSERT INTO `tcz_agreement` VALUES ('86', '血压设置舒张压成功', 'XYSZSZYCG', '1', 'FF  0000  0000  0000  SZXY1000  FD');
INSERT INTO `tcz_agreement` VALUES ('87', '血压设置舒张压失败', 'XYSZSZYSB', '1', 'FF  0000  0000  0000  SZXY1111  FD');
INSERT INTO `tcz_agreement` VALUES ('88', '血压校准开始校准信号', 'XYJZKSBZXH', '2', 'FF  0000  0000  0000  XYJZ0000  FD');
INSERT INTO `tcz_agreement` VALUES ('89', '听诊通信标识码返回', 'TZTXBSMFH', '1', 'FF  0000  0000  0000  TZ  FD');
INSERT INTO `tcz_agreement` VALUES ('90', '心前区震颤有', 'XQQZCY', '3', 'FF  0000  0000  0000  XQQZ0001  FD');
INSERT INTO `tcz_agreement` VALUES ('91', '心前区震颤无', 'XQQZCW', '3', 'FF  0000  0000  0000  XQQZ0000  FD');
INSERT INTO `tcz_agreement` VALUES ('92', '心前区震颤成功', 'XQQZCCG', '1', 'FF  0000  0000  0000  XQQZ1000  FD');
INSERT INTO `tcz_agreement` VALUES ('93', '心前区震颤失败', 'XQQZCSB', '1', 'FF  0000  0000  0000  XQQZ1111  FD');
INSERT INTO `tcz_agreement` VALUES ('94', '心尖搏动有', 'XJBDY', '3', 'FF  0000  0000  0000  XJBD0001  FD');
INSERT INTO `tcz_agreement` VALUES ('95', '心尖搏动无', 'XJBDW', '3', 'FF  0000  0000  0000  XJBD0000  FD');
INSERT INTO `tcz_agreement` VALUES ('96', '心尖搏动成功', 'XJBDCG', '1', 'FF  0000  0000  0000  XJBD1000  FD');
INSERT INTO `tcz_agreement` VALUES ('97', '心尖搏动失败', 'XJBDSB', '1', 'FF  0000  0000  0000  XJBD1111  FD');
INSERT INTO `tcz_agreement` VALUES ('98', '肺部开启听诊模式', 'FBKQTZMS', '1', 'FF  0000  0000  0000  TZON  FD');
INSERT INTO `tcz_agreement` VALUES ('99', '肺部关闭听诊模式', 'FBKGBZMS', '1', 'FF  0000  0000  0000  TZOFF  FD');
INSERT INTO `tcz_agreement` VALUES ('100', '肺部接受听诊标签位置', 'FBJSTCBQWZ', '1', 'FF  0000  0000  0000  TZLB@  FD');
INSERT INTO `tcz_agreement` VALUES ('101', '肺部发送声音序号', 'FBFSSYXH', '1', 'FF  0000  0000  0000  TZSN@ FD');
INSERT INTO `tcz_agreement` VALUES ('102', '腹部开启听诊模式', 'FUBKQTZMS', '1', 'FF  0000  0000  0000  CZON  FD');
INSERT INTO `tcz_agreement` VALUES ('103', '腹部关闭听诊模式', 'FUBKGBZMS', '1', 'FF  0000  0000  0000  CZOFF  FD');
INSERT INTO `tcz_agreement` VALUES ('104', '腹部接受听诊标签位置', 'FUBJSTZBQWZ', '1', 'FF  0000  0000  0000  CZLB@ FD');
INSERT INTO `tcz_agreement` VALUES ('105', '腹部发送声音序号', 'FUBFSSYXH', '1', 'FF  0000  0000  0000  CZSN@ FD');

-- ----------------------------
-- Table structure for `tcz_classes`
-- ----------------------------
DROP TABLE IF EXISTS `tcz_classes`;
CREATE TABLE `tcz_classes` (
  `CLASS_ID` varchar(255) NOT NULL COMMENT '课程ID',
  `CLASS_NAME` varchar(255) NOT NULL COMMENT '课程中文名称',
  `CLASS_ENAME` varchar(255) NOT NULL COMMENT '课程英文名称',
  `CLASS_TYPE_ID` varchar(255) NOT NULL COMMENT '课程类型ID',
  PRIMARY KEY (`CLASS_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tcz_classes
-- ----------------------------
INSERT INTO `tcz_classes` VALUES ('1', '基础知识', 'Basicknowledge', '1');
INSERT INTO `tcz_classes` VALUES ('10', '胸膜摩擦音', '3222', '2');
INSERT INTO `tcz_classes` VALUES ('11', '其他疾病呼吸音', 'e2', '2');
INSERT INTO `tcz_classes` VALUES ('12', '腹部触诊基础', '2222', '3');
INSERT INTO `tcz_classes` VALUES ('13', '腹壁紧张度', '222', '3');
INSERT INTO `tcz_classes` VALUES ('14', '腹部包块', '222', '3');
INSERT INTO `tcz_classes` VALUES ('15', '液波震颤', '2222', '3');
INSERT INTO `tcz_classes` VALUES ('16', '压痛与反跳痛', '222', '3');
INSERT INTO `tcz_classes` VALUES ('17', '胆囊触诊', '22222', '3');
INSERT INTO `tcz_classes` VALUES ('18', '肝脏触诊', '2222', '3');
INSERT INTO `tcz_classes` VALUES ('19', '脾脏触诊', '2222', '3');
INSERT INTO `tcz_classes` VALUES ('2', '正常心音', 'Normalheartsounds', '1');
INSERT INTO `tcz_classes` VALUES ('20', '乳房触诊', '2222', '3');
INSERT INTO `tcz_classes` VALUES ('21', '腹部听诊', '2222', '3');
INSERT INTO `tcz_classes` VALUES ('3', '病理性心音', 'Pathologicaleartsounds', '1');
INSERT INTO `tcz_classes` VALUES ('4', '其他疾病心音', 'Otherdisease heartsounds', '1');
INSERT INTO `tcz_classes` VALUES ('5', '基础知识', 'Basicknowle', '2');
INSERT INTO `tcz_classes` VALUES ('6', '正常呼吸音', '122222', '2');
INSERT INTO `tcz_classes` VALUES ('7', '异常呼吸音', '33333', '2');
INSERT INTO `tcz_classes` VALUES ('8', '啰音', '33333', '2');
INSERT INTO `tcz_classes` VALUES ('9', '语音共振', '22233', '2');

-- ----------------------------
-- Table structure for `tcz_czmnr`
-- ----------------------------
DROP TABLE IF EXISTS `tcz_czmnr`;
CREATE TABLE `tcz_czmnr` (
  `LOGIN_ID` varchar(255) NOT NULL,
  `肝脏肿大` varchar(255) DEFAULT NULL,
  `肝脏质地` varchar(255) DEFAULT NULL,
  `脾脏肿大` varchar(255) DEFAULT NULL,
  `胆囊触痛` varchar(255) DEFAULT NULL,
  `胆囊肿大` varchar(255) DEFAULT NULL,
  `胆囊墨菲氏征` varchar(255) DEFAULT NULL,
  `压痛胃溃疡` varchar(255) DEFAULT NULL,
  `压痛十二指肠` varchar(255) DEFAULT NULL,
  `压痛胰腺` varchar(255) DEFAULT NULL,
  `压痛阑尾` varchar(255) DEFAULT NULL,
  `压痛小肠` varchar(255) DEFAULT NULL,
  `乙状结肠` varchar(255) DEFAULT NULL,
  `反跳痛胰腺` varchar(255) DEFAULT NULL,
  `反跳痛阑尾` varchar(255) DEFAULT NULL,
  `反跳痛小肠` varchar(255) DEFAULT NULL,
  `肠鸣音` varchar(255) DEFAULT NULL,
  `肾动脉听诊音` varchar(255) DEFAULT NULL,
  `脉搏` varchar(255) DEFAULT NULL,
  `血压收缩压` varchar(255) DEFAULT NULL,
  `血压舒张压` varchar(255) DEFAULT NULL,
  `股动脉听诊音` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`LOGIN_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tcz_czmnr
-- ----------------------------
INSERT INTO `tcz_czmnr` VALUES ('', '1111', '1', '2222', '1', '1', '1', '0', '0', '0', '0', '1', '1', '1', '0', '0', '1222啊', '2', '2', '3啊', '4', '3');

-- ----------------------------
-- Table structure for `tcz_lessons`
-- ----------------------------
DROP TABLE IF EXISTS `tcz_lessons`;
CREATE TABLE `tcz_lessons` (
  `LESSON_ID` int(255) NOT NULL COMMENT '课件ID',
  `LESSON_NAME` varchar(255) NOT NULL COMMENT '课件中文名称',
  `LESSON_ENAME` varchar(255) NOT NULL COMMENT '课件英文名称',
  `LESSON_FILENAME` varchar(255) NOT NULL COMMENT '课件对应文件的名称',
  `LESSON_CLASS_ID` varchar(255) NOT NULL COMMENT '课件课程分类ID',
  `LESSON_MUSIC_FILENAME` varchar(255) DEFAULT NULL COMMENT '音频文件名',
  PRIMARY KEY (`LESSON_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tcz_lessons
-- ----------------------------
INSERT INTO `tcz_lessons` VALUES ('1', '基础1', '222', '1', '1', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('2', '基础2', '222', '2', '1', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('3', '胸膜摩擦音1', '333', '3', '10', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('4', '其他疾病呼吸音1', '444', '1', '11', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('5', '腹部触诊基础1', '555', '2', '12', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('6', '腹壁紧张度1', '66', '3', '13', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('7', '腹部包块1', '77', '1', '14', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('8', '液波震颤1', '88', '2', '15', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('9', '压痛与反跳痛1', '99', '3', '16', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('10', '胆囊触诊1', '10', '1', '17', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('11', '肝脏触诊1', '11', '2', '18', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('12', '脾脏触诊1', '12', '3', '19', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('13', '正常心音1', '13', '1', '2', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('14', '乳房触诊1', '14', '2', '20', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('15', '腹部听诊1', '15', '3', '21', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('16', '病理性心音1', '16', '1', '2', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('17', '其他疾病心音', '17', '2', '4', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('18', '基础知识1', '18', '3', '5', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('19', '正常呼吸音', '19', '正常呼吸音', '6', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('20', '异常呼吸音1', '20', '2', '7', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('21', '啰音1', '21', '3', '8', 'YouAreMySunshine');
INSERT INTO `tcz_lessons` VALUES ('22', '语音共振', '22', '1', '9', 'YouAreMySunshine');

-- ----------------------------
-- Table structure for `tcz_type`
-- ----------------------------
DROP TABLE IF EXISTS `tcz_type`;
CREATE TABLE `tcz_type` (
  `TCZ_ID` varchar(255) NOT NULL COMMENT '听触诊分类ID',
  `TCZ_NAME` varchar(255) DEFAULT NULL COMMENT '听触诊分类中文名称',
  `TCZ_ENAME` varchar(255) DEFAULT NULL COMMENT '听触诊分类英文名称',
  PRIMARY KEY (`TCZ_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tcz_type
-- ----------------------------
INSERT INTO `tcz_type` VALUES ('1', '心脏听诊', 'Xztz');
INSERT INTO `tcz_type` VALUES ('2', '肺部听诊', 'Fbtz');
INSERT INTO `tcz_type` VALUES ('3', '腹部听触诊', 'Fbtcz');

-- ----------------------------
-- Table structure for `tcz_tzmnr`
-- ----------------------------
DROP TABLE IF EXISTS `tcz_tzmnr`;
CREATE TABLE `tcz_tzmnr` (
  `LOGIN_ID` varchar(255) NOT NULL,
  `心尖搏动` varchar(255) DEFAULT NULL,
  `二尖瓣听诊区` varchar(255) DEFAULT NULL,
  `肺动脉瓣听诊区` varchar(255) DEFAULT NULL,
  `主动脉瓣区` varchar(255) DEFAULT NULL,
  `主动脉瓣第二听诊区` varchar(255) DEFAULT NULL,
  `三尖瓣区` varchar(255) DEFAULT NULL,
  `气管` varchar(255) DEFAULT NULL,
  `左肺上` varchar(255) DEFAULT NULL,
  `左肺中` varchar(255) DEFAULT NULL,
  `左肺下` varchar(255) DEFAULT NULL,
  `右肺上` varchar(255) DEFAULT NULL,
  `右肺中` varchar(255) DEFAULT NULL,
  `右肺下` varchar(255) DEFAULT NULL,
  `心前区震颤` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`LOGIN_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tcz_tzmnr
-- ----------------------------
INSERT INTO `tcz_tzmnr` VALUES ('teacher', '0', '1', '2', '', '4', '5', '6', '7的', '8', '9', '77', '88才', '99', '0');

-- ----------------------------
-- Function structure for `getScore`
-- ----------------------------
DROP FUNCTION IF EXISTS `getScore`;
DELIMITER ;;
CREATE DEFINER=`root`@`127.0.0.1` FUNCTION `getScore`(inEXAM_ID int,inUSER_ID int) RETURNS varchar(100) CHARSET utf8
BEGIN 
declare  total_num int default 0;
declare  right_num int default 0;
declare  s int default 0;  
declare  rANSWERS VARCHAR(100);
declare  rTOPIC_ID int;
declare  rRightAnswer VARCHAR(100);
declare  cursor_name CURSOR FOR select ANSWERS ,TOPIC_ID from ex_exam_result where user_id=inUSER_ID and EXAMINATION_ID=inEXAM_ID;
declare CONTINUE HANDLER FOR SQLSTATE '02000' SET s=1;
OPEN cursor_name; 
fetch  cursor_name into rANSWERS,rTOPIC_ID;  
while s <> 1 do  
select ANSWERS  into rRightAnswer from ex_topic where topic_id=rTOPIC_ID;
if STRCMP(rRightAnswer,rANSWERS)=0 then 
	set right_num=right_num+1;
end if; 
fetch  cursor_name into rANSWERS,rTOPIC_ID; 
set total_num=total_num+1;
end while; 
CLOSE cursor_name; 
return  CONCAT(FORMAT(right_num/total_num,2)*100,'%') ;
END
;;
DELIMITER ;
