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


-- Constraints
DECLARE @remove TABLE(
	RemoveID INT IDENTITY(1,1),
	TableName VARCHAR(100),
	ConstraintName VARCHAR(250)
)

INSERT INTO @remove (TableName,ConstraintName)
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


-- Identity
DECLARE @identity TABLE(
	IdentityID INT IDENTITY(1,1),
	TableName VARCHAR(100),
	ColumnName VARCHAR(100),
	DataType VARCHAR(25)
)

INSERT INTO @identity (TableName,ColumnName,DataType)
SELECT OBJECT_NAME(c.object_id) AS "TableName"
	, c.name AS ColumnName
	, UPPER(s.DATA_TYPE) AS DataType
FROM sys.columns c
	INNER JOIN sys.tables t ON c.object_id = t.object_id
	INNER JOIN INFORMATION_SCHEMA.COLUMNS s ON t.name = s.TABLE_NAME AND c.column_id = s.ORDINAL_POSITION
WHERE t.type = 'U'
	AND t.is_ms_shipped = '0'
	AND c.is_identity = 1

SELECT *
FROM @identity

DECLARE @begint INT = 1, @maxt INT, @ta VARCHAR(100), @co VARCHAR(250), @dt VARCHAR(25), @sqlt NVARCHAR(MAX)
SELECT @maxt = MAX(IdentityID) FROM @identity

WHILE @begint <= @maxt
BEGIN
	
	SELECT @ta = TableName FROM @identity WHERE IdentityID = @begint
	SELECT @co = ColumnName FROM @identity WHERE IdentityID = @begint
	SELECT @dt = DataType FROM @identity WHERE IdentityID = @begint

	SET @sqlt = 'ALTER TABLE ' + @ta + ' DROP COLUMN ' + @co

	--ALTER TABLE ' + @ta + ' ADD COLUMN ' + @co + ' ' + @dt

	EXECUTE sp_executesql @sqlt
	
	SET @begint = @begint + 1

END


/* 

-- References:
SELECT *
FROM INFORMATION_SCHEMA.COLUMNS

SELECT OBJECT_NAME(c.object_id) AS "Name"
	, is_identity
	, *
FROM sys.columns c
	INNER JOIN sys.tables t ON c.object_id = t.object_id
	INNER JOIN INFORMATION_SCHEMA.COLUMNS s ON t.name = s.TABLE_NAME AND c.column_id = s.ORDINAL_POSITION
WHERE t.type = 'U'
	AND t.is_ms_shipped = '0'
	AND c.is_identity = 1

SELECT *
FROM sys.columns
WHERE OBJECT_NAME(object_id) = 'NewerTable'

*/
