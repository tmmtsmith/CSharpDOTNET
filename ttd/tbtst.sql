
CREATE TABLE AffluentCustomers(
	Name VARCHAR(100),
	PID VARCHAR(25)
)

INSERT INTO AffluentCustomers
VALUES ('John','XY872L985RYR')
	, ('Sarah','764YFXLPQZC')
	

-- After creating the table, wait anywhere from 1 to 3 days, then ...

DROP TABLE AffluentCustomers

-- Oh noez!!!  I need my table.
