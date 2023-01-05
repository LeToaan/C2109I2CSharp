use master
go

drop database if exists WFC2109I2
create database WFC2109I2
go

use WFC2109I2
go

drop table if exists Student
create table Student
(
	Id int primary key identity,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Gender bit,
	Dob date,

)

insert into Student(FirstName, LastName, Gender, Dob)
Values(N'Le', N'Thai', 1, '2003/9/27')
go 10