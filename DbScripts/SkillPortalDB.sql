Use SkillPortalDB
Go

-- Create User table
CREATE TABLE [User] (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(255),
    Mobile VARCHAR(20),
    Password VARCHAR(255),
    Role VARCHAR(50),
    IsActive BIT
);
Go

-- Create Email table
CREATE TABLE Email (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES [User](Id),
    EmailAddress VARCHAR(255),
    IsPrimary BIT
);
Go


-- Create Skill table
CREATE TABLE Skill (
    Id INT IDENTITY(1,1) PRIMARY KEY,
	UserId INT FOREIGN KEY REFERENCES [User](Id),
    SkillName VARCHAR(50)
);
Go

-- Create Employee table
CREATE TABLE Employee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeName VARCHAR(255),
    EducationalQualification VARCHAR(255),
    BasicSalary DECIMAL(18, 2),
    JoiningDate DATE
);
Go

-- Create EmployeeSkills join table
CREATE TABLE EmployeeSkills (
    EmployeeId INT FOREIGN KEY REFERENCES Employee(Id),
    SkillId INT FOREIGN KEY REFERENCES Skill(Id),
    PRIMARY KEY (EmployeeId, SkillId)
);
