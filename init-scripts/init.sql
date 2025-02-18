CREATE TABLE `AUTH_USER` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `USERNAME` varchar(20) NOT NULL,
  `PASSWORD` varchar(100) NOT NULL,
  `FULLNAME` varchar(100) DEFAULT NULL,
  `EMAIL` varchar(100) DEFAULT NULL,
  `FIRSTLOGIN` int DEFAULT NULL COMMENT '0: not yet login\\n1: logined',
  `INDATE` varchar(20) DEFAULT NULL,
  `OUTDATE` varchar(20) DEFAULT NULL,
  `FAILCOUNT` int DEFAULT NULL COMMENT 'count times loging fail, if loging fail 5 time lock account',
  `ISLOCKED` int NOT NULL DEFAULT '0' COMMENT '0: no lock, 1: locked',
  `AVATAR` varchar(500) DEFAULT NULL COMMENT 'link avata image',
  `LASTLOGIN` varchar(20) DEFAULT NULL,
  `CREATEDTIME` datetime DEFAULT NULL,
  `CREATEDBY` varchar(20) DEFAULT NULL,
  `UPDATEDTIME` datetime DEFAULT NULL,
  `UPDATEDBY` varchar(20) DEFAULT NULL,
  `DELETEDBY` varchar(20) DEFAULT NULL,
  `DELETEDFLAG` int NOT NULL DEFAULT '0',
  `DELETEDTIME` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='User table';

CREATE TABLE `AUTH_PAGE` (
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

CREATE TABLE `AUTH_ROLE` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `CODE` varchar(50) DEFAULT NULL,
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

CREATE TABLE `AUTH_PAGE_ROLE` (
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


CREATE TABLE `AUTH_USER_ROLE` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `USERID` int NOT NULL,
  `ROLECODE` varchar(50) DEFAULT NULL,
  `CREATEDTIME` datetime DEFAULT NULL,
  `CREATEDBY` varchar(16) DEFAULT NULL,
  `UPDATEDTIME` datetime DEFAULT NULL,
  `UPDATEDBY` varchar(16) DEFAULT NULL,
  `DELETEDBY` varchar(16) DEFAULT NULL,
  `DELETEDFLAG` int NOT NULL DEFAULT '0',
  `DELETEDTIME` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='relationship between user and role';

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


CREATE TABLE `AUTH_ORDERS` (
	`ID` INT NOT NULL AUTO_INCREMENT,
    `USERID` INT NOT NULL,
    `SHIPPINGADDRESS` VARCHAR(100) DEFAULT NULL,
    `TOTAL` DECIMAL(15,2) NOT NULL DEFAULT '0',
    `STATUS` INT NOT NULL DEFAULT '0',
    `PAYMENTMETHOD` VARCHAR(20) DEFAULT NULL,
    `PAYMENTEDTIME` DATETIME DEFAULT NULL,
    `PAYMENTEDBY` VARCHAR(10) DEFAULT NULL,
    `CREATEDTIME` DATETIME DEFAULT NULL,
    `CREATEDBY` VARCHAR(10) DEFAULT NULL,
    `UPDATEDTIME` DATETIME DEFAULT NULL,
    `UPDATEDBY` VARCHAR(10) DEFAULT NULL,
    `DELETEDTIME` DATETIME DEFAULT NULL,
    `DELETEDBY` VARCHAR(10) DEFAULT NULL,
    `DELETEDFLAG` INT NOT NULL DEFAULT '0',
    PRIMARY KEY (`ID`)
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_0900_AI_CI;

CREATE TABLE `AUTH_ORDERDETAIL` (
	`ID` INT NOT NULL AUTO_INCREMENT,
    `ORDERID` INT NOT NULL,
    `PRODUCTID` INT NOT NULL,
    `QUANTITY` INT DEFAULT '0',
    `PRICE` DECIMAL(10,2) NOT NULL DEFAULT '0',
    `TOTAL` DECIMAL(15,2) NOT NULL DEFAULT '0',
    `CREATEDTIME` DATETIME DEFAULT NULL,
    `CREATEDBY` VARCHAR(10) DEFAULT NULL,
    `UPDATEDTIME` DATETIME DEFAULT NULL,
    `UPDATEDBY` VARCHAR(10) DEFAULT NULL,
    `DELETEDTIME` DATETIME DEFAULT NULL,
    `DELETEDBY` VARCHAR(10) DEFAULT NULL,
    `DELETEDFLAG` INT NOT NULL DEFAULT '0',
    PRIMARY KEY (`ID`)
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_0900_AI_CI;

CREATE TABLE `AUTH_PRODUCT` (
	`ID` INT NOT NULL AUTO_INCREMENT,
    `PRODUCTNAME` VARCHAR(100) DEFAULT NULL,
    `DESCRIPTION` VARCHAR(200) DEFAULT NULL,
    `PRICE` DECIMAL(10,2) NOT NULL DEFAULT '0',
    `STOCKQUANTITY` INT NOT NULL DEFAULT '0',
    `CATEGORY` INT NOT NULL,
    `SUPPLIER` VARCHAR(50),
    `DISCOUNT` DECIMAL(10,2) NOT NULL DEFAULT '0',
    `CREATEDTIME` DATETIME DEFAULT NULL,
    `CREATEDBY` VARCHAR(10) DEFAULT NULL,
    `UPDATEDTIME` DATETIME DEFAULT NULL,
    `UPDATEDBY` VARCHAR(10) DEFAULT NULL,
    `DELETEDTIME` DATETIME DEFAULT NULL,
    `DELETEDBY` VARCHAR(10) DEFAULT NULL,
    `DELETEDFLAG` INT NOT NULL DEFAULT '0',
    PRIMARY KEY (`ID`)
) ENGINE=INNODB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_0900_AI_CI;

CREATE TABLE `AUTH_PRODUCT_IMAGE` (
    `ID` INT NOT NULL AUTO_INCREMENT,
    `IDPRODUCT` INT NOT NULL,
    `IMAGEURL` VARCHAR(255) NOT NULL,
    `CREATEDTIME` DATETIME DEFAULT NULL,
    `CREATEDBY` VARCHAR(10) DEFAULT NULL,
    `UPDATEDTIME` DATETIME DEFAULT NULL,
    `UPDATEDBY` VARCHAR(10) DEFAULT NULL,
    `DELETEDTIME` DATETIME DEFAULT NULL,
    `DELETEDBY` VARCHAR(10) DEFAULT NULL,
    `DELETEDFLAG` INT NOT NULL DEFAULT '0',
    PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=UTF8MB4 COLLATE=UTF8MB4_0900_AI_CI;

DELIMITER //
CREATE PROCEDURE sp_auth_user_insert(
    IN p_UserName VARCHAR(20),
    IN p_PassWord VARCHAR(100),
    IN p_FullName VARCHAR(100),
    IN p_Email VARCHAR(100),
    IN p_Avatar VARCHAR(500),
    IN p_CreatedBy VARCHAR(20),
    IN p_RoleCode JSON
)
BEGIN
    DECLARE v_UserID INT;

    -- Thêm user vào bảng AUTH_USER
    INSERT INTO AUTH_USER (
        USERNAME, PASSWORD, FULLNAME, EMAIL, AVATAR, CREATEDTIME, CREATEDBY
    ) VALUES (
        p_UserName, p_PassWord, p_FullName, p_Email, p_Avatar, NOW(), p_CreatedBy
    );

    -- Lấy ID của user vừa tạo
    SET v_UserID = LAST_INSERT_ID();

    -- Chèn danh sách role vào bảng AUTH_USER_ROLE từ JSON
    INSERT INTO AUTH_USER_ROLE (USERID, ROLECODE, CREATEDTIME, CREATEDBY)
    SELECT v_UserID, JSON_UNQUOTE(JSON_EXTRACT(Item, '$.Code')) AS ROLECODE, NOW(), p_CreatedBy
    FROM JSON_TABLE(p_RoleCode, '$[*]' COLUMNS (Item JSON PATH '$')) AS Item;

END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_auth_user_selectAll()
BEGIN
    SELECT 
        u.*, 
        COALESCE(
            CONCAT('[', GROUP_CONCAT(
                JSON_OBJECT('code', r.ROLECODE)
            ), ']'), 
            '[]'
        ) AS roleCode
    FROM AUTH_USER u
    LEFT JOIN AUTH_USER_ROLE r ON u.ID = r.USERID
    WHERE u.DELETEDFLAG = 0
    GROUP BY u.ID;
    
END //
DELIMITER ;


DELIMITER //
CREATE PROCEDURE sp_auth_user_selectByID(IN p_ID INT)
BEGIN
    SELECT 
        u.*, 
        COALESCE(
            CONCAT('[', GROUP_CONCAT(
                JSON_OBJECT('code', r.ROLECODE)
            ), ']'), 
            '[]'
        ) AS roleCode
    FROM AUTH_USER u
    LEFT JOIN AUTH_USER_ROLE r ON u.ID = r.USERID
    WHERE u.ID = p_ID AND u.DELETEDFLAG = 0
    GROUP BY u.ID;
    
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_auth_user_delete(IN p_ID INT, IN p_DeletedBy VARCHAR(20))
BEGIN
    -- Xóa mềm trong bảng AUTH_USER
    UPDATE AUTH_USER
    SET 
        DELETEDFLAG = 1,
        DELETEDTIME = NOW(),
        DELETEDBY = p_DeletedBy
    WHERE ID = p_ID;
    
    -- Xóa mềm trong bảng AUTH_USER_ROLE
    UPDATE AUTH_USER_ROLE
    SET 
        DELETEDFLAG = 1,
        DELETEDTIME = NOW(),
        DELETEDBY = p_DeletedBy
    WHERE USERID = p_ID;
    
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_auth_user_login_select(IN P_UserName VARCHAR(50))
BEGIN
    SELECT 
        u.ID,
        u.UserName,
        u.Password,
        u.FullName,
        u.Email,
        u.Avatar,
        u.IsLocked,
        u.FailCount,
        u.LastLogin,
        u.CreatedTime,
        u.CreatedBy,
        u.UpdatedTime,
        u.UpdatedBy,
        u.DeletedFlag,
        (SELECT JSON_ARRAYAGG(JSON_OBJECT('code', r.ROLECODE)) 
             FROM AUTH_USER_ROLE r
             WHERE r.USERID = u.ID AND r.DELETEDFLAG = 0) AS RoleCode
    FROM AUTH_USER u
    WHERE u.UserName = P_UserName 
    AND u.DeletedFlag = 0;
END //
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_user_login_failcount_update(
    IN p_ID INT
)
BEGIN
    -- Tăng số lần đăng nhập thất bại và khóa tài khoản nếu quá 5 lần
    UPDATE AUTH_USER
    SET 
        FAILCOUNT = FAILCOUNT + 1,
        ISLOCKED = CASE WHEN FAILCOUNT + 1 >= 5 THEN 1 ELSE ISLOCKED END
    WHERE ID = p_ID AND ISLOCKED = 0;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_user_login_failcount_reset(
    IN p_ID INT
)
BEGIN
    -- Reset số lần đăng nhập thất bại và mở khóa tài khoản
    UPDATE AUTH_USER
    SET 
        FAILCOUNT = 0,
        ISLOCKED = 0
    WHERE ID = p_ID;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_user_update(
    IN p_id INT,
    IN p_FullName VARCHAR(255),
    IN p_Email VARCHAR(255),
    IN p_FirstLogin INT,
    IN p_LastLogin VARCHAR(255),
    IN p_IsLocked INT,
    IN p_InDate VARCHAR(255),
    IN p_OutDate VARCHAR(255),
    IN p_Avatar VARCHAR(500),
    IN p_UpdatedBy INT,
    IN p_RoleCode JSON
)
BEGIN
    -- Cập nhật thông tin user trong AUTH_USER
    UPDATE AUTH_USER
    SET 
        FullName = p_FullName,
        Email = p_Email,
        FirstLogin = p_FirstLogin,
        LastLogin = p_LastLogin,
        IsLocked = p_IsLocked,
        InDate = p_InDate,
        OutDate = p_OutDate,
        Avatar = p_Avatar,
        UpdatedBy = p_UpdatedBy,
        UpdatedTime = NOW()
    WHERE ID = p_id;

    -- Xóa hết vai trò của user trong AUTH_USER_ROLE
    DELETE FROM AUTH_USER_ROLE WHERE UserID = p_id;

    -- Thêm lại danh sách role mới từ JSON
    INSERT INTO AUTH_USER_ROLE (USERID, ROLECODE, CREATEDTIME, CREATEDBY)
    SELECT p_id, JSON_UNQUOTE(JSON_EXTRACT(Item, '$.Code')) AS ROLECODE, NOW(), p_UpdatedBy
    FROM JSON_TABLE(p_RoleCode, '$[*]' COLUMNS (Item JSON PATH '$')) AS Item;

END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_role_insert(
    IN p_Code VARCHAR(50),
    IN p_Name VARCHAR(100),
    IN p_CreatedBy VARCHAR(16),
    IN p_PageCode JSON,
    IN p_ActionCode JSON
)
BEGIN
    DECLARE v_RoleID INT;

    -- Thêm mới role vào bảng AUTH_ROLE
    INSERT INTO AUTH_ROLE (CODE, NAME, CREATEDTIME, CREATEDBY)
    VALUES (p_Code, p_Name, NOW(), p_CreatedBy);

    -- Lấy ID của role vừa thêm
    SET v_RoleID = LAST_INSERT_ID();

    -- Chèn dữ liệu vào bảng AUTH_PAGE_ACTION_ROLE bằng cách kết hợp PAGECODE và ACTIONCODE
    INSERT INTO AUTH_PAGE_ACTION_ROLE (PAGECODE, ACTIONCODE, ROLECODE, CREATEDTIME, CREATEDBY)
    SELECT 
        JSON_UNQUOTE(JSON_EXTRACT(pc.Item, '$.Code')) AS PAGECODE,
        JSON_UNQUOTE(JSON_EXTRACT(ac.Item, '$.Code')) AS ACTIONCODE,
        p_Code, 
        NOW(),
        p_CreatedBy
    FROM 
        JSON_TABLE(p_PageCode, '$[*]' COLUMNS (Item JSON PATH '$')) AS pc
    CROSS JOIN 
        JSON_TABLE(p_ActionCode, '$[*]' COLUMNS (Item JSON PATH '$')) AS ac;

END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_role_selectAll()
BEGIN
    SELECT 
        r.*, 
        COALESCE(
            CONCAT('[', GROUP_CONCAT(DISTINCT JSON_OBJECT('code', p.PAGECODE)), ']'), 
            '[]'
        ) AS pageCode,
        COALESCE(
            CONCAT('[', GROUP_CONCAT(DISTINCT JSON_OBJECT('code', p.ACTIONCODE)), ']'), 
            '[]'
        ) AS actionCode
    FROM AUTH_ROLE r
    LEFT JOIN AUTH_PAGE_ACTION_ROLE p ON r.CODE = p.ROLECODE
    WHERE r.DELETEDFLAG = 0
    GROUP BY r.ID;
    
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_role_selectByID(IN p_ID INT)
BEGIN
    SELECT 
        r.*, 
        COALESCE(
            CONCAT('[', GROUP_CONCAT(DISTINCT JSON_OBJECT('code', p.PAGECODE)), ']'), 
            '[]'
        ) AS pageCode,
        COALESCE(
            CONCAT('[', GROUP_CONCAT(DISTINCT JSON_OBJECT('code', p.ACTIONCODE)), ']'), 
            '[]'
        ) AS actionCode
    FROM AUTH_ROLE r
    LEFT JOIN AUTH_PAGE_ACTION_ROLE p ON r.CODE = p.ROLECODE
    WHERE r.DELETEDFLAG = 0 AND r.ID = p_ID
    GROUP BY r.ID;
    
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_role_delete(
    IN p_ID INT,
    IN p_DeletedBy VARCHAR(16)
)
BEGIN
    DECLARE v_RoleCode VARCHAR(50);

    -- Lấy ROLECODE của role cần xóa
    SELECT CODE INTO v_RoleCode FROM AUTH_ROLE WHERE ID = p_ID;

    -- Nếu role không tồn tại thì thoát
    IF v_RoleCode IS NULL THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Role not found';
    END IF;

    -- Xóa mềm tất cả các quyền liên quan đến role trong AUTH_PAGE_ACTION_ROLE
    UPDATE AUTH_PAGE_ACTION_ROLE 
    SET 
        DELETEDFLAG = 1,
        DELETEDBY = p_DeletedBy,
        DELETEDTIME = NOW()
    WHERE ROLECODE = v_RoleCode;

    -- Xóa mềm role trong AUTH_ROLE
    UPDATE AUTH_ROLE
    SET 
        DELETEDFLAG = 1,
        DELETEDBY = p_DeletedBy,
        DELETEDTIME = NOW()
    WHERE ID = p_ID;
    
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE sp_auth_role_update(
    IN p_ID INT,
    IN p_Code VARCHAR(50),
    IN p_Name VARCHAR(100),
    IN p_UpdatedBy VARCHAR(16),
    IN p_PageCode JSON,
    IN p_ActionCode JSON
)
BEGIN
    DECLARE v_RoleCode VARCHAR(50);

    -- Kiểm tra role có tồn tại hay không
    SELECT CODE INTO v_RoleCode FROM AUTH_ROLE WHERE ID = p_ID;

    IF v_RoleCode IS NULL THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Role not found';
    END IF;

    -- Cập nhật thông tin role trong AUTH_ROLE
    UPDATE AUTH_ROLE
    SET 
        CODE = p_Code,
        NAME = p_Name,
        UPDATEDBY = p_UpdatedBy,
        UPDATEDTIME = NOW()
    WHERE ID = p_ID;

     -- Xóa tất cả các quyền liên quan đến role trong AUTH_PAGE_ACTION_ROLE
    DELETE FROM AUTH_PAGE_ACTION_ROLE WHERE ROLECODE = v_RoleCode;

    -- Thêm lại danh sách pageCode và actionCode mới từ JSON vào AUTH_PAGE_ACTION_ROLE
    INSERT INTO AUTH_PAGE_ACTION_ROLE (PAGECODE, ACTIONCODE, ROLECODE, CREATEDTIME, CREATEDBY)
    SELECT 
        JSON_UNQUOTE(JSON_EXTRACT(p.PageItem, '$.Code')) AS PAGECODE,
        JSON_UNQUOTE(JSON_EXTRACT(a.ActionItem, '$.Code')) AS ACTIONCODE,
        p_Code,
        NOW(),
        p_UpdatedBy
    FROM JSON_TABLE(p_PageCode, '$[*]' COLUMNS (PageItem JSON PATH '$')) AS p
    JOIN JSON_TABLE(p_ActionCode, '$[*]' COLUMNS (ActionItem JSON PATH '$')) AS a;

END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_action_insert(
    IN p_Name VARCHAR(100),
    IN p_ActionCode VARCHAR(10),
    IN p_CreatedBy VARCHAR(16)
)
BEGIN
    INSERT INTO AUTH_ACTION (NAME, ACTIONCODE, CREATEDTIME, CREATEDBY)
    VALUES (p_Name, p_ActionCode, NOW(), p_CreatedBy);
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE sp_auth_action_delete(
    IN p_ID INT,
    IN p_DeletedBy VARCHAR(16)
)
BEGIN
    UPDATE AUTH_ACTION 
    SET 
        DELETEDFLAG = 1,
        DELETEDBY = p_DeletedBy,
        DELETEDTIME = NOW()
    WHERE ID = p_ID;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_action_selectByID(
    IN p_ID INT
)
BEGIN
    SELECT * FROM AUTH_ACTION WHERE ID = p_ID AND DELETEDFLAG = 0;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_action_selectAll()
BEGIN
    SELECT * FROM AUTH_ACTION WHERE DELETEDFLAG = 0;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_auth_action_update(
    IN p_ID INT,
    IN p_Name VARCHAR(100),
    IN p_ActionCode VARCHAR(10),
    IN p_UpdatedBy VARCHAR(16)
)
BEGIN
    UPDATE AUTH_ACTION
    SET 
        NAME = p_Name,
        ACTIONCODE = p_ActionCode,
        UPDATEDBY = p_UpdatedBy,
        UPDATEDTIME = NOW()
    WHERE ID = p_ID;
END $$
DELIMITER ;


DELIMITER //
CREATE PROCEDURE sp_auth_page_insert(
    IN p_Code VARCHAR(10),
    IN p_Name VARCHAR(100),
    IN p_ParentCode VARCHAR(10),
    IN p_Level INT,
    IN p_Url VARCHAR(500),
    IN p_Hidden INT,
    IN p_Icon VARCHAR(50),
    IN p_Sort INT,
    IN p_CreatedBy VARCHAR(16),
    IN p_ActionCode JSON
)
BEGIN
     -- Thêm page vào bảng AUTH_PAGE
    INSERT INTO AUTH_PAGE (
        CODE, NAME, PARENTCODE, LEVEL, URL, HIDDEN, ICON, SORT, CREATEDTIME, CREATEDBY
    ) VALUES (
        p_Code, p_Name, p_ParentCode, p_Level, p_Url, p_Hidden, p_Icon, p_Sort, NOW(), p_CreatedBy
    );

    -- Chèn danh sách action vào bảng AUTH_PAGE_ACTION từ JSON
    INSERT INTO AUTH_PAGE_ACTION (PAGECODE, ACTIONCODE, CREATEDTIME, CREATEDBY)
    SELECT p_Code, JSON_UNQUOTE(JSON_EXTRACT(Item, '$.Code')) AS ACTIONCODE, NOW(), p_CreatedBy
    FROM JSON_TABLE(p_ActionCode, '$[*]' COLUMNS (Item JSON PATH '$')) AS Item;

END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_auth_page_delete(
    IN p_Id INT,
    IN p_DeletedBy VARCHAR(16)
)
BEGIN
    -- Xóa mềm các hành động liên quan trong AUTH_PAGE_ACTION
    UPDATE AUTH_PAGE_ACTION 
    SET DELETEDFLAG = 1, DELETEDBY = p_DeletedBy, DELETEDTIME = NOW()
    WHERE PAGECODE = (SELECT CODE FROM AUTH_PAGE WHERE ID = p_Id);
    
    -- Xóa mềm page trong AUTH_PAGE
    UPDATE AUTH_PAGE 
    SET DELETEDFLAG = 1, DELETEDBY = p_DeletedBy, DELETEDTIME = NOW()
    WHERE ID = p_Id;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_auth_page_selectAll()
BEGIN
    SELECT 
        p.ID,
        P.CODE,
        p.NAME,
        p.PARENTCODE,
        p.LEVEL,
        p.URL,
        p.HIDDEN,
        p.ICON,
        p.SORT,
        p.CREATEDTIME,
        p.CREATEDBY,
        p.UPDATEDTIME,
        p.UPDATEDBY,
        p.DELETEDTIME,
        p.DELETEDBY,
        p.DELETEDFLAG,
        COALESCE(
            CONCAT('[', GROUP_CONCAT(
                JSON_OBJECT('Code', a.ACTIONCODE)
            ), ']'), 
            '[]'
        ) AS actionCode
    FROM AUTH_PAGE p
    LEFT JOIN AUTH_PAGE_ACTION a ON p.CODE = a.PAGECODE
    WHERE p.DELETEDFLAG = 0
    GROUP BY p.ID,
        P.CODE,
        p.NAME,
        p.PARENTCODE,
        p.LEVEL,
        p.URL,
        p.HIDDEN,
        p.ICON,
        p.SORT,
        p.CREATEDTIME,
        p.CREATEDBY,
        p.UPDATEDTIME,
        p.UPDATEDBY,
        p.DELETEDTIME,
        p.DELETEDBY,
        p.DELETEDFLAG;
END //

DELIMITER //
CREATE PROCEDURE sp_auth_page_selectByID(
    IN p_ID VARCHAR(10)
)
BEGIN
    SELECT 
        p.ID,
        P.CODE,
        p.NAME,
        p.PARENTCODE,
        p.LEVEL,
        p.URL,
        p.HIDDEN,
        p.ICON,
        p.SORT,
        p.CREATEDTIME,
        p.CREATEDBY,
        p.UPDATEDTIME,
        p.UPDATEDBY,
        p.DELETEDTIME,
        p.DELETEDBY,
        p.DELETEDFLAG, 
        COALESCE(
            CONCAT('[', GROUP_CONCAT(
                JSON_OBJECT('Code', a.ACTIONCODE)
            ), ']'), 
            '[]'
        ) AS actionCode
    FROM AUTH_PAGE p
    LEFT JOIN AUTH_PAGE_ACTION a ON p.CODE = a.PAGECODE
    WHERE p.ID = p_ID AND p.DELETEDFLAG = 0
    GROUP BY p.ID,
        P.CODE,
        p.NAME,
        p.PARENTCODE,
        p.LEVEL,
        p.URL,
        p.HIDDEN,
        p.ICON,
        p.SORT,
        p.CREATEDTIME,
        p.CREATEDBY,
        p.UPDATEDTIME,
        p.UPDATEDBY,
        p.DELETEDTIME,
        p.DELETEDBY,
        p.DELETEDFLAG;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_auth_page_update(
    IN p_Id INT,
    IN p_Code VARCHAR(10),
    IN p_Name VARCHAR(100),
    IN p_ParentCode VARCHAR(10),
    IN p_Level INT,
    IN p_Url VARCHAR(500),
    IN p_Hidden INT,
    IN p_Icon VARCHAR(50),
    IN p_Sort INT,
    IN p_UpdatedBy VARCHAR(16),
    IN p_ActionCode JSON
)
BEGIN
    -- Cập nhật thông tin trang trong AUTH_PAGE
    UPDATE AUTH_PAGE 
    SET CODE = p_Code,
        NAME = p_Name,
        PARENTCODE = p_ParentCode,
        LEVEL = p_Level,
        URL = p_Url,
        HIDDEN = p_Hidden,
        ICON = p_Icon,
        SORT = p_Sort,
        UPDATEDTIME = NOW(),
        UPDATEDBY = p_UpdatedBy
    WHERE ID = p_Id;
    
    -- Xóa cứng tất cả action liên quan đến trang
    DELETE FROM AUTH_PAGE_ACTION WHERE PAGECODE = (SELECT CODE FROM AUTH_PAGE WHERE ID = p_Id);
    
    -- Thêm mới danh sách action vào AUTH_PAGE_ACTION từ JSON
    INSERT INTO AUTH_PAGE_ACTION (PAGECODE, ACTIONCODE, CREATEDTIME, CREATEDBY)
    SELECT p_Code, JSON_UNQUOTE(JSON_EXTRACT(Item, '$.Code')) AS ACTIONCODE, NOW(), p_UpdatedBy
    FROM JSON_TABLE(p_ActionCode, '$[*]' COLUMNS (Item JSON PATH '$')) AS Item;
    
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_auth_page_get_permisson_user(
    IN p_ID INT
)
BEGIN
    SELECT DISTINCT
        p.*
    FROM AUTH_USER u
    JOIN AUTH_USER_ROLE ur ON u.ID = ur.USERID
    JOIN AUTH_ROLE r ON ur.ROLECODE = r.CODE
    JOIN AUTH_PAGE_ACTION_ROLE par ON r.CODE = par.ROLECODE
    JOIN AUTH_PAGE p ON par.PAGECODE = p.CODE
    WHERE u.ID = p_ID AND u.DELETEDFLAG = 0 AND r.DELETEDFLAG = 0 AND p.DELETEDFLAG = 0;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_product_insert(
    IN p_productName VARCHAR(255),
    IN p_description VARCHAR(500),
    IN p_price DECIMAL(10,2),
    IN p_stockQuantity INT,
    IN p_category VARCHAR(100),
    IN p_supplier VARCHAR(100),
    IN p_discount DECIMAL(5,2),
    IN p_createdBy INT,
    IN p_imageUrl JSON
)
BEGIN
    DECLARE new_product_id INT;
    
    -- Thêm sản phẩm vào bảng AUTH_PRODUCT
    INSERT INTO AUTH_PRODUCT (
        PRODUCTNAME, DESCRIPTION, PRICE, STOCKQUANTITY, CATEGORY, SUPPLIER, DISCOUNT, CREATEDTIME, CREATEDBY
    ) VALUES (
        p_productName, p_description, p_price, p_stockQuantity, p_category, p_supplier, p_discount, NOW(), p_createdBy
    );
    
    -- Lấy ID của sản phẩm vừa thêm
    SET new_product_id = LAST_INSERT_ID();
    
    -- Chèn danh sách hình ảnh vào bảng AUTH_PRODUCT_IMAGE từ JSON
    INSERT INTO AUTH_PRODUCT_IMAGE (IDPRODUCT, IMAGEURL, CREATEDTIME, CREATEDBY)
    SELECT new_product_id, JSON_UNQUOTE(JSON_EXTRACT(Item, '$.Code')), NOW(), p_createdBy
    FROM JSON_TABLE(p_imageUrl, '$[*]' COLUMNS (Item JSON PATH '$')) AS Item;

END //

DELIMITER //
CREATE PROCEDURE sp_product_delete(
    IN p_ID INT,
    IN p_DeletedBy INT
)
BEGIN
    -- Xóa mềm các hình ảnh liên quan trong AUTH_PRODUCT_IMAGE
    UPDATE AUTH_PRODUCT_IMAGE 
    SET DELETEDFLAG = 1, DELETEDBY = p_DeletedBy, DELETEDTIME = NOW()
    WHERE IDPRODUCT = p_ID;
    
    -- Xóa mềm sản phẩm trong AUTH_PRODUCT
    UPDATE AUTH_PRODUCT 
    SET DELETEDFLAG = 1, DELETEDBY = p_DeletedBy, DELETEDTIME = NOW()
    WHERE ID = p_ID;
END //

DELIMITER //
CREATE PROCEDURE sp_product_selectAll()
BEGIN
    SELECT 
        p.*, 
        COALESCE(
            CONCAT('[', GROUP_CONCAT(
                JSON_OBJECT('Code', i.IMAGEURL)
            ), ']'), 
            '[]'
        ) AS imageUrl
    FROM AUTH_PRODUCT p
    LEFT JOIN AUTH_PRODUCT_IMAGE i ON p.ID = i.IDPRODUCT
    WHERE p.DELETEDFLAG = 0
    GROUP BY p.ID;
END //

DELIMITER //
CREATE PROCEDURE sp_product_selectByID(
    IN p_ID INT
)
BEGIN
    SELECT 
        p.*, 
        COALESCE(
            CONCAT('[', GROUP_CONCAT(
                JSON_OBJECT('Code', i.IMAGEURL)
            ), ']'), 
            '[]'
        ) AS imageUrl
    FROM AUTH_PRODUCT p
    LEFT JOIN AUTH_PRODUCT_IMAGE i ON p.ID = i.IDPRODUCT
    WHERE p.ID = p_ID AND p.DELETEDFLAG = 0
    GROUP BY p.ID;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_product_update(
    IN p_id INT,
    IN p_productName VARCHAR(255),
    IN p_description VARCHAR(500),
    IN p_price DECIMAL(10,2),
    IN p_stockQuantity INT,
    IN p_category VARCHAR(100),
    IN p_supplier VARCHAR(100),
    IN p_discount DECIMAL(5,2),
    IN p_updatedBy INT,
    IN p_imageUrl JSON
)
BEGIN
    -- Cập nhật thông tin sản phẩm trong AUTH_PRODUCT
    UPDATE AUTH_PRODUCT
    SET PRODUCTNAME = p_productName,
        DESCRIPTION = p_description,
        PRICE = p_price,
        STOCKQUANTITY = p_stockQuantity,
        CATEGORY = p_category,
        SUPPLIER = p_supplier,
        DISCOUNT = p_discount,
        UPDATEDTIME = NOW(),
        UPDATEDBY = p_updatedBy
    WHERE ID = p_id;
    
    -- Chèn danh sách hình ảnh từ JSON
    INSERT INTO AUTH_PRODUCT_IMAGE (IDPRODUCT, IMAGEURL, CREATEDTIME, CREATEDBY)
    SELECT p_id, JSON_UNQUOTE(JSON_EXTRACT(Item, '$.Code')), NOW(), p_updatedBy
    FROM JSON_TABLE(p_imageUrl, '$[*]' COLUMNS (Item JSON PATH '$')) AS Item;

END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE sp_productimage_delete(
    IN p_ID INT
)
BEGIN
    DELETE FROM AUTH_PRODUCT_IMAGE WHERE ID = p_ID;
END //

DELIMITER //
CREATE PROCEDURE sp_productimage_getid(
    IN p_imageUrl VARCHAR(255)
)
BEGIN
    SELECT ID FROM AUTH_PRODUCT_IMAGE WHERE IMAGEURL = p_imageUrl LIMIT 1;
END //
DELIMITER ;