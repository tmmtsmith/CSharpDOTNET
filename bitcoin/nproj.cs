/*

CREATE TABLE PAEMs(
	WeekID SMALLINT IDENTITY(1,1),
	Desired INT,
	Actual INT,
	DesAcDifference INT,
	WeekDate DATE DEFAULT GETDATE()
)

--  F
INSERT INTO PAEMs (Desired)
VALUES ('up')

-- Rem
DECLARE @max INT
SELECT @max = MAX(WeekID) FROM PAEMs

;WITH Former AS(
	SELECT Desired * .2 AS Inc
	FROM PAEMs
	WHERE WeekID = @max
)
INSERT INTO PAEMs (Desired,Actual,DesAcDifference)
SELECT Inc, 'up', (Inc - 'up')
FROM Former


*/
