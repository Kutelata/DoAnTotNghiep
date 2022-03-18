insert into Author values
-- ('name','image','description','birthday')

('Jason Reynolds','image','description','birthday'),
('Erica Katz','image','description','birthday'),
('Italo Calvino','image','description','birthday'),
('Michel Lauricella','image','description','birthday'),
('Calla Henkel','image','description','birthday'),
('Abrams Books','image','description','birthday'),
('Boo Walker','image','description','birthday'),
('Verna Aardema','image','description','birthday'),
('Pam Grossman','image','description','birthday'),
('Jessica Hundley','image','description','birthday'),
('Barbara O''Neal','image','description','birthday'),

('Jeanine W. Turner','image','description','birthday'),
('David Goggins','image','description','birthday'),
('Donald Miller','image','description','birthday'),
('Chip Heath','image','description','birthday'),
('Karla Starr','image','description','birthday'),
('Lindsey Vonn','image','description','birthday'),
('Whitney Johnson','image','description','birthday'),
('Amy B. Zegart','image','description','birthday'),
('Jimmy Soni','image','description','birthday'),
('Daniel H. Pink','image','description','birthday'),
('John A. List','image','description','birthday'),

('Sabaa Tahir','image','description','birthday'),
('Blue Delliquanti','image','description','birthday'),
('Andrea Sorrentino','image','description','birthday'),
('Tee Franklin','image','description','birthday'),
('Laura Gao','image','description','birthday'),
('Yuko Ota','image','description','birthday'),
('Kendra Wells','image','description','birthday'),
('Ram V','image','description','birthday'),
('Si Spurrier','image','description','birthday'),
('Ariel Slamet Ries','image','description','birthday'),

('Brené Brown','image','description','birthday'),
('Dale Carnegie','image','description','birthday'),
('Stephen R. Covey','image','description','birthday'),
('Don Miguel Ruiz','image','description','birthday'),
('Janet Mills','image','description','birthday'),
('Marie Kondo','image','description','birthday'),
('Discover Press','image','description','birthday'),
('Susan Cain','image','description','birthday'),
('Eckhart Tolle','image','description','birthday'),
('Jen Sincero','image','description','birthday'),

('Chloe Liese','image','description','birthday'),
('Frank Murphy','image','description','birthday'),
('Surya Bonaly','image','description','birthday'),
('Gia De Cadenet','image','description','birthday'),
('Mariana Zapata','image','description','birthday'),
('Lucy Score','image','description','birthday'),
('A. L. Graziadei','image','description','birthday'),
('John Grisham','image','description','birthday'),
('Sarah Adams','image','description','birthday'),
('Denise Williams','image','description','birthday'),
('James Patterson','image','description','birthday'),
('Mike Lupica','image','description','birthday')
go

insert into Author_Book values
-- ('book_id','author_id')

(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,6),
(7,7),
(8,8),
(9,9),
(9,10),
(10,11),

(11,12),
(12,13),
(13,14),
(14,15),
(14,16),
(15,17),
(16,18),
(17,19),
(18,20),
(19,21),
(20,22),

(21,23),
(22,24),
(23,25),
(24,26),
(25,27),
(26,28),
(27,29),
(28,30),
(29,31),
(30,32),

(31,33),
(32,34),
(33,35),
(34,36),
(34,37),
(35,33),
(36,38),
(37,39),
(38,40),
(39,41),
(40,42),

(41,43),
(42,44),
(42,45),
(43,46),
(44,47),
(45,48),
(46,49),
(47,50),
(48,51),
(49,52),
(50,53),
(50,54)
go

insert into Review values
-- ('text','star','created_at','book_id','user_id')
go

insert into Comment values
-- ('text','review_id','blog_id','parent_id','created_at','user_id')
go

insert into Blog values
-- ('text','created_at','user_id')
go

insert into Shelf values
-- ('page','progress_read','book_id','user_id')
go

insert into [Like] values
-- ('author_id','blog_id','review_id','comment_id','user_id')
go
