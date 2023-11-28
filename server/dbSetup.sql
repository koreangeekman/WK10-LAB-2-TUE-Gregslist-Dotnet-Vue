CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS jobs(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'generated at api',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        title CHAR(128) NOT NULL,
        description CHAR(128) NOT NULL,
        salary INT NOT NULL
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS houses(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'auto inc int ID',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        title CHAR(128) NOT NULL,
        description VARCHAR(1024) NOT NULL,
        price INT NOT NULL,
        bedrooms TINYINT NOT NULL,
        bathrooms TINYINT NOT NULL,
        imgUrl VARCHAR(384)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS cars(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'auto inc int ID',
        createdAt DATETIME CURRENT_TIMESTAMP,
        updatedAt DATETIME CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        title CHAR(128) NOT NULL,
        description VARCHAR(1024) NOT NULL,
        price INT NOT NULL,
        mileage INT NOT NULL,
        imgUrl VARCHAR(384)
    ) default charset utf8 COMMENT '';

INSERT INTO jobs (name, description, salary) VALUES('')