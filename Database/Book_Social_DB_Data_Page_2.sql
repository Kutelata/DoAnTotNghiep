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

insert into Friend values
-- ('user_id','user_friend_id')

(7,8),
(8,7),
(7,9),
(10,7),

(7,11),
(11,7),
(7,12),
(13,7),

(7,14),
(14,7),
(7,15),
(16,7),

(7,17),
(17,7),
(7,18),
(19,7),

(7,20),
(20,7),
(7,21),
(22,7),

(7,23),
(23,7),
(7,24),
(25,7),

(7,26),
(26,7),
(7,27),
(28,7)
go

insert into Shelf values
-- ('progress_read','book_id','user_id')

(0,1,7),
(1,2,7),
(2,3,7),
(0,4,7),
(1,5,7),
(2,6,7),
(0,7,7),
(1,8,7),
(2,9,7),
(0,10,7),

(1,11,11),
(2,12,11),
(0,13,11),
(1,14,11),
(2,15,11),
(0,16,11),
(1,17,11),
(2,18,11),
(0,19,11),
(1,20,11)
go

insert into Review values
-- ('text','star','created_at','book_id','user_id')

(N'Tôi vẫn đang đọc cuốn sách này, chương đầu của nó thật tuyệt',0,'2010-01-01',1,7),
(N'Cuốn sách này quá tệ, không mấy ấn tượng đối với tôi',1,'2002-02-02',1,8),
(N'Nội dung giống như nhiều cuốn sách khác, không có sự sáng tạo',2,'2003-03-03',1,9),
(N'Cuốn sách khá hay nhưng tôi không thích cái kết lắm',3,'2004-04-04',1,10),
(N'Cho 4 sao để khuyến khích tác giả làm bìa đẹp hơn',4,'2005-05-05',1,11),
(N'Quá tuyệt vời, cuốn sách này sẽ nằm trong những cuốn sách yêu thích của tôi',5,'2006-06-06',1,12),

(N'Tôi vẫn đang đọc cuốn sách này, chương đầu của nó thật tuyệt',0,'2001-01-01',2,7),
(N'Cuốn sách này quá tệ, không mấy ấn tượng đối với tôi',1,'2002-02-02',2,8),
(N'Nội dung giống như nhiều cuốn sách khác, không có sự sáng tạo',2,'2003-03-03',2,9),
(N'Cuốn sách khá hay nhưng tôi không thích cái kết lắm',3,'2004-04-04',2,10),
(N'Cho 4 sao để khuyến khích tác giả làm bìa đẹp hơn',4,'2005-05-05',2,11),
(N'Quá tuyệt vời, cuốn sách này sẽ nằm trong những cuốn sách yêu thích của tôi',5,'2006-06-06',2,12),

(N'Tôi vẫn đang đọc cuốn sách này, chương đầu của nó thật tuyệt',0,'2001-01-01',3,7),
(N'Cuốn sách này quá tệ, không mấy ấn tượng đối với tôi',1,'2002-02-02',3,8),
(N'Nội dung giống như nhiều cuốn sách khác, không có sự sáng tạo',2,'2003-03-03',3,9),
(N'Cuốn sách khá hay nhưng tôi không thích cái kết lắm',3,'2004-04-04',3,10),
(N'Cho 4 sao để khuyến khích tác giả làm bìa đẹp hơn',4,'2005-05-05',3,11),
(N'Quá tuyệt vời, cuốn sách này sẽ nằm trong những cuốn sách yêu thích của tôi',5,'2006-06-06',3,12),

(N'Tôi vẫn đang đọc cuốn sách này, chương đầu của nó thật tuyệt',0,'2001-01-01',4,7),
(N'Cuốn sách này quá tệ, không mấy ấn tượng đối với tôi',1,'2002-02-02',4,8),
(N'Nội dung giống như nhiều cuốn sách khác, không có sự sáng tạo',2,'2003-03-03',4,9),
(N'Cuốn sách khá hay nhưng tôi không thích cái kết lắm',3,'2004-04-04',4,10),
(N'Cho 4 sao để khuyến khích tác giả làm bìa đẹp hơn',4,'2005-05-05',4,11),
(N'Quá tuyệt vời, cuốn sách này sẽ nằm trong những cuốn sách yêu thích của tôi',5,'2006-06-06',4,12),

(N'Tôi vẫn đang đọc cuốn sách này, chương đầu của nó thật tuyệt',0,'2001-01-01',5,7),
(N'Cuốn sách này quá tệ, không mấy ấn tượng đối với tôi',1,'2002-02-02',5,8),
(N'Nội dung giống như nhiều cuốn sách khác, không có sự sáng tạo',2,'2003-03-03',5,9),
(N'Cuốn sách khá hay nhưng tôi không thích cái kết lắm',3,'2004-04-04',5,10),
(N'Cho 4 sao để khuyến khích tác giả làm bìa đẹp hơn',4,'2005-05-05',5,11),
(N'Quá tuyệt vời, cuốn sách này sẽ nằm trong những cuốn sách yêu thích của tôi',5,'2006-06-06',5,12)
go

insert into Comment values
-- ('text','created_at','review_id','user_id')

(N'Tôi thích bình luận này','2000-01-11',1,7),
(N'Bài viết rất đúng ý tôi','2001-02-12',1,8),
(N'Tôi không đồng ý quan điểm này','2002-03-13',1,9),
(N'Bài viết rất hay, giải thích đúng với nội dung của sách','2003-04-14',1,10),
(N'Bạn nên đăng bài nhiều hơn','2022-05-15',1,11),

(N'Tôi thích bình luận này','2004-06-16',2,12),
(N'Bài viết rất đúng ý tôi','2005-07-17',2,13),
(N'Tôi không đồng ý quan điểm này','2006-08-18',2,14),
(N'Bài viết rất hay, giải thích đúng với nội dung của sách','2007-09-19',2,15),
(N'Bạn nên đăng bài nhiều hơn','2008-10-20',2,16),

(N'Tôi thích bình luận này','2009-11-21',3,17),
(N'Bài viết rất đúng ý tôi','2010-12-22',3,18),
(N'Tôi không đồng ý quan điểm này','2011-01-23',3,19),
(N'Bài viết rất hay, giải thích đúng với nội dung của sách','2012-02-24',3,20),
(N'Bạn nên đăng bài nhiều hơn','2013-03-25',3,21)
go