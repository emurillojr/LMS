INSERT INTO 
Companies(Name) 
VALUES 
('Netflix'),
('Hulu'),
('Amazon')
SELECT * FROM Companies


INSERT INTO 
Ratings(RatingName, RatingDesc) VALUES
('G','General Audiences.'),
('PG','Parental Guidance Suggested.'),
('PG-13','Parents Strongly Cautioned.'),
('R','Restricted. Under 17 requires accompanying parent or adult guardian.'),
('NC-17','Adults Only. No One 17 and Under Admitted.'),
('TV-Y7','This program is designed for children age 7 and above.'),
('TV-G','Most parents would find this program suitable for all ages.'),
('TV-PG','Parental guidance is recommended; these programs may be unsuitable for younger children.'),
('TV-14','This program contains some material that many parents would find unsuitable for children under 14 years of age.'),
('TV-MA','This program is intended to be viewed by adults and therefore may be unsuitable for children under 17.')
SELECT * FROM Ratings

INSERT INTO MovieShows
(Title, ImageName, Type, CompanyId, RatingId) VALUES
('The Punisher','/Images/Punisher.jpg', 1, 1, 1),
('The Punisher','/Images/Punisher.jpg', 1, 1, 2),
('The Punisher','/Images/Punisher.jpg', 1, 1, 3),
('The Punisher','/Images/Punisher.jpg', 1, 1, 4),
('The Punisher','/Images/Punisher.jpg', 1, 1, 5),
('The Punisher','/Images/Punisher.jpg', 1, 2, 1),
('The Punisher','/Images/Punisher.jpg', 1, 2, 2),
('The Punisher','/Images/Punisher.jpg', 1, 2, 3),
('The Punisher','/Images/Punisher.jpg', 1, 2, 4),
('The Punisher','/Images/Punisher.jpg', 1, 2, 5),
('The Punisher','/Images/Punisher.jpg', 1, 3, 1),
('The Punisher','/Images/Punisher.jpg', 1, 3, 2),
('The Punisher','/Images/Punisher.jpg', 1, 3, 3),
('The Punisher','/Images/Punisher.jpg', 1, 3, 4),
('The Punisher','/Images/Punisher.jpg', 1, 3, 5),

('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 1, 1),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 1, 2),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 1, 3),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 1, 4),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 1, 5),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 1),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 2),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 3),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 4),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 5),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 1),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 2),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 3),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 4),
('Brooklyn 99','/Images/Brooklyn99.jpg', 2, 2, 5)
SELECT * FROM MovieShows