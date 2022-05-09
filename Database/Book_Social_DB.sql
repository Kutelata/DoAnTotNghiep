create database Book_Social_DB
go

use Book_Social_DB
go

create table [User]
(
	id int identity primary key,
	[name] nvarchar(max) not null,
	phone varchar(max),
	email varchar(max),
	account nvarchar(50) unique not null,
	[password] nvarchar(max) not null,
	[image] varchar(450),
	[address] nvarchar(max),
	[description] nvarchar(max),
	birthday datetime,
	gender tinyint default(0),
	[status] tinyint default(0),
	[role] tinyint default(0)
)
go

create unique nonclustered index UQ_User_Image on [User]([image]) where [image] != '' and [image] is not null
go

create table Friend 
(
	[user_id] int,
	user_friend_id int
)
go

create table Author
(
	id int primary key identity,
	[name] nvarchar(max) not null,
	[image] varchar(450),
	[description] nvarchar(max),
	birthday datetime,
)
go

create unique nonclustered index UQ_Author_Image on Author([image]) where [image] != '' and [image] is not null
go

create table Genre
(
	id int primary key identity,
	[name] nvarchar(50) unique not null 
)
go

create table Book
(
	id int primary key identity,
	isbn varchar(50) unique not null,
	[name] nvarchar(max) not null,
	[image] varchar(450),
	[description] nvarchar(max),
	page_number int default(0),
	published datetime,
	genre_id int foreign key references Genre(id)
)
go

create unique nonclustered index UQ_Book_Image on Book([image]) where [image] != '' and [image] is not null
go

create table Author_Book
(
	book_id int foreign key references Book(id),
	author_id int foreign key references Author(id)
)
go

create table Review
(
	id int identity primary key,
	[text] nvarchar(max) not null,
	star tinyint default(0),
	created_at datetime not null,
	book_id int,
	[user_id] int
)
go

create table Comment
(
	id int identity primary key,
	[text] nvarchar(max) not null,
	created_at datetime not null,
	review_id int,
	[user_id] int
)
go

create table Shelf
(
	progress_read tinyint default(0),
	book_id int foreign key references Book(id),
	[user_id] int foreign key references [User](id),
)
