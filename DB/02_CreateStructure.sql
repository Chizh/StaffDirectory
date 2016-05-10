/****** Object:  Table [dbo].[Department] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Staff] ******/
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Birthday] [date] NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[FirstNameBin]  AS (upper([FirstName]) collate Cyrillic_General_CI_AS) PERSISTED,
	[LastNameBin]  AS (upper([LastName]) collate Cyrillic_General_CI_AS) PERSISTED,
	[MiddleNameBin]  AS (upper([MiddleName]) collate Cyrillic_General_CI_AS) PERSISTED,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/* Indexes for better perfomance with WHERE clause */
CREATE NONCLUSTERED INDEX IDX_Staff_FirstNameBin
ON dbo.Staff(FirstNameBin);
CREATE NONCLUSTERED INDEX IDX_Staff_LastNameBin
ON dbo.Staff(LastNameBin);
CREATE NONCLUSTERED INDEX IDX_Staff_MiddleNameBin
ON dbo.Staff(MiddleNameBin);
GO

/****** Object:  Table [dbo].[DepartmentMember] ******/
CREATE TABLE [dbo].[DepartmentMember](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
 CONSTRAINT [PK_DepartmentMember] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DepartmentMember]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentMember_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([ID])
GO
ALTER TABLE [dbo].[DepartmentMember] CHECK CONSTRAINT [FK_DepartmentMember_Department]
GO
ALTER TABLE [dbo].[DepartmentMember]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentMember_Staff] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([ID])
GO
ALTER TABLE [dbo].[DepartmentMember] CHECK CONSTRAINT [FK_DepartmentMember_Staff]
GO
/* Indexes for DepartmentMember table */
CREATE NONCLUSTERED INDEX [IX_DepartmentMember_Department] ON [dbo].[DepartmentMember]
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DepartmentMember_Staff] ON [dbo].[DepartmentMember]
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO




