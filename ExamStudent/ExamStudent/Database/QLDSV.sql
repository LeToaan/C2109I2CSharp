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
	 depId INT DEFAULT 1,
)
GO


DROP TABLE IF EXISTS tblExam
CREATE TABLE tblExam
(
	examId INT PRIMARY KEY IDENTITY,
	examName NVARCHAR(50) NOT NULL,
	examMark DECIMAL(4,2),
	examDate NVARCHAR(50) NOT NULL,
	stuId INT IDENTITY,
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

ALTER TABLE tblDepartment
ADD CONSTRAINT FK_tblDepartment_tblSubject
FOREIGN KEY (subjectId)
REFERENCES tblSubject(subjectId)
GO

ALTER TABLE tblSubject
ADD CONSTRAINT FK_tblSubject_tblTeacher
FOREIGN KEY (teachId)
REFERENCES tblTeacher(teachId)
GO



ALTER TABLE tblTeacher
ADD CONSTRAINT FK_tblTeacher_tblAccount
FOREIGN KEY (accId)
REFERENCES tblAccount(accId)
GO


INSERT INTO tblAccount (Username,[Password]) VALUES(N'admin', N'0123456')
INSERT INTO tblTeacher(fullName, accId) VALUES(N'LE THAI TOAN',1)

INSERT INTO tblSubject(subName, teachId) VALUES(N'CSHARP', 1)
INSERT INTO tblDepartment(depName, subjectId) VALUES(N'CNTT',1)
INSERT INTO tblCourse(couName, couSemester) VALUES(N'ADSE', N'THREE')
INSERT INTO tblStudent(stuCode,stuName,stuGender, stuDob, stuAddress, stuPhone, stuEmail, depId)
VALUES(N'SV001', N'TRUNG NGHI',1,'01/01/2003', N'LONG AN', N'0123456678', N'NGHI@GMAIL.COM', 1)
INSERT INTO tblExam(examName, examMark, examDate, stuId, couId) VALUES(N'QLSV', 6.5, '22/1/2022',1,1)



