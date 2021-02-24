
CREATE PROCEDURE [dbo].[zSp_GetListArea]
AS
BEGIN

	SET FMTONLY OFF
	SET NOCOUNT ON

	SELECT	[AreaID],
			[Name]
	FROM	[dbo].[Area];
END
