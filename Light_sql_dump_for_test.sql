-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: fabryka
-- ------------------------------------------------------
-- Server version	8.0.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `czesc`
--

DROP TABLE IF EXISTS `czesc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `czesc` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Nazwa` varchar(45) DEFAULT NULL,
  `Ilosc` int DEFAULT NULL,
  `Cena` double DEFAULT NULL,
  `Komentarz` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `czesc`
--

LOCK TABLES `czesc` WRITE;
/*!40000 ALTER TABLE `czesc` DISABLE KEYS */;
INSERT INTO `czesc` VALUES (1,'Opona_15',0,120,'XD'),(2,'Felga_15',5,120,NULL),(3,'Sruby_do_kol',0,3,NULL),(4,'Sruby_do_kol',1000,3,NULL),(5,'Drzwi',300,1200,NULL),(6,'Karoseria',100,20000,NULL),(7,'Wahacze',240,1000,NULL),(8,'Amortyzatory',100,1000,NULL),(9,'Skrzynia biegów',100,10000,NULL),(10,'Silnik 2.0',100,15000,NULL),(12,'Przeguby',200,500,NULL),(13,'Kierownica',200,500,NULL),(14,'Kokpit',200,2500,NULL),(15,'Przyciski',100,1000,NULL),(16,'Fotele',100,1000,NULL),(17,'dssd',2,1,NULL),(18,'Nazwa podzespołu: ',0,0,'Komentarz do podzespołu: 12'),(19,'Nazwa podzespołu: ',0,0,'Komentarz do podzespołu: 12'),(20,'Nazwa podzespołu: ',0,0,'Komentarz do podzespołu: 12'),(21,'Nazwa podzespołu: ',0,0,'Komentarz do podzespołu: 12'),(22,'Nazwa podzespołu: ',0,0,'Komentarz do podzespołu: 12'),(23,'Nazwa podzespołu: adasdas',0,0,'Komentarz do podzespołu: 12312');
/*!40000 ALTER TABLE `czesc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kierownik_produkcji`
--

DROP TABLE IF EXISTS `kierownik_produkcji`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kierownik_produkcji` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Imie` varchar(45) DEFAULT NULL,
  `Nazwisko` varchar(45) DEFAULT NULL,
  `Haslo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kierownik_produkcji`
--

LOCK TABLES `kierownik_produkcji` WRITE;
/*!40000 ALTER TABLE `kierownik_produkcji` DISABLE KEYS */;
INSERT INTO `kierownik_produkcji` VALUES (1,'Przemo','Kocur',' Sposob');
/*!40000 ALTER TABLE `kierownik_produkcji` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `podzespol`
--

DROP TABLE IF EXISTS `podzespol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `podzespol` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Nazwa` varchar(45) DEFAULT NULL,
  `Ilosc` int DEFAULT NULL,
  `Podzespolcol` varchar(45) DEFAULT NULL,
  `Komentarz` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `podzespol`
--

LOCK TABLES `podzespol` WRITE;
/*!40000 ALTER TABLE `podzespol` DISABLE KEYS */;
INSERT INTO `podzespol` VALUES (1,'Kolo',0,NULL,NULL),(2,'Nadwozie_Polonez',20,NULL,NULL),(3,'Podwozie_Polonez',0,NULL,NULL),(4,'Naped_Polonez',0,NULL,NULL),(5,'Wnetrze',0,NULL,NULL),(6,'Nazwa podzespołu: zx',0,NULL,'Komentarz do podzespołu: zx'),(8,'ewrw',0,NULL,'21312');
/*!40000 ALTER TABLE `podzespol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `podzespol_has_czesc`
--

DROP TABLE IF EXISTS `podzespol_has_czesc`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `podzespol_has_czesc` (
  `Podzespol_ID` int NOT NULL,
  `Czesc_ID` int NOT NULL,
  `Ilosc` int DEFAULT NULL,
  PRIMARY KEY (`Podzespol_ID`,`Czesc_ID`),
  KEY `fk_Podzespol_has_Czesc_Czesc1_idx` (`Czesc_ID`),
  KEY `fk_Podzespol_has_Czesc_Podzespol1_idx` (`Podzespol_ID`),
  CONSTRAINT `fk_Podzespol_has_Czesc_Czesc1` FOREIGN KEY (`Czesc_ID`) REFERENCES `czesc` (`ID`),
  CONSTRAINT `fk_Podzespol_has_Czesc_Podzespol1` FOREIGN KEY (`Podzespol_ID`) REFERENCES `podzespol` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `podzespol_has_czesc`
--

LOCK TABLES `podzespol_has_czesc` WRITE;
/*!40000 ALTER TABLE `podzespol_has_czesc` DISABLE KEYS */;
INSERT INTO `podzespol_has_czesc` VALUES (1,2,1),(1,3,5),(2,5,4),(2,6,1),(3,7,4),(3,8,4),(4,9,1),(4,10,1),(4,12,1),(5,13,1),(5,14,1),(5,15,10),(5,16,1);
/*!40000 ALTER TABLE `podzespol_has_czesc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projektant`
--

DROP TABLE IF EXISTS `projektant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projektant` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Imie` varchar(45) DEFAULT NULL,
  `Nazwisko` varchar(45) DEFAULT NULL,
  `Haslo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projektant`
--

LOCK TABLES `projektant` WRITE;
/*!40000 ALTER TABLE `projektant` DISABLE KEYS */;
INSERT INTO `projektant` VALUES (1,'Michal','Aniol','zaq12');
/*!40000 ALTER TABLE `projektant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `samochod`
--

DROP TABLE IF EXISTS `samochod`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `samochod` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Nazwa_Modelu` varchar(45) DEFAULT NULL,
  `Zapotrzebowanie` int DEFAULT NULL,
  `Cena` double DEFAULT NULL,
  `Komentarz` text,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `samochod`
--

LOCK TABLES `samochod` WRITE;
/*!40000 ALTER TABLE `samochod` DISABLE KEYS */;
INSERT INTO `samochod` VALUES (1,'Polonez',10,120000,NULL);
/*!40000 ALTER TABLE `samochod` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `samochod_has_podzespol`
--

DROP TABLE IF EXISTS `samochod_has_podzespol`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `samochod_has_podzespol` (
  `Samochod_ID` int NOT NULL,
  `Podzespol_ID` int NOT NULL,
  `Ilosc` int DEFAULT NULL,
  PRIMARY KEY (`Samochod_ID`,`Podzespol_ID`),
  KEY `fk_Samochod_has_Podzespol_Podzespol1_idx` (`Podzespol_ID`),
  KEY `fk_Samochod_has_Podzespol_Samochod1_idx` (`Samochod_ID`),
  CONSTRAINT `fk_Samochod_has_Podzespol_Podzespol1` FOREIGN KEY (`Podzespol_ID`) REFERENCES `podzespol` (`ID`),
  CONSTRAINT `fk_Samochod_has_Podzespol_Samochod1` FOREIGN KEY (`Samochod_ID`) REFERENCES `samochod` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `samochod_has_podzespol`
--

LOCK TABLES `samochod_has_podzespol` WRITE;
/*!40000 ALTER TABLE `samochod_has_podzespol` DISABLE KEYS */;
INSERT INTO `samochod_has_podzespol` VALUES (1,1,2),(1,2,1),(1,3,1),(1,4,1),(1,5,1);
/*!40000 ALTER TABLE `samochod_has_podzespol` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `zarzadca_magazynu`
--

DROP TABLE IF EXISTS `zarzadca_magazynu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `zarzadca_magazynu` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Imie` varchar(45) DEFAULT NULL,
  `Nazwisko` varchar(45) DEFAULT NULL,
  `Haslo` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `zarzadca_magazynu`
--

LOCK TABLES `zarzadca_magazynu` WRITE;
/*!40000 ALTER TABLE `zarzadca_magazynu` DISABLE KEYS */;
INSERT INTO `zarzadca_magazynu` VALUES (1,'Andrzej','Poniedzielski','zaqwsx');
/*!40000 ALTER TABLE `zarzadca_magazynu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-27 15:44:38
