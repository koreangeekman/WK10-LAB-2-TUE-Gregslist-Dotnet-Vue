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
        year INT NOT NULL,
        price INT NOT NULL,
        bedrooms TINYINT NOT NULL,
        bathrooms TINYINT NOT NULL,
        imgUrl VARCHAR(384)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS cars(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'auto inc int ID',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        make CHAR(128) NOT NULL,
        model CHAR(128) NOT NULL,
        color CHAR(128) NOT NULL,
        year INT NOT NULL,
        description VARCHAR(1024) NOT NULL,
        price INT NOT NULL,
        mileage INT NOT NULL,
        imgUrl VARCHAR(384)
    ) default charset utf8 COMMENT '';

INSERT INTO
    jobs (title, description, salary)
VALUES ('jester', 'play the fool', 420);

INSERT INTO
    cars(
        make,
        model,
        color,
        description,
        year,
        price,
        mileage,
        imgUrl
    )
VALUES (
        'Ford',
        'F150 Hybrid',
        'Antimatter Blue Metallic',
        'yo',
        2022,
        69420,
        100,
        'https://images.unsplash.com/photo-1579226305581-d56b4afc48d5?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8ZjE1MCUyMGJsdWV8ZW58MHx8MHx8fDA%3D'
    )

INSERT INTO
    houses (
        title,
        description,
        year,
        price,
        bedrooms,
        bathrooms,
        imgUrl
    )
VALUES (
        'one lonely house',
        'a tiny house on a hill',
        1881,
        11111,
        1,
        1,
        "https://images.unsplash.com/photo-1518780664697-55e3ad937233?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aG91c2V8ZW58MHx8MHx8fDA%3D"
    );

INSERT INTO
    houses (
        title,
        description,
        year,
        price,
        bedrooms,
        bathrooms,
        imgUrl
    )
VALUES (
        'a modern house',
        'a big boxy building',
        2020,
        4343434,
        4,
        3,
        "https://images.unsplash.com/photo-1523217582562-09d0def993a6?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8aG91c2V8ZW58MHx8MHx8fDA%3D"
    );

-- DROP TABLE cars;

-- DROP TABLE houses;