USE MASTER
GO

DROP DATABASE IF EXISTS Student
CREATE DATABASE Student
GO

USE Student
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

INSERT INTO tblDepartment(depName) VALUES(N'CNTT')
INSERT INTO tblCourse(couName, couSemester) VALUES(N'ADSE', N'THREE')
INSERT INTO tblStudent(stuCode,stuName, stuAddress, stuPhone, stuEmail, depId)
VALUES(N'SV001', N'TRUNG NGHI', N'LONG AN', N'0123456678', N'NGHI@GMAIL.COM', 1)
INSERT INTO tblExam(examName, examMark, examDate, stuId, couId) VALUES(N'QLSV', 3.5, '2022/01/15',1,1)

SELECT tblStudent.stuId, stuCode, stuName, stuAddress, stuPhone, stuEmail, examId, examName, examMark, examDate, depName, couName, couSemester FROM tblStudent	 INNER JOIN tblDepartment ON tblDepartment.depId = tblStudent.depId INNER JOIN tblExam ON tblExam.stuId = tblStudent.stuId INNER JOIN tblCourse ON tblCourse.couId = tblExam.couId