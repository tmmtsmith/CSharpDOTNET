CREATE PROCEDURE stp_InsertMOData
AS
BEGIN

	-- Create temporary holding table for stock data
	CREATE TABLE StockStage(
		[Date] VARCHAR(100),
		[Open] VARCHAR(100),
		[High] VARCHAR(100),
		[Low] VARCHAR(100),
		[Close] VARCHAR(100),
		[Volume] VARCHAR(100),
		[Adj Close] VARCHAR(100)
	)

	-- Insert the data to stage
	BULK INSERT StockStage
	FROM 'E:\Check\test.csv'
	WITH (
		FIELDTERMINATOR = ','
		,ROWTERMINATOR = '0x0a')

	-- Insert the final data only that doesn't already exist and that matches a certain criteria
	INSERT INTO MoHistoricalData ([Close],[Date])
	SELECT [Close], [Date]
	FROM StockStage
	WHERE ISNUMERIC([Close]) = 1
		AND [Date] <> 'DATE'
		AND [Date] NOT IN (SELECT [Date] FROM MoHistoricalData)

	-- Eliminate the cleaning table
	DROP TABLE StockStage

END
