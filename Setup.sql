USE vacations;

-- NOTE this is creating the table to put burgers in

--  CREATE TABLE cruises
-- (
--   id INT AUTO_INCREMENT,
--   description VARCHAR(255) NOT NULL,
--   price DECIMAL(6 , 2) NOT NULL,
--   destination VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- );

-- NOTE this is creating actual burger

INSERT INTO cruises
(description, destination, price)
VALUES
("Anniversary", "England", 1400.00)

-- Get All of a collection
-- SELECT * FROM fries;

-- Get a specific from a collection

-- SELECT * FROM burgers WHERE description="Brisket" OR id=1;

-- DELETE FROM burgers WHERE id=1;

-- DELETE burgers;
-- TRUNCATE burgers;

-- DROP TABLE knights;