create database Book_Social_DB
go

use Book_Social_DB
go

create table Role
(
	id int primary key identity,
	name nvarchar(max) not null
)
go

create table [User]
(
	id int identity primary key,
	[name] nvarchar(max) not null,
	phone varchar(max),
	email varchar(max),
	account nvarchar(50) unique not null,
	[password] nvarchar(max) not null,
	[image] varchar(max),
	[address] nvarchar(max),
	[description] nvarchar(max),
	[birthday] datetime,
	gender tinyint,
	friend varchar(max),
	[status] tinyint,
	[role_id] int foreign key references [Role](id)
)
go

create table Author
(
	id int primary key identity,
	[name] nvarchar(max) not null,
	[image] varchar(max),
	[description] nvarchar(max),
	birthday datetime,
)
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
	isbn varchar(50) unique,
	[name] nvarchar(max) not null,
	[image] varchar(max),
	[description] nvarchar(max),
	[page_number] int,
	published datetime,
	[language] nvarchar(max),
	genre_id int foreign key references Genre(id)
)
go

create table Author_Book
(
	book_id int foreign key references Book(id),
	author_id int foreign key references Author(id)
)
go

create table User_Review
(
	id int identity primary key,
	[text] nvarchar(max),
	review int,
	created_at datetime not null,
	[book_id] int foreign key references Book(id),
	[user_id] int foreign key references [User](id)
)
go

create table User_Comment
(
	id int identity primary key,
	[text] nvarchar(max) not null,
	user_review_id int,
	user_blog_id int,
	parent_id int,
	created_at datetime not null,
	[user_id] int foreign key references [User](id)
)
go

create table User_Blog
(
	id int identity primary key,
	[text] nvarchar(max) not null,
	created_at datetime not null,
	[user_id] int foreign key references [User](id)
)
go

create table User_Shelf
(
	[book_id] int foreign key references Book(id),
	[page] int,
	progress_read_id tinyint,
	[user_id] int foreign key references [User](id),
)

create table [Like]
(
	author_id int,
	user_blog_id int,
	user_review_id int,
	user_comment int,
	[user_id] int,
)
go
