DROP TABLE IF EXISTS accounts;

CREATE TABLE accounts 
(	
	account_id	integer PRIMARY KEY,
	email		varchar(100)	UNIQUE NOT NULL,
	password 	varchar(100) 	NOT NULL,
	nif		integer UNIQUE
);


INSERT INTO accounts (email, password) VALUES ('admin@dashboard360.com',123456);
INSERT INTO accounts (email, password) VALUES ('vendedor@dashboard360',123456);

