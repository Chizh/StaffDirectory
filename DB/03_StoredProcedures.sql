CREATE PROCEDURE dbo.SearchStaff
	@firstName nvarchar(100) = null,
	@lastName nvarchar(100) = null,
	@middleName nvarchar(100) = null,
	@birthday date = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.Staff
	WHERE (@firstName IS NULL OR FirstNameBin like Upper(@firstName) + '%' collate Cyrillic_General_CI_AS) AND
		(@lastName IS NULL OR LastNameBin like Upper(@lastName) + '%' collate Cyrillic_General_CI_AS) AND
		(@middleName IS NULL OR MiddleNameBin like Upper(@middleName) + '%' collate Cyrillic_General_CI_AS) AND
		(@birthday IS NULL OR @birthday = Birthday)
	OPTION (maxdop 1);
END
GO
