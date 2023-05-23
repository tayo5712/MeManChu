-- MySQL dump 10.13  Distrib 8.0.32, for Linux (x86_64)
--
-- Host: localhost    Database: unityInfo
-- ------------------------------------------------------
-- Server version	8.0.32-0ubuntu0.20.04.2

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `unityInfo`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `unityInfo` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `unityInfo`;

--
-- Table structure for table `ranks`
--

DROP TABLE IF EXISTS `ranks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ranks` (
  `no` int NOT NULL AUTO_INCREMENT,
  `id` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `map` varchar(45) NOT NULL,
  `score` int NOT NULL DEFAULT '0',
  `time` time NOT NULL,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`no`),
  KEY `rank_id to user_id_idx` (`id`),
  CONSTRAINT `rank_id to user_id` FOREIGN KEY (`id`) REFERENCES `user` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=150 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ranks`
--

LOCK TABLES `ranks` WRITE;
/*!40000 ALTER TABLE `ranks` DISABLE KEYS */;
INSERT INTO `ranks` VALUES (0,'mb5ss95','moon','ssafyRun',0,'00:02:57','2023-03-28 05:59:35'),(1,'mb5ss95','moon','skyStair',0,'00:01:10','2023-03-28 05:59:57'),(2,'mb5ss95','moon','FireMap',0,'00:01:38','2023-03-28 06:00:01'),(3,'mb5ss95','moon','HorrorHouse',0,'00:01:28','2023-03-28 06:00:05'),(4,'mb5ss95','moon','4',0,'00:00:03','2023-03-28 06:00:09'),(15,'t1','t1','ssafyRun',0,'00:00:05','2023-03-31 04:46:04'),(17,'t1','t1','skyStair',0,'00:00:25','2023-03-31 08:00:09'),(18,'t1','t1','skyStair',0,'00:00:27','2023-04-03 01:36:23'),(19,'t1','t1','skyStair',0,'00:00:15','2023-04-03 01:39:50'),(20,'t1','t1','skyStair',0,'00:00:15','2023-04-03 01:44:47'),(21,'t1','t1','skyStair',0,'00:00:15','2023-04-03 01:48:30'),(22,'t1','t1','skyStair',0,'00:00:15','2023-04-03 01:49:21'),(23,'t1','t1','skyStair',0,'00:00:18','2023-04-03 01:50:15'),(24,'t1','t1','skyStair',0,'00:00:15','2023-04-03 01:52:46'),(25,'t1','t1','skyStair',0,'00:00:30','2023-04-03 02:24:22'),(26,'ryu','kyu','ssafyRun',0,'00:03:57','2023-04-03 02:44:35'),(27,'t1','t1','skyStair',0,'00:00:57','2023-04-03 06:19:12'),(28,'t1','t1','ssafyRun',0,'00:05:53','2023-04-03 06:52:19'),(29,'jjm','jjm','skyStair',0,'00:00:40','2023-04-03 06:56:55'),(30,'jjm','jjm','skyStair',0,'00:00:40','2023-04-03 16:45:55'),(31,'jjm','jjm','skyStair',0,'00:00:49','2023-04-03 17:04:55'),(32,'jjm','jjm','skyStair',0,'00:00:38','2023-04-03 17:13:43'),(33,'jjm','jjm','skyStair',0,'00:00:07','2023-04-03 17:14:19'),(34,'jjm','jjm','skyStair',0,'00:00:07','2023-04-03 17:15:25'),(35,'jjm','jjm','skyStair',0,'00:00:07','2023-04-03 17:16:27'),(36,'t1','t1','skyStair',0,'00:00:07','2023-04-03 17:17:29'),(37,'t1','t1','ssafyRun',0,'00:11:34','2023-04-03 17:19:13'),(38,'jjm','jjm','skyStair',0,'00:00:00','2023-04-03 17:28:42'),(39,'t3','t3','skyStair',0,'00:00:54','2023-04-04 09:16:09'),(40,'jjm','jjm','skyStair',0,'00:00:18','2023-04-04 10:34:16'),(41,'t3','t3','FireMap',0,'00:00:55','2023-04-04 11:24:36'),(42,'jjm','jjm','skyStair',0,'00:00:26','2023-04-04 11:31:47'),(43,'jjm','jjm','skyStair',0,'00:00:55','2023-04-04 14:05:08'),(44,'jjm','jjm','skyStair',0,'00:00:36','2023-04-04 14:12:06'),(45,'jjm','jjm','skyStair',0,'00:00:03','2023-04-04 14:26:41'),(46,'jjm','jjm','skyStair',0,'00:00:30','2023-04-04 14:31:16'),(47,'t3','t3','skyStair',0,'00:00:17','2023-04-04 14:50:41'),(48,'jjm','jjm','skyStair',0,'00:00:15','2023-04-05 09:42:51'),(49,'jjm','jjm','skyStair',0,'00:00:08','2023-04-05 09:44:58'),(50,'t1','t1','skyStair',0,'00:00:48','2023-04-05 09:52:17'),(51,'t1','t1','skyStair',0,'00:00:45','2023-04-05 09:54:59'),(52,'t1','t1','skyStair',0,'00:00:11','2023-04-05 09:56:17'),(53,'jjm','jjm','skyStair',0,'00:00:34','2023-04-05 10:27:29'),(54,'jjm','jjm','skyStair',0,'00:00:32','2023-04-05 10:30:31'),(55,'jjm','jjm','skyStair',0,'00:00:25','2023-04-05 10:34:21'),(56,'jjm','jjm','skyStair',0,'00:00:32','2023-04-05 10:37:56'),(57,'jjm','jjm','skyStair',0,'00:00:56','2023-04-05 10:40:48'),(58,'jjm','jjm','skyStair',0,'00:00:16','2023-04-05 10:57:30'),(60,'t1','t1','HorrorHouse',0,'00:10:32','2023-04-05 11:28:29'),(61,'t1','t1','HorrorHouse',0,'00:01:44','2023-04-05 11:35:05'),(62,'t1','t1','HorrorHouse',0,'00:01:31','2023-04-05 11:36:43'),(63,'ryu','kyu','ssafyRun',0,'00:03:05','2023-04-05 11:41:19'),(64,'ryu','kyu','skyStair',0,'00:00:02','2023-04-05 11:43:04'),(65,'t1','t1','HorrorHouse',0,'00:01:58','2023-04-05 12:03:25'),(66,'jjm','jjm','skyStair',0,'00:00:41','2023-04-05 12:09:48'),(67,'jjm','jjm','ssafyRun',0,'00:13:47','2023-04-05 12:53:36'),(68,'jjm','jjm','skyStair',0,'00:00:51','2023-04-05 12:55:02'),(69,'jjm','jjm','skyStair',0,'00:00:27','2023-04-05 12:57:52'),(70,'jjm','jjm','skyStair',0,'00:00:34','2023-04-05 13:04:20'),(71,'t1','t1','skyStair',0,'00:00:33','2023-04-05 13:14:14'),(72,'jjm','jjm','skyStair',0,'00:00:35','2023-04-05 13:39:17'),(73,'jjm','jjm','skyStair',0,'00:00:31','2023-04-05 13:40:38'),(74,'jjm','jjm','skyStair',0,'00:00:47','2023-04-05 14:11:16'),(75,'test','test','HorrorHouse',0,'00:04:19','2023-04-05 15:39:23'),(76,'test','test','ssafyRun',0,'00:03:27','2023-04-05 15:44:01'),(77,'test','test','skyStair',0,'00:00:39','2023-04-05 15:50:13'),(78,'test','test','skyStair',0,'00:00:52','2023-04-05 15:59:36'),(79,'jjm','jjm','skyStair',0,'00:00:32','2023-04-05 16:01:54'),(80,'test','test','skyStair',0,'00:00:47','2023-04-05 16:02:10'),(81,'jjm','jjm','FireMap',0,'00:08:07','2023-04-05 16:21:12'),(82,'test','test','skyStair',0,'00:00:01','2023-04-06 08:55:17'),(83,'jjm','jjm','skyStair',0,'00:00:32','2023-04-06 09:10:31'),(84,'test','test','HorrorHouse',0,'00:02:51','2023-04-06 09:39:01'),(85,'test1','test1','skyStair',0,'00:00:38','2023-04-06 10:02:37'),(86,'t1','t1','HorrorHouse',0,'00:02:15','2023-04-06 10:44:55'),(87,'test1','test1','skyStair',0,'00:00:24','2023-04-06 10:45:28'),(88,'t1','t1','skyStair',0,'00:00:42','2023-04-06 11:01:52'),(89,'t1','t1','FireMap',0,'00:01:08','2023-04-06 11:03:41'),(90,'test1','test1','FireMap',0,'00:02:11','2023-04-06 11:10:15'),(91,'test1','test1','HorrorHouse',0,'00:05:04','2023-04-06 11:17:49'),(92,'good','Happy','FireMap',0,'00:01:35','2023-04-06 11:44:40'),(93,'test2','test2','ssafyRun',0,'00:10:09','2023-04-06 12:05:28'),(94,'test2','test2','FireMap',0,'00:07:10','2023-04-06 12:13:42'),(95,'test2','test2','skyStair',0,'00:00:37','2023-04-06 12:15:12'),(96,'gch04407','tayo','skyStair',0,'00:00:36','2023-04-06 13:10:43'),(97,'t1','t1','skyStair',0,'00:00:35','2023-04-06 14:11:26'),(98,'test5','test5','skyStair',0,'00:00:36','2023-04-06 14:20:23'),(99,'test5','test5','skyStair',0,'00:00:28','2023-04-06 14:22:53'),(100,'test10','test10','skyStair',0,'00:00:40','2023-04-06 14:23:52'),(101,'test10','test10','skyStair',0,'00:00:47','2023-04-06 14:26:00'),(102,'test5','test5','skyStair',0,'00:00:16','2023-04-06 14:28:56'),(103,'test5','test5','skyStair',0,'00:00:38','2023-04-06 14:30:20'),(104,'test10','test10','skyStair',0,'00:00:08','2023-04-06 14:40:05'),(105,'test10','test10','skyStair',0,'00:00:34','2023-04-06 15:05:24'),(106,'test5','test5','skyStair',0,'00:00:15','2023-04-06 15:10:51'),(107,'anska77@ssafy.com','남무','skyStair',0,'00:00:45','2023-04-06 15:12:48'),(108,'anska77@ssafy.com','남무','skyStair',0,'00:00:52','2023-04-06 15:20:22'),(109,'anska77@ssafy.com','남무','skyStair',0,'00:00:46','2023-04-06 15:22:14'),(110,'anska77@ssafy.com','남무','skyStair',0,'00:00:45','2023-04-06 15:23:50'),(111,'anska77@ssafy.com','남무','skyStair',0,'00:00:33','2023-04-06 15:25:07'),(112,'test10','test10','skyStair',0,'00:00:41','2023-04-06 15:26:26'),(113,'test10','test10','skyStair',0,'00:00:19','2023-04-06 15:26:56'),(114,'anska77@ssafy.com','남무','skyStair',0,'00:00:21','2023-04-06 15:27:27'),(115,'whehdgurt1','나는광주맨임','skyStair',0,'00:00:27','2023-04-06 15:40:34'),(116,'whehdgurt1','나는광주맨임','skyStair',0,'00:00:21','2023-04-06 15:50:37'),(117,'anska77@ssafy.com','남무','skyStair',0,'00:00:23','2023-04-06 15:51:05'),(118,'anska77@ssafy.com','남무','skyStair',0,'00:00:54','2023-04-06 15:55:30'),(119,'anska77@ssafy.com','남무','skyStair',0,'00:00:17','2023-04-06 16:01:52'),(120,'anska77@ssafy.com','남무','skyStair',0,'00:00:44','2023-04-06 16:15:01'),(121,'anska77@ssafy.com','남무','skyStair',0,'00:00:39','2023-04-06 16:21:36'),(122,'anska77@ssafy.com','남무','skyStair',0,'00:00:02','2023-04-06 16:30:02'),(123,'tpshy87@testmail.com','메타버스가뭐에요','HorrorHouse',0,'00:07:26','2023-04-06 16:36:05'),(124,'tpshy87@testmail.com','메타버스가뭐에요','FireMap',0,'00:10:31','2023-04-06 16:47:03'),(125,'anska77@ssafy.com','남무','skyStair',0,'00:00:57','2023-04-06 16:53:46'),(126,'jce0497','챈','skyStair',0,'00:00:33','2023-04-06 16:54:30'),(127,'anska77@ssafy.com','남무','skyStair',0,'00:00:48','2023-04-06 17:00:38'),(128,'anska77@ssafy.com','남무','skyStair',0,'00:00:19','2023-04-06 17:03:06'),(129,'test123','실코','skyStair',0,'00:00:31','2023-04-06 17:06:05'),(130,'anska77@ssafy.com','남무','skyStair',0,'00:00:06','2023-04-06 17:22:19'),(131,'good','Happy','skyStair',0,'00:00:05','2023-04-06 17:23:45'),(132,'anska77@ssafy.com','남무','skyStair',0,'00:00:05','2023-04-06 17:24:13'),(133,'anska77@ssafy.com','남무','skyStair',0,'00:00:56','2023-04-06 17:25:16'),(134,'good','Happy','HorrorHouse',0,'00:01:49','2023-04-06 17:27:16'),(135,'anska77@ssafy.com','남무','skyStair',0,'00:00:57','2023-04-06 17:28:56'),(136,'jjm1261','지요옹','skyStair',0,'00:00:52','2023-04-06 17:29:49'),(137,'anska77@ssafy.com','남무','skyStair',0,'00:00:04','2023-04-06 17:30:05'),(138,'dontknow','메타버스가뭐에요시즌2','skyStair',0,'00:00:43','2023-04-06 17:31:40'),(139,'good','Happy','ssafyRun',0,'00:03:17','2023-04-06 17:33:30'),(140,'kty3234','타요','skyStair',0,'00:00:26','2023-04-06 17:34:21'),(141,'dontknow','메타버스가뭐에요시즌2','skyStair',0,'00:00:41','2023-04-06 17:49:31'),(142,'mb5ss95','moon','HorrorHouse',0,'00:02:28','2023-04-06 20:53:53'),(143,'mb5ss95','moon','FireMap',0,'00:01:37','2023-04-06 20:55:55'),(144,'mb5ss95','moon','skyStair',0,'00:00:40','2023-04-06 20:57:37'),(145,'testt','testt','FireMap',0,'00:04:40','2023-04-06 21:32:30'),(146,'c210c210','Cute','skyStair',0,'00:00:58','2023-04-06 22:38:10'),(147,'test1234','테스터1234','HorrorHouse',0,'00:01:44','2023-04-06 23:29:42'),(148,'test1234','테스터1234','HorrorHouse',0,'00:01:42','2023-04-06 23:38:56'),(149,'test1234','테스터1234','HorrorHouse',0,'00:02:20','2023-04-06 23:48:59');
/*!40000 ALTER TABLE `ranks` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`unity`@`%`*/ /*!50003 TRIGGER `ranks_BEFORE_INSERT` BEFORE INSERT ON `ranks` FOR EACH ROW BEGIN

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `ranksd`
--

DROP TABLE IF EXISTS `ranksd`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ranksd` (
  `no` int NOT NULL AUTO_INCREMENT,
  `id` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `map` varchar(45) NOT NULL,
  `score` int NOT NULL DEFAULT '0',
  `time` time NOT NULL,
  `date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`no`),
  KEY `rank_id to user_id_idx` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ranksd`
--

LOCK TABLES `ranksd` WRITE;
/*!40000 ALTER TABLE `ranksd` DISABLE KEYS */;
/*!40000 ALTER TABLE `ranksd` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `ID` varchar(30) NOT NULL,
  `NAME` varchar(30) DEFAULT NULL,
  `PASS` varchar(30) DEFAULT NULL,
  `CHIDX` int DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('ab','abababab','abababab',0),('abcd','abcd','abcdabcd',0),('anska77@ssafy.com','남무','Handsome55!',0),('asdasd','asdasd','asdasdasd',0),('C210C210','Cute','qwerqwer',0),('consultant','insultant','insultant',0),('dontknow','메타버스가뭐에요시즌2','111122223333',0),('gch04407','tayo','tayo5712',0),('good','Happy','12345678',0),('host','host','hosthost',0),('jce0497','챈','testtest11!',0),('jjm','jjm','12341234',0),('jjm1261','지요옹','12341234',0),('kty3234','타요','tayo5712',0),('mb5ss95','moon','moonisbacon',0),('princess','공주','123456789',0),('qwerqwer','qwer1234','qwerqwer',0),('ryu','kyu','12345678',0),('ssafy','유경이에요','ssafyssafy',0),('ssafy1','ssafy1','ssafyisbacon',0),('ssafy2','ssafy2','ssafyisbacon',0),('ssafy3','ssafy3','ssafyisbacon',0),('ssafy4','ssafy4','ssafyisbacon',0),('ssafyjojo','왕자','123456789',0),('ssafywhehdgur','ssafyjo','123456789',0),('t1','t1','t',0),('t2','t2','t',0),('t3','t3','t',0),('t4','t4','t',0),('test','test','12345678',0),('test1','test1','12341234',0),('test10','test10','12341234',0),('test123','실코','testtest',0),('test1234','테스터1234','test5712',0),('test2','test2','testtest1!',0),('test5','test5','12341234',0),('testt','testt','test123!',0),('tpshy87@testmail.com','메타버스가뭐에요','z',0),('whehdgurt1','나는광주맨임','123456789',0),('yongsm','yongsm','12341234',0),('zizonBS','zizonBS','12341234',0),('zxcv','zxcv','zxcvzxcv',0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-07  0:26:52
