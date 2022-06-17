CREATE DATABASE [SmarterBooks];

SET IDENTITY_INSERT Books OFF;

INSERT INTO [Books](Name, Author) VALUES ('Design Pattern', 'Sendy Friscilla');

SELECT * FROM [Books];

DROP TABLE [Books];