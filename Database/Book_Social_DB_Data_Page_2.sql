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
(35,37),
(36,38),
(37,39),
(38,40),
(39,41),
(40,42),

(41,43),
(42,44),
(43,45),
(44,46),
(45,47),
(46,48),
(47,49),
(48,50),
(49,51),
(50,52)
go

insert into User_Review values
-- ('text','review','created_at','book_id','user_id')
go

insert into User_Comment values
-- ('text','user_review_id','user_blog_id','parent_id','created_at','user_id')
go

insert into User_Blog values
-- ('text','created_at','user_id')
go

insert into User_Shelf values
-- ('page','progress_read_id','book_id','user_id')
go

insert into User_Like values
-- ('author_id','user_blog_id','user_review_id','user_comment_id','user_id')
go
