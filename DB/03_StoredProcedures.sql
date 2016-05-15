CREATE PROCEDURE dbo.SearchStaff
	@firstName nvarchar(100) = null,
	@lastName nvarchar(100) = null,
	@middleName nvarchar(100) = null,
	@birthday date = null,
	@departmentId int = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT s.*, d.ID as DepartmentID, d.Name as DepartmentName
	FROM dbo.Staff as s LEFT OUTER JOIN dbo.DepartmentMember as dm on s.ID = dm.StaffID LEFT OUTER JOIN dbo.Department as d on dm.DepartmentID = d.ID
	WHERE (@firstName IS NULL OR @firstName = '' OR FirstNameBin like Upper(@firstName) + '%' collate Cyrillic_General_CI_AS) AND
		(@lastName IS NULL OR @lastName = '' OR LastNameBin like Upper(@lastName) + '%' collate Cyrillic_General_CI_AS) AND
		(@middleName IS NULL OR @middleName = '' OR MiddleNameBin like Upper(@middleName) + '%' collate Cyrillic_General_CI_AS) AND
		(@birthday IS NULL OR @birthday = Birthday)
	OPTION (maxdop 1);
END
GO
