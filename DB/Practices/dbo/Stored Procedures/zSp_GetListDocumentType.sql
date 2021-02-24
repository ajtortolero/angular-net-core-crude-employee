
CREATE PROCEDURE dbo.zSp_GetListDocumentType
AS
BEGIN
	SET NOCOUNT ON

	SELECT	[DocumentTypeID],
			[Name]
	FROM	[dbo].[DocumentType];
END
