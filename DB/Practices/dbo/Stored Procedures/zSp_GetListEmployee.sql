
CREATE PROCEDURE dbo.zSp_GetListEmployee
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	emp.[EmployeeID],
			emp.[DocumentTypeID],
			emp.[DocumentNumber],
			emp.[Name],
			emp.[LastName],
			emp.[BirthDate],
			emp.[AreaID]
	FROM	[dbo].[Employee]		AS emp
	INNER	JOIN dbo.[DocumentType]	AS doc ON emp.[DocumentTypeID] = doc.[DocumentTypeID]
	INNER	JOIN dbo.[Area]			AS are ON emp.[AreaID] = are.[AreaID];

	SET NOCOUNT OFF;
END
