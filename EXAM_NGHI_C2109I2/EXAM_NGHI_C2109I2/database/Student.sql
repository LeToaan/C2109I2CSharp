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



CREATE PROC InsertStu
@stuCode nvarchar(50), @stuName nvarchar(50),  @stuAddress nvarchar(50),@stuPhone nvarchar(50), @stuEmail nvarchar(50), 
@examName nvarchar(50), @examMark decimal(4,2), @examDate DATE
as
begin

DECLARE @stuId INT



	INSERT INTO tblStudent(stuCode, stuName, stuAddress, stuPhone, stuEmail)
	VALUES(@stuCode, @stuName, @stuAddress, @stuPhone, @stuEmail)

	SELECT @stuId = stuId FROM tblStudent where (stuName = @stuName or stuName is Null  ) and (stuAddress=@stuAddress or stuAddress is null)
	ORDER BY stuId DESC 
	OFFSET 0 ROWS 
	FETCH NEXT 1 ROWS ONLY

	INSERT INTO tblExam(examName, examMark, examDate,stuId)
	VALUES (@examName, @examMark, @examDate,@stuId)
	
end
go

CREATE PROC UpdateStu
@stuId INT, @examId INT
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
@examId int,@stuId int
 AS
 BEGIN
 
 DELETE FROM tblExam
 Where examId = @examId

 DELETE FROM tblStudent
 where stuId = @stuId
 END
 GO

INSERT INTO tblDepartment(depName) VALUES(N'QTKD')
INSERT INTO tblCourse(couName, couSemester) VALUES(N'2022', N'4')
INSERT INTO tblStudent(stuCode,stuName, stuAddress, stuPhone, stuEmail, depId)
VALUES(N'SV1', N'Le TOAN', N'Binh Thuan', N'0147852369', N'TOAN@GMAIL.COM', 1)
INSERT INTO tblExam(examName, examMark, examDate, stuId, couId) VALUES(N'EXAM', 3.5, '2023/02/09',1,1)