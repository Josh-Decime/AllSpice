CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';
drop table if EXISTS accounts;
CREATE TABLE recipes(
  id INT AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(50) Not Null,
  instructions VARCHAR(1500) NOT NULL,
  img VARCHAR(500) NOT NULL,
  category VARCHAR(25) NOT NULL,
  creatorId VARCHAR(255) Not NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8mb4 COMMENT '';
drop Table if EXISTS recipes;
INSERT INTO recipes (title, instructions, img, category, creatorId)
VALUES (
    @title,
    @instructions,
    @img,
    @category,
    @creatorId
  );
SELECT recipes.*,
  accounts.*
FROM recipes
  JOIN accounts ON recipes.creatorId = accounts.id
WHERE recipes.id = LAST_INSERT_ID();