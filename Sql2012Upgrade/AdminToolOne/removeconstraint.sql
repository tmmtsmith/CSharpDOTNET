/* 
-- Testing:

CREATE TABLE NewerTable(
	ID INT IDENTITY(1,1),
	ValueOne VARCHAR(5) DEFAULT 'Sym',
	ValueDate DATE DEFAULT GETDATE(),
	Notes VARCHAR(50)
)

SELECT *
FROM NewerTable

DROP TABLE NewerTable

*/

DECLARE @remove TABLE(
	RemoveID INT IDENTITY(1,1),
	TableName VARCHAR(100),
	ConstraintName VARCHAR(250)
)

INSERT INTO @remove (TableName, ConstraintName)
SELECT OBJECT_NAME(parent_object_id) AS TableName
	, name AS ConstraintName
FROM sys.default_constraints 
ORDER BY TableName, ConstraintName

DECLARE @begin INT = 1, @max INT, @t VARCHAR(100), @c VARCHAR(250), @sql NVARCHAR(MAX)
SELECT @max = MAX(RemoveID) FROM @remove

WHILE @begin <= @max
BEGIN

	SELECT @t = TableName FROM @remove WHERE RemoveID = @begin
	SELECT @c = ConstraintName FROM @remove WHERE RemoveID = @begin

	SET @sql = 'ALTER TABLE ' + @t + ' DROP CONSTRAINT ' + @c

	EXECUTE sp_executesql @sql

	SET @begin = @begin + 1
	SET @sql = ''
	SET @t = ''
	SET @c = ''

END


/* 

SELECT *
FROM INFORMATION_SCHEMA.COLUMNS

*/
