IF OBJECT_ID('Products') IS NOT NULL DROP TABLE Products
IF OBJECT_ID('Categories') IS NOT NULL DROP TABLE Categories
IF OBJECT_ID('ProductsCategories') IS NOT NULL DROP TABLE ProductsCategories

CREATE TABLE Products (
	Id INT IDENTITY(1, 1),
	[Name] NVARCHAR(100) NOT NULL 
)
GO

INSERT INTO Products VALUES 
	('Яблоки'), ('Груши'), ('Сливы'), ('Абрикосы'), 
	('Гречка'), ('Рис'), ('Манка'), ('Макароны'), 
	('Колбаса'), ('Говядина'), ('Свинина'), ('Баранина'),
	('Тетради'), ('Книги'), ('Свечи'), ('Мыло')

--SELECT * FROM Products

CREATE TABLE Categories (
	Id INT IDENTITY(1, 1),
	[Name] NVARCHAR(100) NOT NULL 
)
GO

INSERT INTO Categories VALUES 
	('Фрукты'), ('Бакалея'), ('Мясные продукты'), 
	('Импорт'), ('Отечественные'), ('Просроченные')

--SELECT * FROM Categories

CREATE TABLE ProductsCategories (
	ProductId INT NOT NULL,
	CategoryId INT NOT NULL
)
GO

INSERT INTO ProductsCategories VALUES 
	(1, 1), (1, 4), (1, 5), (1, 6), (2, 1), (2, 4), (2, 5), (3, 1), (3, 4), (3, 5), (4, 1), (4, 4), (4, 5),
	(5, 2), (5, 4), (5, 5), (6, 2), (6, 4), (6, 5), (7, 2), (7, 4), (7, 5), (8, 2), (8, 4), (8, 5),
	(9, 3), (9, 4), (9, 5), (10, 3), (10, 4), (10, 5), (11, 3), (11, 4), (11, 5), (12, 3), (12, 4), (12, 5)

--SELECT * FROM ProductsCategories

SELECT p1.Name, c1.Name FROM (
	SELECT p.Id, pc.CategoryId 
	FROM Products p
		LEFT JOIN ProductsCategories pc ON p.Id = pc.ProductId
	GROUP BY p.Id, pc.CategoryId) as g 
LEFT JOIN Products p1 ON g.Id = p1.Id
LEFT JOIN Categories c1 ON g.CategoryId = c1.Id