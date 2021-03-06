/*
Navicat MySQL Data Transfer

Source Server         : Connection
Source Server Version : 50621
Source Host           : localhost:3306
Source Database       : elysium_gs

Target Server Type    : MYSQL
Target Server Version : 50621
File Encoding         : 65001

Date: 2015-01-11 00:45:13
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for characters
-- ----------------------------
DROP TABLE IF EXISTS `characters`;
CREATE TABLE `characters` (
  `id` int(10) NOT NULL,
  `account_id` int(10) DEFAULT '0',
  `class_id` int(10) DEFAULT '0',
  `guild_id` int(10) DEFAULT '0',
  `char_slot` int(10) DEFAULT '0',
  `name` varchar(25) DEFAULT '',
  `level` int(10) DEFAULT '1',
  `exp` bigint(11) DEFAULT '0',
  `gender` int(4) DEFAULT '0',
  `sprite` int(10) DEFAULT '0',
  `strenght` int(10) DEFAULT '0',
  `dexterity` int(10) DEFAULT '0',
  `agility` int(10) DEFAULT '0',
  `vitality` int(10) DEFAULT '0',
  `intelligence` int(10) DEFAULT '0',
  `mind` int(10) DEFAULT '0',
  `statpoints` int(10) DEFAULT '0',
  `world_id` int(10) DEFAULT '0',
  `posx` int(5) DEFAULT '0',
  `posy` int(5) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of characters
-- ----------------------------
INSERT INTO `characters` VALUES ('1', '1', '0', '0', '0', 'ドラゴニック', '1', '0', '0', '4', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `characters` VALUES ('2', '1', '1', '0', '1', 'ナダイラ', '1', '0', '0', '22', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `characters` VALUES ('3', '1', '0', '0', '2', 'タエオ', '1', '0', '0', '15', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `characters` VALUES ('4', '1', '1', '0', '3', 'カロンネ', '1', '0', '0', '23', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');

-- ----------------------------
-- Table structure for classes
-- ----------------------------
DROP TABLE IF EXISTS `classes`;
CREATE TABLE `classes` (
  `id` int(10) NOT NULL,
  `increment_id` int(10) DEFAULT '0',
  `name` varchar(25) DEFAULT '',
  `gender` int(4) DEFAULT '0',
  `sprite_female` int(10) DEFAULT '0',
  `sprite_male` int(10) DEFAULT '0',
  `level` int(10) DEFAULT '1',
  `regen_hp` int(10) DEFAULT '0',
  `regen_mp` int(10) DEFAULT '0',
  `regen_sp` int(10) DEFAULT '0',
  `hp` int(10) DEFAULT '0',
  `mp` int(10) DEFAULT '0',
  `sp` int(10) DEFAULT '0',
  `strenght` int(10) DEFAULT '0',
  `dexterity` int(10) DEFAULT '0',
  `agility` int(10) DEFAULT '0',
  `vitality` int(10) DEFAULT '0',
  `intelligence` int(10) DEFAULT '0',
  `mind` int(10) DEFAULT '0',
  `points` int(10) DEFAULT '0',
  `critical_rate` int(10) DEFAULT '0',
  `critical_damage` int(10) DEFAULT '0',
  `magic_critical_rate` int(10) DEFAULT '0',
  `magic_critical_damage` int(10) DEFAULT '0',
  `healing_power` int(10) DEFAULT '0',
  `attack` int(10) DEFAULT '0',
  `accuracy` int(10) DEFAULT '0',
  `defense` int(10) DEFAULT '0',
  `evasion` int(10) DEFAULT '0',
  `block` int(10) DEFAULT '0',
  `magic_attack` int(10) DEFAULT '0',
  `magic_accuracy` int(10) DEFAULT '0',
  `magic_defense` int(10) DEFAULT '0',
  `magic_resist` int(10) DEFAULT '0',
  `damage_suppression` int(10) DEFAULT '0',
  `additional_damage` int(10) DEFAULT '0',
  `enmity` int(10) DEFAULT '0',
  `attack_speed` int(10) DEFAULT '0',
  `cast_speed` int(10) DEFAULT '0',
  `attribute_fire` int(10) DEFAULT '0',
  `attribute_water` int(10) DEFAULT '0',
  `attribute_earth` int(10) DEFAULT '0',
  `attribute_wind` int(10) DEFAULT '0',
  `resist_stun` int(10) DEFAULT '0',
  `resist_silence` int(10) DEFAULT '0',
  `resist_paralysis` int(10) DEFAULT '0',
  `resist_critical_rate` int(10) DEFAULT '0',
  `resist_critical_damage` int(10) DEFAULT '0',
  `resist_magic_critical_rate` int(10) DEFAULT '0',
  `resist_magic_critical_damage` int(10) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of classes
-- ----------------------------
INSERT INTO `classes` VALUES ('0', '0', 'Gladiador', '0', '15', '4', '1', '0', '0', '0', '110', '65', '10', '10', '5', '5', '8', '1', '1', '0', '5', '20', '5', '20', '5', '41', '52', '21', '11', '61', '7', '12', '6', '6', '0', '0', '0', '2000', '2000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `classes` VALUES ('1', '1', 'Mago', '0', '23', '22', '1', '0', '0', '0', '100', '50', '10', '2', '3', '3', '4', '13', '1', '0', '5', '20', '5', '20', '16', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '2000', '2000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');
INSERT INTO `classes` VALUES ('2', '2', 'Arqueiro', '0', '19', '20', '1', '0', '0', '0', '90', '60', '10', '5', '8', '13', '6', '3', '1', '0', '5', '20', '5', '20', '5', '22', '23', '9', '13', '8', '0', '0', '0', '0', '0', '0', '8', '2000', '2000', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0');

-- ----------------------------
-- Table structure for classes_increment
-- ----------------------------
DROP TABLE IF EXISTS `classes_increment`;
CREATE TABLE `classes_increment` (
  `id` int(11) NOT NULL,
  `name` varchar(20) DEFAULT '',
  `hp` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `mp` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `sp` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `regen_hp` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `regen_mp` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `regen_sp` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `strenght` int(11) DEFAULT '0',
  `dexterity` int(11) DEFAULT '0',
  `agility` int(11) DEFAULT '0',
  `vitality` int(11) DEFAULT '0',
  `intelligence` int(11) DEFAULT '0',
  `mind` int(11) DEFAULT '0',
  `points` int(11) DEFAULT '0',
  `critical_rate` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `critical_damage` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `magic_critical_rate` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `magic_critical_damage` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `healing_power` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `attack` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `accuracy` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `defense` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `evasion` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `block` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `magic_attack` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `magic_accuracy` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `magic_defense` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `magic_resist` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `damage_suppression` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `additional_damage` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `enmity` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `attack_speed` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `cast_speed` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `attribute_fire` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `attribute_water` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `attribute_earth` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `attribute_wind` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `resist_stun` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `resist_silence` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `resist_paralysis` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `resist_critical_rate` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `resist_critical_damage` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `resist_magic_critical_rate` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  `resist_magic_critical_damage` varchar(100) DEFAULT '0;0;0;0;0;0;0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of classes_increment
-- ----------------------------
INSERT INTO `classes_increment` VALUES ('0', 'Gladiador', '10;0;0;0;5;0;0', '10;0;0;0;0;5;0', '10;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0', '0', '0', '0', '0', '0', '5', '0;0;1;1;0;0;0', '0;1;1;1;0;0;0', '0;0;1;1;0;0;0', '1;0;1;1;0;0;0', '0;0;0;0;0;0;5', '1;3;1;1;0;0;0', '2;0;5;5;0;0;0', '1;0;2;2;0;0;0', '1;0;1;1;0;0;0', '1;5;2;0;0;0;0', '1;0;0;0;0;5;1', '1;0;0;1;0;5;1', '1;0;0;0;0;5;0', '1;0;0;0;0;5;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '1;0;2;2;0;0;0', '1;0;2;2;0;1;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0');
INSERT INTO `classes_increment` VALUES ('1', 'Mago', '5;0;0;0;5;0;0', '5;0;0;0;0;10;0', '10;0;0;0;0;0;0', '1;0;0;0;1;0;0', '1;0;0;0;0;1;0', '0;0;0;0;0;0;0', '0', '0', '0', '0', '1', '0', '5', '1;0;2;2;0;0;0', '1;0;2;2;0;0;0', '1;0;2;2;0;1;0', '1;0;2;2;0;3;0', '1;0;0;0;0;0;5', '0;2;1;1;0;0;0', '1;1;3;3;0;0;0', '1;0;2;2;0;0;0', '1;0;2;2;0;0;0', '1;5;0;0;0;0;0', '1;0;0;0;0;5;0', '1;0;1;1;0;3;0', '1;0;0;0;0;2;0', '1;0;0;0;0;2;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '1;0;2;2;0;1;0', '1;0;2;2;0;1;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0', '0;0;0;0;0;0;0');

-- ----------------------------
-- Table structure for data_exp
-- ----------------------------
DROP TABLE IF EXISTS `data_exp`;
CREATE TABLE `data_exp` (
  `level` int(10) unsigned NOT NULL,
  `exp_to_reach_lvl` bigint(20) unsigned NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of data_exp
-- ----------------------------
INSERT INTO `data_exp` VALUES ('0', '0');
INSERT INTO `data_exp` VALUES ('1', '0');
INSERT INTO `data_exp` VALUES ('2', '14');
INSERT INTO `data_exp` VALUES ('3', '20');
INSERT INTO `data_exp` VALUES ('4', '36');
INSERT INTO `data_exp` VALUES ('5', '90');
INSERT INTO `data_exp` VALUES ('6', '152');
INSERT INTO `data_exp` VALUES ('7', '250');
INSERT INTO `data_exp` VALUES ('8', '352');
INSERT INTO `data_exp` VALUES ('9', '480');
INSERT INTO `data_exp` VALUES ('10', '591');
INSERT INTO `data_exp` VALUES ('11', '743');
INSERT INTO `data_exp` VALUES ('12', '973');
INSERT INTO `data_exp` VALUES ('13', '1290');
INSERT INTO `data_exp` VALUES ('14', '1632');
INSERT INTO `data_exp` VALUES ('15', '1928');
INSERT INTO `data_exp` VALUES ('16', '2340');
INSERT INTO `data_exp` VALUES ('17', '3480');
INSERT INTO `data_exp` VALUES ('18', '4125');
INSERT INTO `data_exp` VALUES ('19', '4995');
INSERT INTO `data_exp` VALUES ('20', '5880');
INSERT INTO `data_exp` VALUES ('21', '7840');
INSERT INTO `data_exp` VALUES ('22', '6875');
INSERT INTO `data_exp` VALUES ('23', '8243');
INSERT INTO `data_exp` VALUES ('24', '10380');
INSERT INTO `data_exp` VALUES ('25', '13052');
INSERT INTO `data_exp` VALUES ('26', '16450');
INSERT INTO `data_exp` VALUES ('27', '20700');
INSERT INTO `data_exp` VALUES ('28', '26143');
INSERT INTO `data_exp` VALUES ('29', '31950');
INSERT INTO `data_exp` VALUES ('30', '38640');
INSERT INTO `data_exp` VALUES ('31', '57035');
INSERT INTO `data_exp` VALUES ('32', '65000');
INSERT INTO `data_exp` VALUES ('33', '69125');
INSERT INTO `data_exp` VALUES ('34', '72000');
INSERT INTO `data_exp` VALUES ('35', '87239');
INSERT INTO `data_exp` VALUES ('36', '105863');
INSERT INTO `data_exp` VALUES ('37', '128694');
INSERT INTO `data_exp` VALUES ('38', '182307');
INSERT INTO `data_exp` VALUES ('39', '221450');
INSERT INTO `data_exp` VALUES ('40', '269042');
INSERT INTO `data_exp` VALUES ('41', '390368');
INSERT INTO `data_exp` VALUES ('42', '438550');
INSERT INTO `data_exp` VALUES ('43', '458137');
INSERT INTO `data_exp` VALUES ('44', '468943');
INSERT INTO `data_exp` VALUES ('45', '560177');
INSERT INTO `data_exp` VALUES ('46', '669320');
INSERT INTO `data_exp` VALUES ('47', '799963');
INSERT INTO `data_exp` VALUES ('48', '1115396');
INSERT INTO `data_exp` VALUES ('49', '1331100');
INSERT INTO `data_exp` VALUES ('50', '1590273');
INSERT INTO `data_exp` VALUES ('51', '2306878');
INSERT INTO `data_exp` VALUES ('52', '2594255');
INSERT INTO `data_exp` VALUES ('53', '2711490');
INSERT INTO `data_exp` VALUES ('54', '2777349');
INSERT INTO `data_exp` VALUES ('55', '3318059');
INSERT INTO `data_exp` VALUES ('56', '3963400');
INSERT INTO `data_exp` VALUES ('57', '4735913');
INSERT INTO `data_exp` VALUES ('58', '6600425');
INSERT INTO `data_exp` VALUES ('59', '7886110');
INSERT INTO `data_exp` VALUES ('60', '9421875');
INSERT INTO `data_exp` VALUES ('61', '13547310');
INSERT INTO `data_exp` VALUES ('62', '15099446');
INSERT INTO `data_exp` VALUES ('63', '15644776');
INSERT INTO `data_exp` VALUES ('64', '15885934');
INSERT INTO `data_exp` VALUES ('65', '18817757');
INSERT INTO `data_exp` VALUES ('66', '22280630');
INSERT INTO `data_exp` VALUES ('67', '26392968');
INSERT INTO `data_exp` VALUES ('68', '36465972');
INSERT INTO `data_exp` VALUES ('69', '43184958');
INSERT INTO `data_exp` VALUES ('70', '51141217');
INSERT INTO `data_exp` VALUES ('71', '73556918');
INSERT INTO `data_exp` VALUES ('72', '81991117');
INSERT INTO `data_exp` VALUES ('73', '84966758');
INSERT INTO `data_exp` VALUES ('74', '86252845');
INSERT INTO `data_exp` VALUES ('75', '102171368');
INSERT INTO `data_exp` VALUES ('76', '120995493');
INSERT INTO `data_exp` VALUES ('77', '143307208');
INSERT INTO `data_exp` VALUES ('78', '198000645');
INSERT INTO `data_exp` VALUES ('79', '234477760');
INSERT INTO `data_exp` VALUES ('80', '277716683');
INSERT INTO `data_exp` VALUES ('81', '381795797');
INSERT INTO `data_exp` VALUES ('82', '406848219');
INSERT INTO `data_exp` VALUES ('83', '403044458');
INSERT INTO `data_exp` VALUES ('84', '391191019');
INSERT INTO `data_exp` VALUES ('85', '442876559');
INSERT INTO `data_exp` VALUES ('86', '501408635');
INSERT INTO `data_exp` VALUES ('87', '567694433');
INSERT INTO `data_exp` VALUES ('88', '749813704');
INSERT INTO `data_exp` VALUES ('89', '849001357');
INSERT INTO `data_exp` VALUES ('90', '961154774');
INSERT INTO `data_exp` VALUES ('91', '1309582668');
INSERT INTO `data_exp` VALUES ('92', '1382799035');
INSERT INTO `data_exp` VALUES ('93', '1357505030');
INSERT INTO `data_exp` VALUES ('94', '1305632790');
INSERT INTO `data_exp` VALUES ('95', '1464862605');
INSERT INTO `data_exp` VALUES ('96', '1628695740');
INSERT INTO `data_exp` VALUES ('97', '1810772333');
INSERT INTO `data_exp` VALUES ('98', '2348583653');
INSERT INTO `data_exp` VALUES ('99', '2611145432');
INSERT INTO `data_exp` VALUES ('100', '2903009208');
INSERT INTO `data_exp` VALUES ('101', '3919352097');
INSERT INTO `data_exp` VALUES ('102', '4063358600');
INSERT INTO `data_exp` VALUES ('103', '3916810682');
INSERT INTO `data_exp` VALUES ('104', '4314535354');
INSERT INTO `data_exp` VALUES ('105', '4752892146');
INSERT INTO `data_exp` VALUES ('106', '5235785988');
INSERT INTO `data_exp` VALUES ('107', '5767741845');
INSERT INTO `data_exp` VALUES ('108', '6353744416');
INSERT INTO `data_exp` VALUES ('109', '6999284849');
INSERT INTO `data_exp` VALUES ('110', '7710412189');
INSERT INTO `data_exp` VALUES ('111', '8493790068');
INSERT INTO `data_exp` VALUES ('112', '9356759139');
INSERT INTO `data_exp` VALUES ('113', '10307405867');
INSERT INTO `data_exp` VALUES ('114', '11354638303');
INSERT INTO `data_exp` VALUES ('115', '12508269555');
INSERT INTO `data_exp` VALUES ('116', '13779109742');
INSERT INTO `data_exp` VALUES ('117', '15179067292');
INSERT INTO `data_exp` VALUES ('118', '16721260528');
INSERT INTO `data_exp` VALUES ('119', '18420140598');
INSERT INTO `data_exp` VALUES ('120', '20291626883');
INSERT INTO `data_exp` VALUES ('121', '22353256174');

-- ----------------------------
-- Table structure for data_sxp
-- ----------------------------
DROP TABLE IF EXISTS `data_sxp`;
CREATE TABLE `data_sxp` (
  `sxp_to_reach_level` int(11) NOT NULL,
  `skill_level` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`skill_level`)
) ENGINE=MyISAM AUTO_INCREMENT=100 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of data_sxp
-- ----------------------------
INSERT INTO `data_sxp` VALUES ('81', '1');
INSERT INTO `data_sxp` VALUES ('94', '2');
INSERT INTO `data_sxp` VALUES ('112', '3');
INSERT INTO `data_sxp` VALUES ('166', '4');
INSERT INTO `data_sxp` VALUES ('228', '5');
INSERT INTO `data_sxp` VALUES ('326', '6');
INSERT INTO `data_sxp` VALUES ('428', '7');
INSERT INTO `data_sxp` VALUES ('556', '8');
INSERT INTO `data_sxp` VALUES ('666', '9');
INSERT INTO `data_sxp` VALUES ('818', '10');
INSERT INTO `data_sxp` VALUES ('1049', '11');
INSERT INTO `data_sxp` VALUES ('1366', '12');
INSERT INTO `data_sxp` VALUES ('1708', '13');
INSERT INTO `data_sxp` VALUES ('2004', '14');
INSERT INTO `data_sxp` VALUES ('2416', '15');
INSERT INTO `data_sxp` VALUES ('3556', '16');
INSERT INTO `data_sxp` VALUES ('4201', '17');
INSERT INTO `data_sxp` VALUES ('5071', '18');
INSERT INTO `data_sxp` VALUES ('5956', '19');
INSERT INTO `data_sxp` VALUES ('7916', '20');
INSERT INTO `data_sxp` VALUES ('6951', '21');
INSERT INTO `data_sxp` VALUES ('8318', '22');
INSERT INTO `data_sxp` VALUES ('10456', '23');
INSERT INTO `data_sxp` VALUES ('13127', '24');
INSERT INTO `data_sxp` VALUES ('16526', '25');
INSERT INTO `data_sxp` VALUES ('20776', '26');
INSERT INTO `data_sxp` VALUES ('26219', '27');
INSERT INTO `data_sxp` VALUES ('32026', '28');
INSERT INTO `data_sxp` VALUES ('38716', '29');
INSERT INTO `data_sxp` VALUES ('57111', '30');
INSERT INTO `data_sxp` VALUES ('65076', '31');
INSERT INTO `data_sxp` VALUES ('69201', '32');
INSERT INTO `data_sxp` VALUES ('72076', '33');
INSERT INTO `data_sxp` VALUES ('87315', '34');
INSERT INTO `data_sxp` VALUES ('105939', '35');
INSERT INTO `data_sxp` VALUES ('128770', '36');
INSERT INTO `data_sxp` VALUES ('182382', '37');
INSERT INTO `data_sxp` VALUES ('221526', '38');
INSERT INTO `data_sxp` VALUES ('269117', '39');
INSERT INTO `data_sxp` VALUES ('390443', '40');
INSERT INTO `data_sxp` VALUES ('438626', '41');
INSERT INTO `data_sxp` VALUES ('458212', '42');
INSERT INTO `data_sxp` VALUES ('469018', '43');
INSERT INTO `data_sxp` VALUES ('560252', '44');
INSERT INTO `data_sxp` VALUES ('669396', '45');
INSERT INTO `data_sxp` VALUES ('800039', '46');
INSERT INTO `data_sxp` VALUES ('1115471', '47');
INSERT INTO `data_sxp` VALUES ('1331176', '48');
INSERT INTO `data_sxp` VALUES ('1590349', '49');
INSERT INTO `data_sxp` VALUES ('2306953', '50');
INSERT INTO `data_sxp` VALUES ('2594331', '51');
INSERT INTO `data_sxp` VALUES ('2711566', '52');
INSERT INTO `data_sxp` VALUES ('2777425', '53');
INSERT INTO `data_sxp` VALUES ('3318153', '54');
INSERT INTO `data_sxp` VALUES ('3963476', '55');
INSERT INTO `data_sxp` VALUES ('4735988', '56');
INSERT INTO `data_sxp` VALUES ('6600501', '57');
INSERT INTO `data_sxp` VALUES ('7886186', '58');
INSERT INTO `data_sxp` VALUES ('9421951', '59');
INSERT INTO `data_sxp` VALUES ('13547386', '60');
INSERT INTO `data_sxp` VALUES ('15099521', '61');
INSERT INTO `data_sxp` VALUES ('15644851', '62');
INSERT INTO `data_sxp` VALUES ('15886010', '63');
INSERT INTO `data_sxp` VALUES ('18817832', '64');
INSERT INTO `data_sxp` VALUES ('22280706', '65');
INSERT INTO `data_sxp` VALUES ('26393044', '66');
INSERT INTO `data_sxp` VALUES ('36466047', '67');
INSERT INTO `data_sxp` VALUES ('43185033', '68');
INSERT INTO `data_sxp` VALUES ('51141292', '69');
INSERT INTO `data_sxp` VALUES ('73556993', '70');
INSERT INTO `data_sxp` VALUES ('81991192', '71');
INSERT INTO `data_sxp` VALUES ('84966834', '72');
INSERT INTO `data_sxp` VALUES ('86252921', '73');
INSERT INTO `data_sxp` VALUES ('102171444', '74');
INSERT INTO `data_sxp` VALUES ('120995568', '75');
INSERT INTO `data_sxp` VALUES ('143307283', '76');
INSERT INTO `data_sxp` VALUES ('198000721', '77');
INSERT INTO `data_sxp` VALUES ('234477836', '78');
INSERT INTO `data_sxp` VALUES ('277716758', '79');
INSERT INTO `data_sxp` VALUES ('381795872', '80');
INSERT INTO `data_sxp` VALUES ('406848295', '81');
INSERT INTO `data_sxp` VALUES ('403044533', '82');
INSERT INTO `data_sxp` VALUES ('391191095', '83');
INSERT INTO `data_sxp` VALUES ('442876635', '84');
INSERT INTO `data_sxp` VALUES ('501408711', '85');
INSERT INTO `data_sxp` VALUES ('567694509', '86');
INSERT INTO `data_sxp` VALUES ('749813780', '87');
INSERT INTO `data_sxp` VALUES ('849001432', '88');
INSERT INTO `data_sxp` VALUES ('961145850', '89');
INSERT INTO `data_sxp` VALUES ('1309582744', '90');
INSERT INTO `data_sxp` VALUES ('1382799111', '91');
INSERT INTO `data_sxp` VALUES ('1357505106', '92');
INSERT INTO `data_sxp` VALUES ('1305632866', '93');
INSERT INTO `data_sxp` VALUES ('1464862681', '94');
INSERT INTO `data_sxp` VALUES ('1628695816', '95');
INSERT INTO `data_sxp` VALUES ('1810772409', '96');
INSERT INTO `data_sxp` VALUES ('2147483647', '97');
INSERT INTO `data_sxp` VALUES ('2147483647', '98');
INSERT INTO `data_sxp` VALUES ('2147483647', '99');

-- ----------------------------
-- Table structure for guilds
-- ----------------------------
DROP TABLE IF EXISTS `guilds`;
CREATE TABLE `guilds` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `owner_id` int(11) NOT NULL DEFAULT '0',
  `owner_name` varchar(20) NOT NULL DEFAULT '',
  `guild_name` varchar(25) NOT NULL DEFAULT '',
  `level` int(11) NOT NULL DEFAULT '1',
  `exp` int(11) NOT NULL DEFAULT '0',
  `contribution_points` int(11) NOT NULL DEFAULT '0',
  `rank_pos` int(11) NOT NULL DEFAULT '0',
  `announcement` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of guilds
-- ----------------------------
INSERT INTO `guilds` VALUES ('1', '109', 'カロンネ', 'H.O.T.Aw', '1', '7', '768', '1', '日本語で一つ目のメッセージテスト');
INSERT INTO `guilds` VALUES ('2', '110', '나무', 'B地区', '1', '7', '768', '1', '日本語で二つ目のメッセージテスト');
INSERT INTO `guilds` VALUES ('14', '115', 'Nadaila', '銀魂', '1', '7', '768', '1', '日本語で三つ目のメッセージテスト');

-- ----------------------------
-- Table structure for guilds_exp
-- ----------------------------
DROP TABLE IF EXISTS `guilds_exp`;
CREATE TABLE `guilds_exp` (
  `nextlevel` int(11) unsigned NOT NULL DEFAULT '0',
  `req_exp` int(11) NOT NULL DEFAULT '0',
  `req_contribution` int(11) NOT NULL DEFAULT '0',
  `req_money` int(11) NOT NULL DEFAULT '0',
  `max_members` int(11) NOT NULL DEFAULT '0'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of guilds_exp
-- ----------------------------
INSERT INTO `guilds_exp` VALUES ('1', '0', '0', '0', '30');
INSERT INTO `guilds_exp` VALUES ('2', '24', '24', '10', '30');
INSERT INTO `guilds_exp` VALUES ('3', '205', '205', '20', '32');
INSERT INTO `guilds_exp` VALUES ('4', '485', '485', '30', '32');
INSERT INTO `guilds_exp` VALUES ('5', '1353', '1353', '40', '34');
INSERT INTO `guilds_exp` VALUES ('6', '2338', '2338', '50', '34');
INSERT INTO `guilds_exp` VALUES ('7', '4547', '4547', '60', '36');
INSERT INTO `guilds_exp` VALUES ('8', '6788', '6788', '70', '36');
INSERT INTO `guilds_exp` VALUES ('9', '11045', '11045', '80', '38');
INSERT INTO `guilds_exp` VALUES ('10', '15151', '15151', '90', '38');
INSERT INTO `guilds_exp` VALUES ('11', '22183', '22183', '100', '40');
INSERT INTO `guilds_exp` VALUES ('12', '28800', '28800', '110', '40');
INSERT INTO `guilds_exp` VALUES ('13', '39340', '39340', '120', '42');
INSERT INTO `guilds_exp` VALUES ('14', '49135', '49135', '130', '42');
INSERT INTO `guilds_exp` VALUES ('15', '63920', '63920', '140', '44');
INSERT INTO `guilds_exp` VALUES ('16', '71608', '71608', '150', '44');
INSERT INTO `guilds_exp` VALUES ('17', '84365', '84365', '160', '46');
INSERT INTO `guilds_exp` VALUES ('18', '91041', '91041', '170', '46');
INSERT INTO `guilds_exp` VALUES ('19', '109698', '109698', '180', '48');
INSERT INTO `guilds_exp` VALUES ('20', '115152', '115152', '190', '48');
INSERT INTO `guilds_exp` VALUES ('21', '134545', '134545', '200', '49');
INSERT INTO `guilds_exp` VALUES ('22', '156813', '156813', '210', '50');
INSERT INTO `guilds_exp` VALUES ('23', '182351', '182351', '220', '51');
INSERT INTO `guilds_exp` VALUES ('24', '211610', '211610', '230', '52');
INSERT INTO `guilds_exp` VALUES ('25', '245099', '245099', '240', '53');
INSERT INTO `guilds_exp` VALUES ('26', '283396', '283396', '250', '54');
INSERT INTO `guilds_exp` VALUES ('27', '327152', '327152', '260', '55');
INSERT INTO `guilds_exp` VALUES ('28', '377106', '377106', '270', '56');
INSERT INTO `guilds_exp` VALUES ('29', '434090', '434090', '280', '57');
INSERT INTO `guilds_exp` VALUES ('30', '499049', '499049', '290', '58');
INSERT INTO `guilds_exp` VALUES ('31', '573046', '573046', '300', '59');
INSERT INTO `guilds_exp` VALUES ('32', '657283', '657283', '310', '60');
INSERT INTO `guilds_exp` VALUES ('33', '753119', '753119', '320', '61');
INSERT INTO `guilds_exp` VALUES ('34', '862086', '862086', '330', '62');
INSERT INTO `guilds_exp` VALUES ('35', '985913', '985913', '340', '63');
INSERT INTO `guilds_exp` VALUES ('36', '1126550', '1126550', '350', '64');
INSERT INTO `guilds_exp` VALUES ('37', '1286198', '1286198', '360', '65');
INSERT INTO `guilds_exp` VALUES ('38', '1467338', '1467338', '370', '66');
INSERT INTO `guilds_exp` VALUES ('39', '1672765', '1672765', '380', '67');
INSERT INTO `guilds_exp` VALUES ('40', '1905631', '1905631', '390', '68');
INSERT INTO `guilds_exp` VALUES ('41', '2169488', '2169488', '400', '69');
INSERT INTO `guilds_exp` VALUES ('42', '2468335', '2468335', '410', '70');
INSERT INTO `guilds_exp` VALUES ('43', '2806677', '2806677', '420', '71');
INSERT INTO `guilds_exp` VALUES ('44', '3189588', '3189588', '430', '72');
INSERT INTO `guilds_exp` VALUES ('45', '3622778', '3622778', '440', '73');
INSERT INTO `guilds_exp` VALUES ('46', '4112677', '4112677', '450', '74');
INSERT INTO `guilds_exp` VALUES ('47', '4666517', '4666517', '460', '75');
INSERT INTO `guilds_exp` VALUES ('48', '5292439', '5292439', '470', '76');
INSERT INTO `guilds_exp` VALUES ('49', '5999599', '5999599', '480', '77');
INSERT INTO `guilds_exp` VALUES ('50', '7500000', '7500000', '490', '80');

-- ----------------------------
-- Table structure for guilds_history
-- ----------------------------
DROP TABLE IF EXISTS `guilds_history`;
CREATE TABLE `guilds_history` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `guild_id` int(11) NOT NULL DEFAULT '0',
  `date` varchar(35) NOT NULL DEFAULT '',
  `player_name` varchar(20) NOT NULL DEFAULT '',
  `description` varchar(100) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of guilds_history
-- ----------------------------
INSERT INTO `guilds_history` VALUES ('1', '14', '2014/12/16 19:29:10', 'Nadaila', 'Nadaila criou a guild.');

-- ----------------------------
-- Table structure for guilds_member
-- ----------------------------
DROP TABLE IF EXISTS `guilds_member`;
CREATE TABLE `guilds_member` (
  `guild_id` int(11) NOT NULL DEFAULT '0',
  `player_id` int(11) NOT NULL DEFAULT '0',
  `player_name` varchar(20) NOT NULL DEFAULT '',
  `permission` varchar(20) NOT NULL DEFAULT '0, 0, 0, 0',
  `selfintro` varchar(100) NOT NULL DEFAULT '',
  `contribution_points` int(10) NOT NULL DEFAULT '0',
  `access` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`player_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of guilds_member
-- ----------------------------
INSERT INTO `guilds_member` VALUES ('1', '109', 'カロンネ', '1, 1, 1, 1', 'Mensagem 1', '0', '1');
INSERT INTO `guilds_member` VALUES ('2', '110', '나무', '1, 1, 1, 1', 'Mensagem 2', '0', '1');
INSERT INTO `guilds_member` VALUES ('14', '115', 'Nadaila', '1, 1, 1, 1', '', '0', '1');

-- ----------------------------
-- Table structure for guilds_warehouse
-- ----------------------------
DROP TABLE IF EXISTS `guilds_warehouse`;
CREATE TABLE `guilds_warehouse` (
  `guild_id` int(11) NOT NULL DEFAULT '0',
  `item_id` int(11) NOT NULL DEFAULT '0',
  `item_unique_id` varchar(255) NOT NULL DEFAULT '',
  `item_count` int(11) NOT NULL DEFAULT '0',
  `warehouse_slot` int(11) NOT NULL DEFAULT '0',
  `item_level` int(11) NOT NULL DEFAULT '0',
  `item_element` int(11) NOT NULL DEFAULT '0',
  `refine_element` int(11) NOT NULL DEFAULT '0',
  `durability` int(11) NOT NULL DEFAULT '0',
  `slots` varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (`guild_id`,`item_unique_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of guilds_warehouse
-- ----------------------------

-- ----------------------------
-- Table structure for items
-- ----------------------------
DROP TABLE IF EXISTS `items`;
CREATE TABLE `items` (
  `id` int(11) NOT NULL,
  `version` varchar(10) NOT NULL,
  `name` varchar(25) DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL,
  `handed` int(11) NOT NULL DEFAULT '0',
  `durability` int(11) NOT NULL,
  `animation` int(11) NOT NULL,
  `rare` int(11) NOT NULL,
  `attack_range` int(11) NOT NULL,
  `type` int(11) NOT NULL,
  `level` int(11) NOT NULL DEFAULT '1',
  `hp` int(11) NOT NULL DEFAULT '0',
  `mp` int(11) NOT NULL DEFAULT '0',
  `sp` int(11) NOT NULL DEFAULT '0',
  `regen_hp` int(11) NOT NULL,
  `regen_mp` int(11) NOT NULL,
  `strenght` int(11) NOT NULL,
  `dexterity` int(11) NOT NULL,
  `agility` int(11) NOT NULL,
  `vitality` int(11) NOT NULL,
  `intelligence` int(11) NOT NULL,
  `mind` int(11) NOT NULL,
  `critical_rate` int(11) NOT NULL,
  `critical_damage` int(11) NOT NULL,
  `spell_critical_rate` int(11) NOT NULL,
  `spell_critical_damage` int(11) NOT NULL,
  `healing_power` int(11) NOT NULL,
  `attack` int(11) NOT NULL,
  `accuracy` int(11) NOT NULL,
  `defense` int(11) NOT NULL,
  `evasion` int(11) NOT NULL,
  `block` int(11) NOT NULL,
  `magic_attack` int(11) NOT NULL,
  `magic_accuracy` int(11) NOT NULL,
  `magic_defense` int(11) NOT NULL,
  `magic_resist` int(11) NOT NULL,
  `damage_suppression` int(11) NOT NULL,
  `additional_damage` int(11) NOT NULL,
  `enmity` int(11) NOT NULL,
  `attack_speed` int(11) NOT NULL,
  `cast_speed` int(11) NOT NULL,
  `attribute_fire` int(11) NOT NULL,
  `attribute_water` int(11) NOT NULL,
  `attribute_earth` int(11) NOT NULL,
  `attribute_wind` int(11) NOT NULL,
  `resist_stun` int(11) NOT NULL,
  `resist_silence` int(11) NOT NULL,
  `resist_paralysis` int(11) NOT NULL,
  `resist_critical_rate` int(11) NOT NULL,
  `resist_critical_damage` int(11) NOT NULL,
  `resist_spell_critical_rate` int(11) NOT NULL,
  `resist_spell_critical_damage` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of items
-- ----------------------------

-- ----------------------------
-- Table structure for languages
-- ----------------------------
DROP TABLE IF EXISTS `languages`;
CREATE TABLE `languages` (
  `id` int(11) NOT NULL DEFAULT '0',
  `name` varchar(20) NOT NULL DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of languages
-- ----------------------------
INSERT INTO `languages` VALUES ('1', 'English');
INSERT INTO `languages` VALUES ('2', 'Portuguese');
INSERT INTO `languages` VALUES ('3', 'Japanese');
INSERT INTO `languages` VALUES ('4', 'Spanish');

-- ----------------------------
-- Table structure for old_names
-- ----------------------------
DROP TABLE IF EXISTS `old_names`;
CREATE TABLE `old_names` (
  `id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `player_id` int(11) NOT NULL,
  `old_name` varchar(50) NOT NULL,
  `new_name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of old_names
-- ----------------------------

-- ----------------------------
-- Table structure for server_variable
-- ----------------------------
DROP TABLE IF EXISTS `server_variable`;
CREATE TABLE `server_variable` (
  `key` varchar(25) NOT NULL,
  `value` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of server_variable
-- ----------------------------
