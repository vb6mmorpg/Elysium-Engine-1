/*
Navicat MySQL Data Transfer

Source Server         : Connection
Source Server Version : 50626
Source Host           : localhost:3306
Source Database       : elysium_ls

Target Server Type    : MYSQL
Target Server Version : 50626
File Encoding         : 65001

Date: 2017-02-15 03:36:03
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for account
-- ----------------------------
DROP TABLE IF EXISTS `account`;
CREATE TABLE `account` (
  `id` int(11) NOT NULL DEFAULT '0',
  `account` varchar(50) NOT NULL DEFAULT '',
  `password` varchar(64) NOT NULL DEFAULT '',
  `email` varchar(100) NOT NULL DEFAULT '',
  `pin` varchar(12) NOT NULL DEFAULT '',
  `cash` int(11) NOT NULL DEFAULT '0',
  `language_id` char(1) NOT NULL DEFAULT '1',
  `logged_in` char(1) NOT NULL DEFAULT '0',
  `access_level` smallint(6) NOT NULL DEFAULT '1',
  `active` char(1) NOT NULL DEFAULT '0',
  `first_name` varchar(50) NOT NULL DEFAULT '',
  `last_name` varchar(50) NOT NULL DEFAULT '',
  `location` varchar(25) NOT NULL DEFAULT '',
  `date_created` datetime NOT NULL,
  `date_last_login` datetime NOT NULL,
  `creator_ip` varchar(15) NOT NULL DEFAULT '',
  `last_ip` varchar(15) NOT NULL DEFAULT '',
  `current_ip` varchar(15) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account
-- ----------------------------
INSERT INTO `account` VALUES ('1', 'akaruz', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'juliosperandio@hotmail.com', '91306354', '0', '1', '1', '1', '1', 'Julio', 'Sperandio', 'Brazil', '2015-07-07 17:45:02', '2017-02-13 09:06:10', '127.0.0.1', '127.0.0.1', '127.0.0.1');
INSERT INTO `account` VALUES ('2', 'dragonick', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'juliosperandio@hotmail.com', '19676091', '0', '3', '0', '3', '1', 'Julio', 'Sperandio', '日本', '2015-07-07 17:45:02', '2017-02-13 03:36:48', '127.0.0.1', '127.0.0.1', '');
INSERT INTO `account` VALUES ('3', 'nadaila', '39046213b04423ced40ff162cefd811ffd4a4f939083b1bf151ca47f7f864705', 'nadaila@hotmail.com', '196760', '0', '1', '0', '1', '1', 'Julio', 'Sperandio', 'Brazil', '2015-07-07 17:45:02', '2017-02-13 03:36:48', '127.0.0.1', '', '');

-- ----------------------------
-- Table structure for account_ban
-- ----------------------------
DROP TABLE IF EXISTS `account_ban`;
CREATE TABLE `account_ban` (
  `id` int(11) NOT NULL DEFAULT '0',
  `account_id` int(11) NOT NULL DEFAULT '0',
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `reason` varchar(100) NOT NULL DEFAULT '',
  `expire` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `id_account` (`account_id`) USING BTREE,
  CONSTRAINT `ban_fk` FOREIGN KEY (`account_id`) REFERENCES `account` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_ban
-- ----------------------------
INSERT INTO `account_ban` VALUES ('1', '1', '2014-06-17 02:31:12', '2017-02-07 02:31:22', '役に立つ', '1');

-- ----------------------------
-- Table structure for account_rewards
-- ----------------------------
DROP TABLE IF EXISTS `account_rewards`;
CREATE TABLE `account_rewards` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account_id` int(11) NOT NULL,
  `added` varchar(70) NOT NULL DEFAULT '',
  `points` int(11) NOT NULL DEFAULT '0',
  `bonus_points` int(11) NOT NULL DEFAULT '0',
  `received` varchar(70) NOT NULL DEFAULT '0',
  `rewarded` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `rewards_fk` (`account_id`),
  CONSTRAINT `rewards_fk` FOREIGN KEY (`account_id`) REFERENCES `account` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_rewards
-- ----------------------------

-- ----------------------------
-- Table structure for account_service
-- ----------------------------
DROP TABLE IF EXISTS `account_service`;
CREATE TABLE `account_service` (
  `id` int(11) NOT NULL,
  `account_id` int(11) NOT NULL,
  `service_id` int(11) NOT NULL DEFAULT '0',
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `expire` tinyint(4) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `service_fk` (`account_id`),
  CONSTRAINT `service_fk` FOREIGN KEY (`account_id`) REFERENCES `account` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of account_service
-- ----------------------------
INSERT INTO `account_service` VALUES ('1', '1', '4', '2016-12-21 02:42:26', '2017-12-28 02:42:34', '0');

-- ----------------------------
-- Table structure for banned_ip
-- ----------------------------
DROP TABLE IF EXISTS `banned_ip`;
CREATE TABLE `banned_ip` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `address` varchar(45) NOT NULL,
  `end_time` datetime NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `mask` (`address`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of banned_ip
-- ----------------------------
