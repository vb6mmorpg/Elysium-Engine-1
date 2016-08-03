/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50626
Source Host           : localhost:3306
Source Database       : elysium_ls

Target Server Type    : MYSQL
Target Server Version : 50626
File Encoding         : 65001

Date: 2016-04-21 16:45:16
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for account
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account` (
  `id` int(11) NOT NULL DEFAULT '0',
  `account` varchar(100) NOT NULL DEFAULT '',
  `password` varchar(100) NOT NULL DEFAULT '',
  `email` varchar(100) NOT NULL DEFAULT '',
  `pin` varchar(12) NOT NULL DEFAULT '',
  `cash` int(11) NOT NULL DEFAULT '0',
  `language_id` char(1) NOT NULL DEFAULT '1',
  `logged_in` char(1) NOT NULL DEFAULT '0',
  `access_level` int(4) NOT NULL DEFAULT '1',
  `active` char(1) NOT NULL DEFAULT '0',
  `first_name` varchar(50) NOT NULL DEFAULT '',
  `last_name` varchar(50) NOT NULL DEFAULT '',
  `location` varchar(25) NOT NULL DEFAULT '',
  `date_created` varchar(25) NOT NULL DEFAULT '',
  `date_last_login` varchar(20) NOT NULL DEFAULT '',
  `creator_ip` varchar(20) NOT NULL DEFAULT '',
  `last_ip` varchar(20) NOT NULL DEFAULT '',
  `current_ip` varchar(20) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account
-- ----------------------------
INSERT INTO `account` VALUES ('1', 'akaruz', 'datamore', 'juliosperandio@hotmail.com', '91306354', '0', '1', '0', '1', '1', 'Julio', 'Sperandio', 'Brazil', '08/09/2014 11:15', '2016/02/26 1:29:13', '127.0.0.1', '127.0.0.1', ' ');
INSERT INTO `account` VALUES ('2', 'dragonick', 'datamore', 'juliosperandio@hotmail.com', '19676091', '0', '3', '0', '3', '1', 'Julio', 'Sperandio', '日本', '08/09/2014 11:15', '24/12/2015 19:00:01', '127.0.0.1', '127.0.0.1', ' ');

-- ----------------------------
-- Table structure for account_ban
-- ----------------------------
DROP TABLE IF EXISTS `account_ban`;
CREATE TABLE `account_ban` (
  `id` int(11) NOT NULL DEFAULT '0',
  `account_id` int(11) NOT NULL DEFAULT '0',
  `start_time` varchar(20) NOT NULL DEFAULT '',
  `end_time` varchar(20) NOT NULL DEFAULT '',
  `reason` varchar(100) NOT NULL DEFAULT '',
  `expire` int(3) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `id_account` (`account_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_ban
-- ----------------------------
INSERT INTO `account_ban` VALUES ('1', '1', '02/12/2014', '01/01/2015', '役に立つ', '1');

-- ----------------------------
-- Table structure for account_rewards
-- ----------------------------
DROP TABLE IF EXISTS `account_rewards`;
CREATE TABLE `account_rewards` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account_id` int(11) NOT NULL,
  `added` varchar(70) NOT NULL DEFAULT '',
  `points` decimal(20,0) NOT NULL DEFAULT '0',
  `bonus_points` decimal(20,0) NOT NULL DEFAULT '0',
  `received` varchar(70) NOT NULL DEFAULT '0',
  `rewarded` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_rewards
-- ----------------------------

-- ----------------------------
-- Table structure for account_service
-- ----------------------------
DROP TABLE IF EXISTS `account_service`;
CREATE TABLE `account_service` (
  `id` int(10) NOT NULL,
  `account_id` int(10) DEFAULT NULL,
  `service_id` int(10) DEFAULT NULL,
  `start_time` varchar(25) DEFAULT NULL,
  `end_time` varchar(25) DEFAULT NULL,
  `expire` int(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_service
-- ----------------------------
INSERT INTO `account_service` VALUES ('1', '1', '4', '25/08/2015 15:30', '03/01/2016 15:30', '1');

-- ----------------------------
-- Table structure for banned_ip
-- ----------------------------
DROP TABLE IF EXISTS `banned_ip`;
CREATE TABLE `banned_ip` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `address` varchar(45) NOT NULL,
  `end_time` varchar(20) DEFAULT '',
  PRIMARY KEY (`id`),
  UNIQUE KEY `mask` (`address`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of banned_ip
-- ----------------------------
