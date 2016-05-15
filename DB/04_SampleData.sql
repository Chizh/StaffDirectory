INSERT [dbo].[Department] ([Name]) VALUES ('Департамент маркетинга')
INSERT [dbo].[Department] ([Name]) VALUES ('Бухгалтерия')
INSERT [dbo].[Department] ([Name]) VALUES ('Департамент информационных технологий')
GO

INSERT [dbo].[Staff] ([Birthday], [FirstName], [MiddleName], [LastName]) VALUES ('1985-05-11', 'Иван', 'Петрович', 'Иванов')
INSERT [dbo].[Staff] ([Birthday], [FirstName], [MiddleName], [LastName]) VALUES ('1990-06-20', 'Сергей', 'Алексеевич', 'Суриков')
INSERT [dbo].[Staff] ([Birthday], [FirstName], [MiddleName], [LastName]) VALUES ('1970-01-20', 'Дмитрий', NULL, 'Никифоров')
INSERT [dbo].[Staff] ([Birthday], [FirstName], [MiddleName], [LastName]) VALUES ('1975-02-12', 'Петр', 'Петрович', 'Петров')
GO

INSERT [dbo].[DepartmentMember] ([StaffID], [DepartmentID]) VALUES (4, 3)
GO