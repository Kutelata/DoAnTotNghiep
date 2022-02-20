create database Book_Social_DB
go

use Book_Social_DB
go

create table [Role]
(
	id int identity primary key,
	[name] nvarchar(max)
)
go

create table [User]
(
	id int identity primary key,
	[name] nvarchar(max),
	phone nvarchar(max),
	email nvarchar(max),
	account nvarchar(max),
	[password] nvarchar(max),
	[image] nvarchar(max),
	[address] nvarchar(max),
	[description] nvarchar(max)
)
go

create table [Group]
(
	id int identity primary key,
	[name] nvarchar(max),
	[description] nvarchar(max),
	[rule] nvarchar(max),
	[user_id] nvarchar(max),
	created_at datetime
)
go

create table Blog
(
	id int identity primary key,
	created_at datetime,
	[text] nvarchar(max),
	group_id int foreign key references [Group](id),
	[user_id] int foreign key references [User](id)
)
go

create table Comment
(
	id int identity primary key,
	[text] nvarchar(max),
	created_at datetime,
	parent_id int,
	[blog_id] int foreign key references Blog(id),
	[user_id] int foreign key references [User](id)
)
go

create table [Like]
(
	[blog_id] int,
	comment_id int,
	[user_id] int
)
go

create table Book
(
	id int primary key identity,
	isbn int,
	[name] nvarchar(max),
	[image] nvarchar(max),
	[description] nvarchar(max),
	[page_number] int,
	published datetime,
	[language] nvarchar(max),
	author_id int foreign key references [Author](id)
)
go

create table Author
(
	id int primary key identity,
	[name] nvarchar(max),
	[image] nvarchar(max),
	[description] nvarchar(max),
	birthday datetime,
)
go

create table Progress_Book
(
	id int primary key identity,
	[name] nvarchar(max),
)

create table User_Book
(
	[user_id] int foreign key references [User](id),
	[book_id] int foreign key references Book(id),
	progress_book_id int foreign key references Progress_Book(id),
)
go






