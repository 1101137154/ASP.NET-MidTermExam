
CREATE DATABASE [KUAS]
GO

USE [KUAS]
GO

CREATE TABLE [dbo].[Course](
	[CourseID]   [nvarchar](20) NOT NULL,
	[CourseName] [nvarchar](200) NOT NULL,
	[CourseDescription]  [nvarchar](1000) NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseDescription]) VALUES (N'kuas001'  , N'CSharp', N'Basic of C Sharp');
INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseDescription]) VALUES (N'kuas002', N'ASP', N'ASP Application');
INSERT [dbo].[Course] ([CourseID], [CourseName], [CourseDescription]) VALUES (N'kuas003'  , N'Mobile', N'Mobile Programming');
GO