create database BookSocial
go

use BookSocial
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
)
go

create table Blog
(
	id int identity primary key,
	created datetime,

	
)
go

create table Comment
(
	id int identity primary key,
)
go

create table Book
(
	id int identity primary key,
	title nvarchar(max),
	author nvarchar(max),
)
go

create table [Group]
(
	id int identity primary key,
)
go




