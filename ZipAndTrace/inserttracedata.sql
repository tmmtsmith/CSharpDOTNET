/* SQL Server Stored Procedure */
USE [DATABASENAME]
GO

/****** Object:  StoredProcedure [dbo].[stp_InsertTraceData]    Script Date: 10/14/2013 3:19:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_InsertTraceData]
@temp VARCHAR(100), @main VARCHAR(100)
AS
BEGIN

	DECLARE @sql NVARCHAR(MAX)
	SET @sql = 'INSERT INTO ' + @main + ' [OUR DATA SELECTION MATCH]
	SELECT [OUR DATA SELECTION]
	FROM ' + @temp + ''

	EXECUTE sp_executesql @sql

END
