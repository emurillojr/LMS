INSERT INTO 
LibraryBranches(ImageUrl, [Address], [Name], Telephone, OpenDate, [Description]) 
VALUES 
('/images/branches/1.png', '150 Empire St. Providence, RI 02909', 'Providence Downtown Branch', '401-888-2222', '1875-05-13', 'The Downtown library branch was founded in 1875. The Central Library building at 225 Washington Street opened in 1900 and was constructed in a Renaissance style.'),
('/images/branches/2.png', '90 Ives St.  Providence, RI 02909', 'Fox Point Branch', '401-888-1111', '1912-06-01', 'The Fox Point branch contains the community center built to serve the Boys and Girls Club. This branch works hard to create a warm and welcoming library.'),
('/images/branches/3.png', '1316 Broad St. Providence, RI 02909', 'Washington Park Branch', '401-888-3333', '1927-09-20', 'The Washington Park branch, newly renovated with a new roof, exterior brickwork, a restroom, a new entrance, fire-alarm system and carpeting.');
SELECT * FROM LibraryBranches

INSERT INTO 
Patrons([Address], DateOfBirth, FirstName, HomeLibraryBranchId, LastName, TelephoneNumber) VALUES
('165 Captain St. Providence, RI 02909', 	'1986-07-10', 'Tom', 		1, 'Hanks', 	'401-555-1234'),
('324 America Ln. Providence, RI 02909', 	'1984-03-12', 'Brad', 		2, 'Pitt', 		'401-555-7785'),
('18 Thor Cir. Providence, RI 02909', 		'1956-02-10', 'Matt', 		3, 'Damon', 	'401-555-3467'),
('246 Black St. Providence, RI 02909', 		'1997-01-17', 'Will', 		1, 'Smith', 	'401-555-1223'),
('1465 Widow St. Providence, RI 02909', 	'1952-09-16', 'Al', 		2, 'Pacino', 	'401-555-8884'),
('785 Vision Ave. Providence, RI 02909', 	'1994-03-24', 'Julia', 		3, 'Roberts', 	'401-555-9988'),
('5654 Loki St. Providence, RI 02909', 		'1978-11-23', 'Natalie', 	1, 'Portman', 	'401-555-7894'),
('1352 Starlord Ct. Providence, RI 02909', 	'1981-10-16', 'Halle', 		2, 'Berry', 	'401-555-4568'),
('1111 Rocket Ct. Providence, RI 02909', 	'1954-10-16', 'Jackie', 	3, 'Chan', 		'401-555-4561'),
('1111 Rocket Ct. Providence, RI 02909', 	'1954-10-16', 'Jet', 		1, 'Li', 		'401-555-1562'),
('1111 Rocket Ct. Providence, RI 02909', 	'1954-10-16', 'Donnie', 	2, 'Yen', 		'401-555-2563'),
('1111 Rocket Ct. Providence, RI 02909', 	'1954-10-16', 'Josh', 		3, 'Brolin', 	'401-555-4364'),
('1111 Rocket Ct. Providence, RI 02909', 	'1954-10-16', 'Scarlett', 	1, 'Johansson', '401-555-4465'),
('1111 Rocket Ct. Providence, RI 02909', 	'1954-10-16', 'Chris', 		2, 'Pratt', 	'401-555-7566'),
('1111 Rocket Ct. Providence, RI 02909', 	'1954-10-16', 'Zoe', 		3, 'Saldana', 	'401-555-8567')
SELECT * FROM Patrons

INSERT INTO LibraryAssets
(Cost, LocationId, Author, DeweyIndex, ISBN, Title, [Year], ImageUrl, NumberOfCopies) VALUES
(12.99, 1,  'Herman Melville', 	'822.345', '9780746062760', 'Moby Dick', 1851, '/images/mobydick.png', 1),
(18.00, 2,  'Bram Stoker', 		'825.678', '9781623750282', 'Dracula', 1897, '/images/dracula.png', 4),
(11.99, 3,  'Alice Walker',		'829.001', '9780151191543', 'The Color Purple', 1982, '/images/colorpurple.png', 2),
(13.99, 1,  'Miguel de Cervantes', 	'835.567', '9785457624589', 'Don Quixote', 1925, '/images/quixote.png', 1),
(14.99, 2,  'William Shakespeare', 	'836.678', '9784567135751', 'Hamlet', 1921, '/images/hamlet.png', 1),
(15.99, 3,  'Mark Twain', 		'837.789', '9783457612345', 'Huckleberry Finn', 1922, '/images/huckleberry.png', 1),
(16.99, 1,  'Lewis Carroll', 		'838.901', '9787897668891', 'Alice in Wonderland', 1935, '/images/alice.png', 1),
(17.00, 2,  'Ralph Ellison', 		'839.001', '9783457345611', 'Invisible Man', 1915, '/images/invisible.png', 1),
(18.99, 3,  'William Golding', 	'840.002', '9787897624466', 'Lord of the Flies', 1905, '/images/lordflies.png', 1),
(25.99, 1,  'Mary Shelley', 		'841.333', '9783457629933', 'Frankenstein', 1925, '/images/frankenstein.png', 1),
(15.99, 2,  'J. R. R. Tolkien', 	'842.421', '9789997622790', 'The Lord of the Rings', 1965, '/images/lotr.png', 1),
(10.99, 3,  'E. B. White', 		'843.768', '9782347624321', 'Charlottes Web', 1975, '/images/charlottes.png', 1),
(15.99, 1,  'Alexandre Dumas', 	'844.990', '9785678905693', 'The Count of Monte Cristo', 1905, '/images/montecristo.png', 1),
(15.99, 2,  'Robert Louis Stevenson',	'845.439', '9786787129934', 'Dr. Jekyll and Mr. Hyde', 1955, '/images/jekyll.png', 1),
(25.99, 3,  'J. K. Rowling', 		'846.123', '9788907230011', 'Harry Potter', 1995, '/images/potter.png', 1),
(18.00, 1,  'Arthur Conan Doyle', 	'847.560', '9781237568902', 'Sherlock Holmes', 1965, '/images/holmes.png', 1),
(21.99, 2,  'Frank Herbert', 		'848.345', '9784537345678', 'Dune', 1945, '/images/dune.png', 1),
(23.99, 3,  'Alexandre Dumas', 	'849.123', '9787657787965', 'The Three Musketeers', 1945, '/images/three.png', 1);
SELECT * FROM LibraryAssets
