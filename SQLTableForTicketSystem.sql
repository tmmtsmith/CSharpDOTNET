-- SQL Server Table for Tickets Program

CREATE TABLE Tickets(
	Name VARCHAR(100),
	Department VARCHAR(100),
	Date SMALLDATETIME DEFAULT getdate(),
	Request VARCHAR(8000)
)