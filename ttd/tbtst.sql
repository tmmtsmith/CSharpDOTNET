
CREATE TABLE AffluentCustomers(
	Name VARCHAR(100),
	PID VARCHAR(25)
)

INSERT INTO AffluentCustomers
VALUES ('John','XY872L985RYR')
	, ('Sarah','764YFXLPQZC')
	

-- After creating the table, wait 3 business days, then ...

DROP TABLE AffluentCustomers

-- Oh noez!!!  I need my table.
-- This is so basic of a task, and yet it's amazing how it can be overlooked.
