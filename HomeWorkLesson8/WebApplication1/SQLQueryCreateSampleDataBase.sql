--Создание таблиц с удаление уже имеющихся
IF OBJECT_ID('Employee' ) IS NOT NULL DROP TABLE Employee;
IF OBJECT_ID('Department' ) IS NOT NULL DROP TABLE Department;
CREATE TABLE Department
(
id INT IDENTITY(1,1) NOT NULL,
department NVARCHAR(128) NOT NULL,
CONSTRAINT PK_id_Department PRIMARY KEY (id),
);
CREATE TABLE Employee
(
id INT IDENTITY(1,1) NOT NULL,
fam NVARCHAR(256) NOT NULL,
name NVARCHAR(256) NOT NULL,
age INT NOT NULL,
salary FLOAT NOT NULL,
department_id INT NULL,
CONSTRAINT PK_id_Employee PRIMARY KEY (id),
CONSTRAINT FK_Department_id_Department FOREIGN KEY (department_id)
	REFERENCES Department(id),
);
--Тестовые данные
DECLARE @count_departments INT = 100;
DECLARE @count_employees INT = 2000;
DECLARE @i INT = 1;
WHILE @i <= @count_departments
BEGIN
	INSERT INTO Department(department)
	VALUES (CONCAT(N'Отдел ', @i, N'-й'));
	SET @i = @i + 1;
END
DECLARE @j INT = 1;
DECLARE @id_department INT = 1;
DECLARE @age INT = 18;
WHILE @j <= @count_employees
BEGIN
	INSERT INTO Employee(fam, name, age, salary, department_id)
	VALUES (CONCAT(N'Тестов', @j),CONCAT(N'Тест', @j),@age,10000.0,@id_department);
	IF (@id_department < @count_departments)
		SET @id_department = @id_department + 1;
	ELSE
		SET @id_department = 1;
	IF (@age < 100)
		SET @age = @age + 1;
	ELSE
		SET @age = 18;
	SET @j = @j + 1;
END
--Сформированные тестовые данные
SELECT e.id,e.fam,e.name,e.age,e.salary,d.department FROM Employee e INNER JOIN Department d ON e.department_id=d.id;
--Запрос к сотрудникам
--SELECT id,fam,name,age,salary,department_id FROM Employee;
--Запрос к отделам
--SELECT id,department FROM Department;
