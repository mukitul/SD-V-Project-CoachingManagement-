create database coachingmanagement
use coachingmanagement

create table Class
(
	ClassId int identity(1,1) not null,
	ClassName varchar(20) not null,
	ClassCode varchar(10) not null,
	MonthlyFee varchar(10) not null,
	TotalSeat varchar(20),
	NumberOfStd varchar(20),
	AvailableSeat varchar(20),

	primary key(ClassCode),
	unique(ClassName)
	
)
create table Batch
(
	BatchId int identity(1,1) not null,
	ClassName varchar(20),
	ClassCode varchar(10),
	foreign key(ClassCode) references Class(ClassCode),
	BatchName varchar (20) not null,
	MaxBatchStd int not null,
	NumberOfStd int not null,
	AvailableSeat int not null,
	primary key(ClassName,BatchName),
	unique(BatchId),
	

	constraint fk_delete_batch foreign key(ClassCode) references Class(ClassCode) on delete cascade,
	constraint fk_update_batch foreign key(ClassCode) references Class(ClassCode) on update cascade,
)
create table Subjects
(
	id int identity(1,1) not null,
	ClassName varchar(20),
	ClassCode varchar(10),
	foreign key(ClassCode) references Class(ClassCode),
	constraint fk_delete_sub foreign key(ClassCode) references Class(ClassCode) on delete cascade,
	constraint fk_update_sub foreign key(ClassCode) references Class(ClassCode) on update cascade,
	SubName varchar(20),
	SubCode varchar(20),
	primary key(SubCode) 

)
create table Teacher
(
	TeacherId int not null,
	TeacherName varchar(20),
	ClassName varchar(20),
	BatchName varchar(20),
	SubName varchar(20),
	SubCode varchar(20),
	phoneno varchar(20),
	TeacherEmail varchar(55),
	CurrentAddress varchar(50),
	Salary varchar(6),
	
	foreign key (SubCode) references Subjects(SubCode),
	foreign key (ClassName,BatchName) references Batch(ClassName,BatchName),
	constraint fk_delete_teachersub foreign key(SubCode) references Subjects(SubCode) on delete cascade,
	constraint fk_update_teachersub foreign key(SubCode) references Subjects(SubCode) on update cascade,
	unique(TeacherId,SubCode,BatchName)

)
create table Student
(
	SerialNo int not null primary key,
	StdName varchar(50) not null,
	StdInsta varchar(50) not null,
	ClassName varchar(20),
	ClassCode varchar(10),
	BatchName varchar(20),
	StdAddress varchar(50),
	StdPhone varchar(25),
	GurPhone varchar(55),
	StdFee varchar(10),
	YoA int not null,
	unique(SerialNo,ClassName),
	FOREIGN KEY (ClassCode) REFERENCES Class(ClassCode),
	 constraint fk_delete_student foreign key(ClassCode) references Class(ClassCode) ON DELETE cascade,
	constraint fk_update_student foreign key(ClassCode) references Class(ClassCode) ON UPDATE cascade,

	StudentId AS  RIGHT('0000' + CAST(YoA AS VARCHAR(4)),4) 
				+'.'+ RIGHT('00' + CAST(ClassCode AS VARCHAR(2)),2)
				+'.'+ RIGHT('000' + CAST(SerialNo AS VARCHAR(3)),3) persisted not null ,

)
create table StudentResult
(
	ExamId int identity(1,1) not null,
	StudentId varchar(20),
	ClassName varchar(20),
	BatchName varchar(20),
	SubName varchar(20),
	SubCode varchar(20),
	ExamType varchar(20),
	ExamMarks float,
	ObtainedMarks float,
	primary key (ExamId),
	unique(StudentId,SubCode,ExamType),

	foreign key(ClassName) references Class(ClassName),

	foreign key(SubCode) references Subjects(SubCode),

	constraint fk_delete_classStd foreign key(ClassName) references Class(ClassName) on delete cascade,
	constraint fk_update_classStd foreign key(ClassName) references Class(ClassName) on update cascade,
)
create table TeacherSalary
(
	SalaryId int identity(1,1) not null,
	TeacherId varchar(20),
	Salary varchar(6),
	SalaryMonth varchar(20),
	SalaryYear varchar(20),
	SalaryStatus varchar(20),
	primary key (SalaryId,SalaryMonth),
	unique(TeacherId,SalaryMonth)
)
create table StudentFee
(
	FeeId int identity(1,1) not null,
	StudentId varchar(15),
	ClassName varchar(20),
	BatchName varchar(20),
	MonthlyFee varchar(20),
	FeeMonth varchar(20),
	FeeYear varchar(20),
	FeeStatus varchar(20),
	primary key(FeeId),
	unique(StudentId,FeeMonth)
	

)
