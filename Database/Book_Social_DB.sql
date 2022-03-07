create database Book_Social_DB
go

use Book_Social_DB
go

create table [Role]
(
	id int identity primary key,
	[name] nvarchar(50) unique not null,
	is_admin bit default(0)
)
go

create table Permission
(
	id int identity primary key,
	[name] nvarchar(50) unique not null, -- Controller-Action
)
go

create table Role_Permission
(
	role_id int foreign key references [Role](id),
	permission_id int foreign key references Permission(id)
)

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
	gender bit default(0),
	friend varchar(max),
	[status] bit default(0),
	role_id int foreign key references [Role](id)
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

create table Progress_Read
(
	id int primary key identity,
	[name] nvarchar(50) unique not null,
)

create table Article
(
	id int identity primary key,
	[text] nvarchar(max) not null,
	created_at datetime not null,
	parent_id int,
	level_id int,
	[book_id] int,
	[user_id] int,
	progress_read_id int,
	review int
)
go

create table [Like]
(
	author_id int,
	article_id int,
	[user_id] int,
)
go
