Create database SMStudent

use master

drop database SMSData


create table UserTypeTable(
 ID int primary key identity not null,
 TypeName nvarchar(200) unique not null,
 [Description] nvarchar(500) null,
 IsActive bit default 1 not null,
 EditDate Datetime null
)
drop table UserTable
create table UserTable(
 ID int primary key identity not null,
 UserType_ID int not null,
 Gender_ID int not null,
 Nationality_ID int not null,
 Religious_ID int not null,
 PostOffice_ID int not null,
 FullName nvarchar(200) not null,
 Username nvarchar(200) unique not null,
 [Password] nvarchar(200) not null,
 Photo nvarchar(max) null,
 ContactNO nvarchar(100) not null,
 EmailAddress nvarchar(200) not null,
 [Address] nvarchar(500) not null,
 IsActive bit default 1 not null,
 EditDate Datetime null
)

ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_UserTable_UserTypeTable] FOREIGN KEY([UserType_ID])
REFERENCES [dbo].[UserTypeTable] ([ID])
ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_UserTable_GenderTable] FOREIGN KEY([Gender_ID])
REFERENCES [dbo].[GenderTable] ([ID])

ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_UserTable_Nationality] FOREIGN KEY([Nationality_ID])
REFERENCES [dbo].[Nationality] ([ID])
ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_UserTable_ReligiousTable] FOREIGN KEY([Religious_ID])
REFERENCES [dbo].[ReligiousTable] ([ID])
ALTER TABLE [dbo].[UserTable]  WITH CHECK ADD  CONSTRAINT [FK_UserTable_PostOffice] FOREIGN KEY([PostOffice_ID])
REFERENCES [dbo].[PostOffice] ([ID])

drop table TeacherTable
create table TeacherTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 Gender_ID int not null,
 Nationality_ID int not null,
 Religious_ID int not null,
 PostOffice_ID int not null,
 ContactNO nvarchar(200) not null,
 BasicSalary float not null,
 EmailAddress nvarchar(200) not null,
 [Address] nvarchar(500) not null,
 Qualification nvarchar(200) not null,
 Photo nvarchar(500) null,
 [Description] nvarchar(500) null,
 IsActive bit default 1 not null,
 HomePhone nvarchar(200) not null,
 RegistrationDate datetime null,
 EditDate datetime null,
 Username nvarchar(200) unique not null,
 [Password] varchar(max) not null,
 [Name] nvarchar(200) not null,
)
alter table TeacherTable
add [Name] nvarchar(max) 

ALTER TABLE [dbo].[TeacherTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[TeacherTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTable_GenderTable] FOREIGN KEY([Gender_ID])
REFERENCES [dbo].[GenderTable] ([ID])

ALTER TABLE [dbo].[TeacherTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTable_Nationality] FOREIGN KEY([Nationality_ID])
REFERENCES [dbo].[Nationality] ([ID])
ALTER TABLE [dbo].[TeacherTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTable_ReligiousTable] FOREIGN KEY([Religious_ID])
REFERENCES [dbo].[ReligiousTable] ([ID])
ALTER TABLE [dbo].[TeacherTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherTable_PostOffice] FOREIGN KEY([PostOffice_ID])
REFERENCES [dbo].[PostOffice] ([ID])

drop table ClassRoutinelTable

create table ClassRoutinelTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 Teacher_ID int not null,
 Class_ID int not null,
 SessionID int null,
 Division_ID int not null,
 Student_ID int not null,
 SubJect_ID int not null,
 StartTime time not null,
 EndTime time not null,
 [Day] varchar(200) not null,
 IsActive bit default 1 not null,
 EditDate datetime null
)
alter table ClassRoutinelTable
add Subject_ID int not null
alter table ClassRoutinelTable
alter column Student_ID int not null


ALTER TABLE [dbo].[ClassRoutinelTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoutinelTable_SubjectTable] FOREIGN KEY([Subject_ID])
REFERENCES [dbo].[SubjectTable] ([ID])

ALTER TABLE [dbo].[ClassRoutinelTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoutinelTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[ClassRoutinelTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoutinelTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])

ALTER TABLE [dbo].[ClassRoutinelTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoutinelTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[ClassRoutinelTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoutinelTable_SessionTable] FOREIGN KEY([SessionID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[ClassRoutinelTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoutinelTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])
ALTER TABLE [dbo].[ClassRoutinelTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassRoutinelTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

create table TuisionFeeTable(
 ID int primary key identity not null,
 [User_ID] int not null,
 Class_ID int not null,
 Student_ID int not null,
 Division_ID int not null,
 Session_ID int not null,
 Amount float not null,
 SubmissionDate date not null,
 FeesMonth nvarchar(200) not null,
 [Description] nvarchar(500) null,
 IsActive bit default 1 not null,
 EditDate datetime null,
)
ALTER TABLE [dbo].[TuisionFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_TuisionFeeTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[TuisionFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_TuisionFeeTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[TuisionFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_TuisionFeeTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[TuisionFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_TuisionFeeTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])
ALTER TABLE [dbo].[TuisionFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_TuisionFeeTableTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

create table SubjectTable(
 ID int primary key identity not null,
 [User_ID] int not null,
 Class_ID int not null,
 Division_ID int not null,
 Session_ID int not null,
 [Name] nvarchar(200) not null,
 IsActive bit default 1 not null,
 EditDate datetime null
)
alter table SubjectTable
add Session_ID int null

ALTER TABLE [dbo].[SubjectTable]  WITH CHECK ADD  CONSTRAINT [FK_SubjectTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[SubjectTable]  WITH CHECK ADD  CONSTRAINT [FK_SubjectTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[SubjectTable]  WITH CHECK ADD  CONSTRAINT [FK_SubjectTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[SubjectTable]  WITH CHECK ADD  CONSTRAINT [FK_SubjectTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])


create table StudentTable(
 ID int primary key identity not null,
 Session_ID int not null,
 Division_ID int not null,
 Class_ID int not null,
 [User_ID] int  null,
 Kota_ID int not null,
 Gender_ID int not null,
 Nationality_ID int not null,
 FatherProffesion_ID int not null,
 Religious_ID int not null,
 PostOffice_ID int not null,
 IsActive bit default 1 not null,
 [Name] nvarchar(200) not null,
 RollNumber nvarchar(200) unique not null,
 FatherName nvarchar(200) not null,
 MotherName nvarchar(200) not null,
 DateOfBirth date not null,
 ContactNo nvarchar(200) not null,
 AdmissionDate date not null,
 CNIC nvarchar(200) null,
 FNIC nvarchar(200) null,
 Photo nvarchar(max) null,
 VaccinationCard_Photo nvarchar(max) null,
 Birth_Certificate_Photo nvarchar(max) null,
 Previous_School_Marksheet_Photo nvarchar(max) null,
 Previous_School_Certificate_Photo nvarchar(max) null,
 Previous_CGPA nvarchar(200) null,
 Previous_School_Name nvarchar(300) null,
 EmailAddress nvarchar(200) not null,
 [Address] nvarchar(500) not null,
 FatherPostalAddress nvarchar(500),
 FatherPhone nvarchar(200) null,
 FatherEmailAddress nvarchar(500) not null,
 EditDate datetime null,
 Username nvarchar(200) not null,
 [Password] nvarchar(max) not null
)

alter table StudentTable
add Username nvarchar(200) unique null
alter table StudentTable 
add [Password] nvarchar(200) not null

ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])

ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_Kota] FOREIGN KEY([Kota_ID])
REFERENCES [dbo].[Kota] ([ID])
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_GenderTable] FOREIGN KEY([Gender_ID])
REFERENCES [dbo].[GenderTable] ([ID])
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_Nationality] FOREIGN KEY([Nationality_ID])
REFERENCES [dbo].[Nationality] ([ID])
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_FatherProfesion] FOREIGN KEY([FatherProffesion_ID])
REFERENCES [dbo].[FatherProfesion] ([ID])

ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_ReligiousTable] FOREIGN KEY([Religious_ID])
REFERENCES [dbo].[ReligiousTable] ([ID])
ALTER TABLE [dbo].[StudentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentTable_PostOffice] FOREIGN KEY([PostOffice_ID])
REFERENCES [dbo].[PostOffice] ([ID])

Create table GenderTable(
 ID int identity primary key not null,
 [Name] nvarchar(200) not null
)

Create table Kota(
 ID int identity primary key not null,
 [Name] nvarchar(200) not null,
 EditDate datetime null
)
Create table Nationality(
 ID int identity primary key not null,
 [Name] nvarchar(200) not null
)
Create table FatherProfesion(
 ID int identity primary key not null,
 [Name] nvarchar(200) not null,
 EditDate datetime null
)
Create table PostOffice(
 ID int identity primary key not null,
 [Name] nvarchar(200) not null,
 PostalCode int not null,
 EditDate datetime null
)

create table StudentAnnualFeeTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 Student_ID int not null,
 Class_ID int not null,
 Division_ID int not null,
 SubmisionDate date not null,
 AnnualFee float not null,
 IsActive bit default 1 not null,
 IsSubmit bit default 1 not null,
 EditDate datetime null
)

ALTER TABLE [dbo].[StudentAnnualFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnnualFeeTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[StudentAnnualFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnnualFeeTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[StudentAnnualFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnnualFeeTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])

ALTER TABLE [dbo].[StudentAnnualFeeTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAnnualFeeTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])


create table TeacherAttendanceTable(
 ID int identity primary key not null,
 Teacher_ID int not null,
 AttendDate date not null,
 ComingTime nvarchar(200) not null,
 ClosingTime nvarchar(200) not null,
 EditDate datetime null,
 IsActive bit default 1 not null
)
alter table TeacherAttendanceTable
alter column ComingTime nvarchar(200) null

alter table TeacherAttendanceTable
alter column ClosingTime nvarchar(200) null

alter table TeacherAttendanceTable
add [User_ID] int null


ALTER TABLE [dbo].[TeacherAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherAttendanceTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])

ALTER TABLE [dbo].[TeacherAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherAttendanceTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])

create table UserAttendanceTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 AttendDate date not null,
 ComingTime time not null,
 ClosingTime time not null,
 EditDate datetime null,
 IsActive bit default 1 not null
)

ALTER TABLE [dbo].[UserAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_UserAttendanceTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])

ALTER TABLE [dbo].[StaffAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_StaffAttendanceTable_UserTable] FOREIGN KEY([Staff_ID])
REFERENCES [dbo].[StaffTable] ([ID])

create table SessionTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 [Name] nvarchar(200) not null,
 StartDate date not null,
 EndDate date not null,
  EditDate datetime null,
 IsActive bit default 1 not null
)

ALTER TABLE [dbo].[SessionTable]  WITH CHECK ADD  CONSTRAINT [FK_SessionTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])


create table DivisionTable(
 ID int identity primary key not null,
 [Name] nvarchar(200) not null,
 [User_ID] int null,
 Teacher_ID int null,
 EditDate datetime null,
 IsActive bit default 1 not null
 )
 ALTER TABLE [dbo].[DivisionTable]  WITH CHECK ADD  CONSTRAINT [FK_DivisionTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[DivisionTable]  WITH CHECK ADD  CONSTRAINT [FK_DivisionTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])



create table SchoolLeavingTable(
 ID int identity primary key not null,
 [User_ID] int  null,
 Student_ID int  null,
 Class_ID int  null,
 Teacher_ID int  null,
 Session_ID int null,
 LeavingDate datetime not null,
 LeavingReason nvarchar(500) not null,
 LeavingComments nvarchar(500) null,
 CreatedDate datetime  null,
 EditDate datetime null,
 IsActive bit default 1 not null
)

ALTER TABLE [dbo].[SchoolLeavingTable]  WITH CHECK ADD  CONSTRAINT [FK_SchoolLeavingTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[SchoolLeavingTable]  WITH CHECK ADD  CONSTRAINT [FK_SchoolLeavingTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])

ALTER TABLE [dbo].[SchoolLeavingTable]  WITH CHECK ADD  CONSTRAINT [FK_SchoolLeavingTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])
ALTER TABLE [dbo].[SchoolLeavingTable]  WITH CHECK ADD  CONSTRAINT [FK_SchoolLeavingTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])

create table ExtraCaricualActiviesTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 [Name] nvarchar(200) not null,
 StartDate datetime not null,
 EndDate datetime not null,
 EditDate datetime null,
 IsActive bit default 1 not null
)

ALTER TABLE [dbo].[ExtraCaricualActiviesTable]  WITH CHECK ADD  CONSTRAINT [FK_ExtraCaricualActiviesTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])

create table ExamTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 Session_ID int not null,
 Division_ID int not null,
 Class_ID int not null,
 Title nvarchar(200) not null,
 StartDate datetime not null,
 EndDate datetime not null,
 [Description] nvarchar(500) null
)

ALTER TABLE [dbo].[ExamTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[ExamTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[ExamTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[ExamTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])


create table ExamMarksTable(
 ID int identity primary key not null,
 Exam_ID int not null,
 Subject_ID int not null,
 Student_ID int not null,
 Class_ID int not null,
 Division_ID int not null,
 Session_ID int not null,
 [User_ID] int not null,
 Grade_ID int not null,
 TotalMarks float not null,
 ObtainsMarks float not null,
  EditDate datetime null,
 IsActive bit default 1 not null
)

ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_ExamTable] FOREIGN KEY([Exam_ID])
REFERENCES [dbo].[ExamTable] ([ID])
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])

ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_SubjectTable] FOREIGN KEY([Subject_ID])
REFERENCES [dbo].[SubjectTable] ([ID])
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[ExamMarksTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarksTable_GradeTable] FOREIGN KEY([Grade_ID])
REFERENCES [dbo].[GradeTable] ([ID])


create table GradeTable(
ID int identity Primary key not null,
[Name] varchar(200),
EditDate datetime null,
IsActive bit default 1 not null
)

create table EventTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 EventTitle nvarchar(200) not null,
 EventDate datetime not null,
 [Location] nvarchar(500) not null,
 [Description] nvarchar(500) null,
 EditDate datetime null,
IsActive bit default 1 not null
)

ALTER TABLE [dbo].[EventTable]  WITH CHECK ADD  CONSTRAINT [FK_EventTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])

create table ClassTable(
 ID int identity primary key not null,
 [User_ID] int null,
 Teacher_ID int null,
 [Name] nvarchar(200) not null,
 IsActive bit default 1 not null,
 EditDate datetime null,
)

ALTER TABLE [dbo].[ClassTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])

ALTER TABLE [dbo].[ClassTable]  WITH CHECK ADD  CONSTRAINT [FK_ClassTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[UserTable] ([ID])

create table StudentAttendanceTable(
 ID int identity primary key not null,
 Session_ID int not null,
 Student_ID int not null,
 Division_ID int not null,
 Class_ID int not null,
 AttendDate datetime not null,
 AttendTime Datetime not null,
 EditDate datetime null,
IsActive bit default 1 not null
)
alter table StudentAttendanceTable
add [User_ID] int null

alter table StudentAttendanceTable
add [Teacher_ID] int 


ALTER TABLE [dbo].[StudentAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendanceTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])

ALTER TABLE [dbo].[StudentAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendanceTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])

ALTER TABLE [dbo].[StudentAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendanceTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])

ALTER TABLE [dbo].[StudentAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendanceTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

ALTER TABLE [dbo].[StudentAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendanceTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])

ALTER TABLE [dbo].[StudentAttendanceTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendanceTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])



create table ExamFeelTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 Division_ID int not null,
 Class_ID int not null,
 Session_ID int not null,
 Student_ID int not null,
 Title nvarchar(200) not null,
 [Description] nvarchar(500) null,
 Fees float not null,
  EditDate datetime null,
 IsActive bit default 1 not null
)
alter table ExamFeelTable
add Student_ID int not null


ALTER TABLE [dbo].[ExamFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamFeelTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

ALTER TABLE [dbo].[ExamFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamFeelTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[ExamFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamFeelTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[ExamFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamFeelTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])

ALTER TABLE [dbo].[ExamFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_ExamFeelTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])

create table TransportationFeelTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 Division_ID int not null,
 Class_ID int not null,
 Session_ID int not null,
 Student_ID int not null,
 Title nvarchar(200) not null,
 [Description] nvarchar(500) null,
 Fees float not null,
 SubmissionDate datetime null,
 FeeofMonth varchar(200) null,
 EditDate datetime null,
 IsActive bit default 1 not null
)
alter table TransportationFeelTable
add Student_ID int not null


ALTER TABLE [dbo].[TransportationFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_TransportationFeelTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

ALTER TABLE [dbo].[TransportationFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_TransportationFeelTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[TransportationFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_TransportationFeelTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[TransportationFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_TransportationFeelTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])

ALTER TABLE [dbo].[TransportationFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_TransportationFeelTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])

create table StudyTourFeelTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 Division_ID int not null,
 Class_ID int not null,
 Session_ID int not null,
 Teacher_ID int null,
 Student_ID int not null,
 Title nvarchar(200) not null,
 [Description] nvarchar(500) null,
 StartDate datetime not null,
 EndDate datetime not null,
 Fees float not null,
 EditDate datetime null,
 IsActive bit default 1 not null
)

alter table  StudyTourFeelTable
add Student_ID int not null


ALTER TABLE [dbo].[StudyTourFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_StudyTourFeelTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

ALTER TABLE [dbo].[StudyTourFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_StudyTourFeelTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[StudyTourFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_StudyTourFeelTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[StudyTourFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_StudyTourFeelTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])

ALTER TABLE [dbo].[StudyTourFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_StudyTourFeelTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])

ALTER TABLE [dbo].[StudyTourFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_StudyTourFeelTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])

create table EstablishmentFeelTable(
 ID int identity primary key not null,
 [User_ID] int not null,
 Division_ID int not null,
 Class_ID int not null,
 Session_ID int not null,
 Student_ID int not null,
 Title nvarchar(200) not null,
 SubmissionDate datetime not null,
 Fees float not null,
 EditDate datetime null,
 IsActive bit default 1 not null
)
alter table EstablishmentFeelTable
add Student_ID int not null

ALTER TABLE [dbo].[EstablishmentFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_EstablishmentFeelTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])
ALTER TABLE [dbo].[EstablishmentFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_EstablishmentFeelTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[EstablishmentFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_EstablishmentFeelTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[EstablishmentFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_EstablishmentFeelTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])

ALTER TABLE [dbo].[EstablishmentFeelTable]  WITH CHECK ADD  CONSTRAINT [FK_EstablishmentFeelTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])


create table StudentDailyWorklTable(
 ID int identity primary key not null,
 Division_ID int not null,
 Class_ID int not null,
 Session_ID int not null,
 Teacher_ID int null,
 Title nvarchar(200) not null,
 SubmissionDate datetime not null,
 [Name] varchar(200) not null,
 [Description] varchar(max) null,
 EditDate datetime null,
 IsActive bit default 1 not null,
 Student_ID int not null
)

alter table StudentDailyWorklTable
add Student_ID int null


ALTER TABLE [dbo].[StudentDailyWorklTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentDailyWorklTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

ALTER TABLE [dbo].[StudentDailyWorklTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentDailyWorklTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[StudentDailyWorklTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentDailyWorklTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[StudentDailyWorklTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentDailyWorklTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])

ALTER TABLE [dbo].[StudentDailyWorklTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentDailyWorklTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])

create table meetingFixableTable(
ID int identity primary key not null,
[User_ID] int not null,
[Name] varchar(200) not null,
Reson varchar(200) null,
[Description] nvarchar(max) null,
IsActive bit default 1 not null,
EditTime datetime null
)

ALTER TABLE [dbo].[meetingFixableTable]  WITH CHECK ADD  CONSTRAINT [FK_meetingFixableTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])


create table TeacherFeedbackTable(
ID int identity primary key not null,
Teacher_ID int not null,
Student_ID int not null,
Class_ID int not null,
Session_ID int not null,
Comments nvarchar(max) not null,
IsActive bit default 1 not null,
EditTime datetime null
)

ALTER TABLE [dbo].[TeacherFeedbackTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherFeedbackTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[TeacherFeedbackTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherFeedbackTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[TeacherFeedbackTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherFeedbackTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

ALTER TABLE [dbo].[TeacherFeedbackTable]  WITH CHECK ADD  CONSTRAINT [FK_TeacherFeedbackTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])

Create table StudentAssignmentTable(
ID int identity primary key not null,
Student_ID int not null,
Class_ID int not null,
Session_ID int not null,
Division_ID int not null,
SubmisionDate datetime not null,
Subject_ID int not null,
[Name] varchar(200) null,
[Description] nvarchar(max) null,
Photo nvarchar(max) null,
IsActive bit default 1 not null,
EditTime datetime null
)
alter table StudentAssignmentTable
add Teacher_ID int null


ALTER TABLE [dbo].[StudentAssignmentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignmentTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])

ALTER TABLE [dbo].[StudentAssignmentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignmentTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[StudentAssignmentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignmentTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[StudentAssignmentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignmentTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

ALTER TABLE [dbo].[StudentAssignmentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignmentTable_SubjectTable] FOREIGN KEY([Subject_ID])
REFERENCES [dbo].[SubjectTable] ([ID])
ALTER TABLE [dbo].[StudentAssignmentTable]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignmentTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])
create table ApplicationForInstallmentTable(
ID int identity primary key not null,
[User_ID] int null,
Student_ID int not null,
Class_ID int not null,
Session_ID int not null,
Division_ID int not null,
[Description] varchar(max) not null,
SubmisionDate datetime not null,
IsActive bit default 1 not null,
EditTime datetime null
)

ALTER TABLE [dbo].[ApplicationForInstallmentTable]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationForInstallmentTable_ClassTable] FOREIGN KEY([Class_ID])
REFERENCES [dbo].[ClassTable] ([ID])
ALTER TABLE [dbo].[ApplicationForInstallmentTable]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationForInstallmentTable_SessionTable] FOREIGN KEY([Session_ID])
REFERENCES [dbo].[SessionTable] ([ID])
ALTER TABLE [dbo].[ApplicationForInstallmentTable]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationForInstallmentTable_StudentTable] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[StudentTable] ([ID])

ALTER TABLE [dbo].[ApplicationForInstallmentTable]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationForInstallmentTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[ApplicationForInstallmentTable]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationForInstallmentTable_DivisionTable] FOREIGN KEY([Division_ID])
REFERENCES [dbo].[DivisionTable] ([ID])
create table notificationTable(
ID int identity primary key not null,
[User_ID] int null,
Teacher_ID int null,
Reason varchar(max) not null,
IsActive bit default 1 not null,
EditTime datetime null
)
ALTER TABLE [dbo].[notificationTable]  WITH CHECK ADD  CONSTRAINT [FK_notificationTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[notificationTable]  WITH CHECK ADD  CONSTRAINT [FK_notificationTable_TeacherTable] FOREIGN KEY([Teacher_ID])
REFERENCES [dbo].[TeacherTable] ([ID])
Create table ParentsInformationTable(
ID int identity primary key not null,
[Name] varchar(200) not null,
[User_ID] int null,
Profession_ID int not null,
Gender_ID int not null,
Nationality_ID int not null,
Religious_ID int not null,
PostOffice_ID int not null,
UserName nvarchar(200) unique not null,
[Password] nvarchar(max) not null,
PhoneNumber nvarchar(200) not null,
[Address] nvarchar(max) not null,
Photo nvarchar(max) null,
IsActive bit default 1 not null,
EditTime datetime null
)

ALTER TABLE [dbo].[ParentsInformationTable]  WITH CHECK ADD  CONSTRAINT [FK_ParentsInformationTable_UserTable] FOREIGN KEY([User_ID])
REFERENCES [dbo].[UserTable] ([ID])
ALTER TABLE [dbo].[ParentsInformationTable]  WITH CHECK ADD  CONSTRAINT [FK_ParentsInformationTable_GenderTable] FOREIGN KEY([Gender_ID])
REFERENCES [dbo].[GenderTable] ([ID])
ALTER TABLE [dbo].[ParentsInformationTable]  WITH CHECK ADD  CONSTRAINT [FK_ParentsInformationTable_Nationality] FOREIGN KEY([Nationality_ID])
REFERENCES [dbo].[Nationality] ([ID])
ALTER TABLE [dbo].[ParentsInformationTable]  WITH CHECK ADD  CONSTRAINT [FK_ParentsInformationTable_FatherProfesion] FOREIGN KEY([Profession_ID])
REFERENCES [dbo].[FatherProfesion] ([ID])

ALTER TABLE [dbo].[ParentsInformationTable]  WITH CHECK ADD  CONSTRAINT [FK_ParentsInformationTable_ReligiousTable] FOREIGN KEY([Religious_ID])
REFERENCES [dbo].[ReligiousTable] ([ID])
ALTER TABLE [dbo].[ParentsInformationTable]  WITH CHECK ADD  CONSTRAINT [FK_ParentsInformationTable_PostOffice] FOREIGN KEY([PostOffice_ID])
REFERENCES [dbo].[PostOffice] ([ID])

create table ReligiousTable(
ID int identity primary key not null,
[Name] varchar(200) not null,
IsActive bit default 1 not null,
EditTime datetime null
)

































































































































































