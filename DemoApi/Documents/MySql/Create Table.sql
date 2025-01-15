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

CREATE TABLE `PAGE` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `CODE` VARCHAR(10) DEFAULT NULL,
  `NAME` VARCHAR(100) DEFAULT NULL,
  `PARENTCODE` VARCHAR(10) DEFAULT NULL,
  `LEVEL` INT DEFAULT NULL,
  `URL` VARCHAR(500) DEFAULT NULL,
  `HIDDEN` INT DEFAULT NULL,
  `ICON` VARCHAR(50) DEFAULT NULL,
  `SORT` INT DEFAULT NULL,
  `CREATEDTIME` DATETIME DEFAULT NULL,
  `CREATEDBY` VARCHAR(16) DEFAULT NULL,
  `UPDATEDTIME` DATETIME DEFAULT NULL,
  `UPDATEDBY` VARCHAR(16) DEFAULT NULL,
  `DELETEDBY` VARCHAR(16) DEFAULT NULL,
  `DELETEDFLAG` INT NOT NULL DEFAULT '0',
  `DELETEDTIME` DATETIME DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_0900_AI_CI;

CREATE TABLE `ROLE` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `CODE` varchar(10) DEFAULT NULL,
  `NAME` varchar(100) DEFAULT NULL COMMENT 'role name',
  `CREATEDTIME` datetime DEFAULT NULL,
  `CREATEDBY` varchar(16) DEFAULT NULL,
  `UPDATEDTIME` datetime DEFAULT NULL,
  `UPDATEDBY` varchar(16) DEFAULT NULL,
  `DELETEDBY` varchar(16) DEFAULT NULL,
  `DELETEDFLAG` int NOT NULL DEFAULT '0',
  `DELETEDTIME` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `PAGE_ROLE` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `PAGECODE` varchar(10) DEFAULT NULL,
  `ROLECODE` varchar(10) DEFAULT NULL,
  `CREATEDTIME` datetime DEFAULT NULL,
  `CREATEDBY` varchar(16) DEFAULT NULL,
  `UPDATEDTIME` datetime DEFAULT NULL,
  `UPDATEDBY` varchar(16) DEFAULT NULL,
  `DELETEDBY` varchar(16) DEFAULT NULL,
  `DELETEDFLAG` int NOT NULL DEFAULT '0',
  `DELETEDTIME` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='relationship between page and role';


CREATE TABLE `USER_ROLE` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `USERID` int NOT NULL,
  `ROLECODE` varchar(10) DEFAULT NULL,
  `CREATEDTIME` datetime DEFAULT NULL,
  `CREATEDBY` varchar(16) DEFAULT NULL,
  `UPDATEDTIME` datetime DEFAULT NULL,
  `UPDATEDBY` varchar(16) DEFAULT NULL,
  `DELETEDBY` varchar(16) DEFAULT NULL,
  `DELETEDFLAG` int NOT NULL DEFAULT '0',
  `DELETEDTIME` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDBD DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='relationship between user and role';

CREATE TABLE `AUTH_ACTION` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `NAME` varchar(100) DEFAULT NULL,
  `ACTIONCODE` varchar(10) DEFAULT NULL,
  `CREATEDTIME` datetime DEFAULT NULL,
  `CREATEDBY` varchar(16) DEFAULT NULL,
  `UPDATEDTIME` datetime DEFAULT NULL,
  `UPDATEDBY` varchar(16) DEFAULT NULL,
  `DELETEDBY` varchar(16) DEFAULT NULL,
  `DELETEDFLAG` int NOT NULL DEFAULT '0',
  `DELETEDTIME` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `AUTH_PAGE_ACTION` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `PAGECODE` varchar(10) DEFAULT NULL,
  `ACTIONCODE` varchar(10) DEFAULT NULL,
  `CREATEDTIME` datetime DEFAULT NULL,
  `CREATEDBY` varchar(16) DEFAULT NULL,
  `UPDATEDTIME` datetime DEFAULT NULL,
  `UPDATEDBY` varchar(16) DEFAULT NULL,
  `DELETEDBY` varchar(16) DEFAULT NULL,
  `DELETEDFLAG` int NOT NULL DEFAULT '0',
  `DELETEDTIME` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='relationship between page and action';


CREATE TABLE `AUTH_PAGE_ACTION_ROLE` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `PAGECODE` varchar(10) DEFAULT NULL,
  `ACTIONCODE` varchar(10) DEFAULT NULL,
  `ROLECODE` varchar(10) DEFAULT NULL,
  `CREATEDTIME` datetime DEFAULT NULL,
  `CREATEDBY` varchar(16) DEFAULT NULL,
  `UPDATEDTIME` datetime DEFAULT NULL,
  `UPDATEDBY` varchar(16) DEFAULT NULL,
  `DELETEDBY` varchar(16) DEFAULT NULL,
  `DELETEDFLAG` int NOT NULL DEFAULT '0',
  `DELETEDTIME` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `CUSTOMER` (
	`ID` INT NOT NULL AUTO_INCREMENT,
    `USERNAME` VARCHAR(20) NOT NULL,
    `PASSWORD` VARCHAR(100) NOT NULL,
    `FULLNAME` VARCHAR(100) DEFAULT NULL,
    `EMAIL` VARCHAR(100) DEFAULT NULL,
    `FIRSTLOGIN` VARCHAR(20) DEFAULT NULL,
    `INDATE` VARCHAR(20) DEFAULT NULL,
    `OUTDATE` VARCHAR(20) DEFAULT NULL,
    `FAILCOUNT` INT NOT NULL DEFAULT '0',
    `ISLOCKED` INT NOT NULL DEFAULT '0',
    `TOTAL` DECIMAL(15,2) NOT NULL DEFAULT '0', 
    `LEVEL` INT NOT NULL DEFAULT '1',
    `DISCOUNT` INT NOT NULL DEFAULT '0',
    `CREATEDTIME` DATETIME DEFAULT NULL, 
    `UPDATEDTIME` DATETIME DEFAULT NULL,
    `DELETEDTIME` DATETIME DEFAULT NULL,
    `DELETEDFLAG` INT NOT NULL DEFAULT '0',
    PRIMARY KEY (`ID`)
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_0900_AI_CI;

CREATE TABLE `ORDERS` (
	`ID` INT NOT NULL AUTO_INCREMENT,
    `USERID` INT NOT NULL,
    `SHIPPINGADDRESS` VARCHAR(100) DEFAULT NULL,
    `TOTAL` DECIMAL(15,2) NOT NULL DEFAULT '0',
    `STATUS` INT NOT NULL DEFAULT '0',
    `PAYMENTMETHOD` VARCHAR(20) DEFAULT NULL,
    `ORDEREDTIME` DATETIME DEFAULT NULL,
    `PAYMENTEDTIME` DATETIME DEFAULT NULL,
    PRIMARY KEY (`ID`)
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_0900_AI_CI;

CREATE TABLE `ORDERDETAIL` (
	`ID` INT NOT NULL AUTO_INCREMENT,
    `ORDERID` INT NOT NULL,
    `PRODUCTID` INT NOT NULL,
    `QUANTITY` INT DEFAULT '0',
    `PRICE` DECIMAL(10,2) NOT NULL DEFAULT '0',
    `TOTAL` DECIMAL(15,2) NOT NULL DEFAULT '0',
    `CREATEDTIME` DATETIME DEFAULT NULL,
    PRIMARY KEY (`ID`)
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_0900_AI_CI;