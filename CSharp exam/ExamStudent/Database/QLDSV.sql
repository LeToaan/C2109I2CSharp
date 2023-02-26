USE MASTER
GO

DROP DATABASE IF EXISTS ExamStudent
CREATE DATABASE ExamStudent
GO

USE ExamStudent
GO

DROP TABLE IF EXISTS tblStudent
CREATE TABLE tblStudent
(
	stuId INT PRIMARY KEY IDENTITY,
	stuCode NVARCHAR(50) NOT NULL,
	 stuPass bit default 0,
	 stuName NVARCHAR(50) NOT NULL,
	 stuAddress NVARCHAR(50),
	 stuPhone NVARCHAR(50),
	 stuEmail NVARCHAR(50),
	 stuStatus bit default 1,
	 depId INT DEFAULT 1,
)
GO


DROP TABLE IF EXISTS tblExam
CREATE TABLE tblExam
(
	examId INT PRIMARY KEY IDENTITY,
	examName NVARCHAR(50) NOT NULL,
	examMark DECIMAL(4,2),
	examDate DATE NOT NULL,
	stuId INT,
	couId INT Default 1,
)
GO

DROP TABLE IF EXISTS tblCourse
CREATE TABLE tblCourse
(
	couId INT PRIMARY KEY IDENTITY,
	couName NVARCHAR(50) NOT NULL,
	couSemester NVARCHAR(50),
)
GO

DROP TABLE IF EXISTS tblDepartment
CREATE TABLE tblDepartment
(
	depId INT PRIMARY KEY IDENTITY,
	depName NVARCHAR(50) NOT NULL,
	subjectId Int,

)
GO

DROP TABLE IF EXISTS tblSubject
CREATE TABLE tblSubject
(
	subjectId INT PRIMARY KEY IDENTITY,
	subName NVARCHAR(50) NOT NULL,
	teachId INT NOT NULL,

)
GO


DROP TABLE IF EXISTS tblTeacher
CREATE TABLE tblTeacher
(
teachId INT IDENTITY PRIMARY KEY,
fullName NVARCHAR(50) NOT NULL,
accId INT NOT NULL,
)
GO



DROP TABLE IF EXISTS tblAccount
CREATE TABLE tblAccount
(
	accId INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
)
GO


ALTER TABLE tblTeacher
ADD CONSTRAINT FK_tblTeacher_tblAccount
FOREIGN KEY (accId)
REFERENCES tblAccount(accId)
GO

ALTER TABLE tblSubject
ADD CONSTRAINT FK_tblSubject_tblTeacher
FOREIGN KEY (teachId)
REFERENCES tblTeacher(teachId)
GO

ALTER TABLE tblDepartment
ADD CONSTRAINT FK_tblDepartment_tblSubject
FOREIGN KEY (subjectId)
REFERENCES tblSubject(subjectId)
GO

ALTER TABLE tblExam
ADD CONSTRAINT FK_tblExam_tblStudent
FOREIGN KEY (stuId)
REFERENCES tblStudent(stuId)
GO

ALTER TABLE tblExam
ADD CONSTRAINT FK_tblExam_tblCourse
FOREIGN KEY (couId)
REFERENCES tblCourse(CouId)
GO

ALTER TABLE tblStudent
ADD CONSTRAINT FK_tblStudent_tblDepartment_
FOREIGN KEY(depId)
REFERENCES tblDepartment(depId)
GO


CREATE PROC InsertStudent
@stuCode nvarchar(50), @stuName nvarchar(50),  @stuAddress nvarchar(50),@stuPhone nvarchar(50), @stuEmail nvarchar(50), 
@examName nvarchar(50), @examMark decimal(4,2), @examDate DATE
as
begin

declare @stuId int



	insert into tblStudent(stuCode, stuName, stuAddress, stuPhone, stuEmail)
	values(@stuCode, @stuName, @stuAddress, @stuPhone, @stuEmail)

	SELECT @stuId = stuId FROM tblStudent where (stuName = @stuName or stuName is Null  ) and (stuAddress=@stuAddress or stuAddress is null)
	ORDER BY stuId DESC 
	OFFSET 0 ROWS 
	FETCH NEXT 1 ROWS ONLY

	insert into tblExam(examName, examMark, examDate,stuId)
	values (@examName, @examMark, @examDate,@stuId)
	
end
go

CREATE PROC UpdateStu
@stuCode nvarchar(50), @stuName nvarchar(50),  @stuAddress nvarchar(50),@stuPhone nvarchar(50), @stuEmail nvarchar(50), 
@examName nvarchar(50), @examMark decimal(4,2), @examDate DATE, @stuId INT, @examId INT
AS
BEGIN
	UPDATE tblStudent
	SET stuCode = @stuCode, stuName = @stuName, stuAddress = @stuAddress, stuPhone = @stuPhone, stuEmail = @stuEmail
	WHERE stuId = @stuId

	UPDATE tblExam 
	SET examName = @examName, examMark = @examMark, examDate = @examDate
	WHERE examId = @examId
END
GO
 
 CREATE PROC DeleteStu
@stuId int
 AS
 BEGIN
 
 Update tblStudent
 set stuStatus = 0
 where stuId = @stuId
 END
 GO

 INSERT INTO tblAccount (Username,[Password]) VALUES(N'admin', N'0123456')
INSERT INTO tblTeacher(fullName, accId) VALUES(N'LE THAI TOAN',1)

INSERT INTO tblSubject(subName, teachId) VALUES(N'CSHARP', 1)
INSERT INTO tblDepartment(depName, subjectId) VALUES(N'CNTT',1)
INSERT INTO tblCourse(couName, couSemester) VALUES(N'ADSE', N'THREE')
INSERT INTO tblStudent(stuCode,stuName, stuAddress, stuPhone, stuEmail, depId)
VALUES(N'SV001', N'TRUNG NGHI', N'LONG AN', N'0123456678', N'NGHI@GMAIL.COM', 1)
INSERT INTO tblExam(examName, examMark, examDate, stuId, couId) VALUES(N'QLSV', 3.5, '2022/01/15',1,1)