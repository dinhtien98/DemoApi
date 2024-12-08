CREATE TABLE `USER` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `USERNAME` varchar(20) NOT NULL,
  `PASSWORD` varchar(100) NOT NULL,
  `FULLNAME` varchar(100) DEFAULT NULL,
  `EMAIL` varchar(100) DEFAULT NULL,
  `FIRSTLOGIN` int DEFAULT NULL COMMENT '0: not yet login\\n1: logined',
  `INDATE` varchar(8) DEFAULT NULL,
  `OUTDATE` varchar(8) DEFAULT NULL,
  `FAILCOUNT` int DEFAULT NULL COMMENT 'count times loging fail, if loging fail 5 time lock account',
  `ISLOCKED` int NOT NULL DEFAULT '0' COMMENT '0: no lock, 1: locked',
  `AVATAR` varchar(500) DEFAULT NULL COMMENT 'link avata image',
  `LASTLOGIN` datetime DEFAULT NULL,
  `CREATEDTIME` datetime DEFAULT NULL,
  `CREATEDBY` varchar(20) DEFAULT NULL,
  `UPDATEDTIME` datetime DEFAULT NULL,
  `UPDATEDBY` varchar(20) DEFAULT NULL,
  `DELETEDBY` varchar(20) DEFAULT NULL,
  `DELETEDFLAG` int NOT NULL DEFAULT '0',
  `DELETEDTIME` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='User table';
