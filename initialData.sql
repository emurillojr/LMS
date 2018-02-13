INSERT INTO 
LibraryBranches(ImageUrl, [Address], [Name], Telephone, OpenDate, [Description]) 
VALUES 
('/images/branches/1.png', '150 Empire Street', 'Providence Downtown Branch', '555-1234', '1875-05-13', 'The Downtown library branch was founded in 1875. The Central Library building at 225 Washington Street opened in 1900 and was constructed in a Renaissance style.'),
('/images/branches/2.png', '90 Ives Street', 'Fox Point Branch', '555-4567', '1912-06-01', 'The Fox Point branch contains the community center built to serve the Boys and Girls Club. This branch works hard to create a warm and welcoming library.'),
('/images/branches/3.png', '1316 Broad Street', 'Washington Park Branch', '555-7890', '1927-09-20', 'The Washington Park branch, newly renovated with a new roof, exterior brickwork, a restroom, a new entrance, fire-alarm system and carpeting.');
SELECT * FROM LibraryBranches

INSERT INTO 
Patrons([Address], DateOfBirth, FirstName, HomeLibraryBranchId, LastName, TelephoneNumber) VALUES
('165 Peace St', 	'1986-07-10', 'Tom', 		1, 'Hanks', 	'555-1234'),
('324 Shadow Ln', 	'1984-03-12', 'Brad', 		2, 'Pitt', 	'555-7785'),
('18 Stone Cir', 	'1956-02-10', 'Matt', 		3, 'Damon', 	'555-3467'),
('246 Jennifer St', 	'1997-01-17', 'Will', 		1, 'Smith', 	'555-1223'),
('1465 Williamson St', 	'1952-09-16', 'Al', 		2, 'Pacino', 	'555-8884'),
('785 Park Ave', 	'1994-03-24', 'Julia', 		3, 'Roberts', 	'555-9988'),
('5654 Main St', 	'1978-11-23', 'Natalie', 	1, 'Portman', 	'555-7894'),
('1352 Bicycle Ct', 	'1981-10-16', 'Halle', 		2, 'Berry', 	'555-4568'),
('1111 Scorn Ct', 	'1954-10-16', 'Jackie', 	3, 'Chan', 	'555-4568')
SELECT * FROM Patrons

INSERT INTO LibraryAssets
(Discriminator, Cost, LocationId, Author, DeweyIndex, ISBN, Title, [Year], Director, ImageUrl, NumberOfCopies) VALUES
('Book', 12.99, 1,  'Herman Melville', 	'822.345', '9780746062760', 'Moby Dick', 1851, NULL, '/images/mobydick.png', 1),
('Book', 18.00, 2,  'Bram Stoker', 		'825.678', '9781623750282', 'Dracula', 1897, NULL, '/images/dracula.png', 4),
('Book', 11.99, 3,  'Alice Walker',		'829.001', '9780151191543', 'The Color Purple', 1982, NULL, '/images/colorpurple.png', 2),
('Book', 15.99, 1,  'Miguel de Cervantes', 	'835.567', '9785457624589', 'Don Quixote', 1925, NULL, '/images/quixote.png', 1),
('Book', 15.99, 2,  'William Shakespeare', 	'836.678', '9784567135751', 'Hamlet', 1921, NULL, '/images/hamlet.png', 1),
('Book', 15.99, 3,  'Mark Twain', 		'837.789', '9783457612345', 'The Adventures of Huckleberry Finn', 1922, NULL, '/images/huckleberry.png', 1),
('Book', 15.99, 1,  'Lewis Carroll', 		'838.901', '9787897668891', 'Alices Adventures in Wonderland', 1935, NULL, '/images/alice.png', 1),
('Book', 15.99, 2,  'Ralph Ellison', 		'839.001', '9783457345611', 'Invisible Man', 1915, NULL, '/images/invisible.png', 1),
('Book', 15.99, 3,  'William Golding', 	'840.002', '9787897624466', 'Lord of the Flies', 1905, NULL, '/images/lordflies.png', 1),
('Book', 15.99, 1,  'Mary Shelley', 		'841.333', '9783457629933', 'Frankenstein', 1925, NULL, '/images/frankenstein.png', 1),
('Book', 15.99, 2,  'J. R. R. Tolkien', 	'842.421', '9789997622790', 'The Lord of the Rings', 1965, NULL, '/images/lotr.png', 1),
('Book', 15.99, 3,  'E. B. White', 		'843.768', '9782347624321', 'Charlottes Web', 1975, NULL, '/images/charlottes.png', 1),
('Book', 15.99, 1,  'Alexandre Dumas', 	'844.990', '9785678905693', 'The Count of Monte Cristo', 1905, NULL, '/images/montecristo.png', 1),
('Book', 15.99, 2,  'Robert Louis Stevenson',	'845.439', '9786787129934', 'The Strange Case of Dr. Jekyll and Mr. Hyde', 1955, NULL, '/images/jekyll.png', 1),
('Book', 15.99, 3,  'J. K. Rowling', 		'846.123', '9788907230011', 'Harry Potter And The Philosophers Stone', 1995, NULL, '/images/potter.png', 1),
('Book', 15.99, 1,  'Arthur Conan Doyle', 	'847.560', '9781237568902', 'The Complete Sherlock Holmes', 1965, NULL, '/images/holmes.png', 1),
('Book', 15.99, 2,  'Frank Herbert', 		'848.345', '9784537345678', 'Dune', 1945, NULL, '/images/dune.png', 1),
('Book', 15.99, 3,  'Alexandre Dumas', 	'849.123', '9787657787965', 'The Three Musketeers', 1945, NULL, '/images/three.png', 1),
('Video', 24.00, 1, NULL, NULL, NULL, 'Blue Velvet',	1986, 'David Lynch', '/images/bluevelvet.png', 1),
('Video', 24.00, 2, NULL, NULL, NULL, 'Trois Coleurs: Rouge', 1994, 'Krzysztof Kieslowski', '/images/redrouge.png', 1),
('Video', 30.00, 3, NULL, NULL, NULL, 'Citizen Kane',	1941, 'Orson Welles', '/images/citizenkane.png', 1),
('Video', 23.00, 1, NULL, NULL, NULL, 'The Departed',	2006, 'Martin Scorsese', '/images/departed.png', 1),
('Video', 17.99, 2, NULL, NULL, NULL, 'Taxi Driver', 1976, 'Martin Scorsese', '/images/taxidriver.png', 1),
('Video', 18.00, 3, NULL, NULL, NULL, 'Casablanca',	1943, 'Michael Curtiz', '/images/casa.png', 1);
SELECT * FROM LibraryAssets
