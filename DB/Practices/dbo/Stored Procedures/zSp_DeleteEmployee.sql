
CREATE PROCEDURE dbo.zSp_DeleteEmployee
(
	@pEmployeeID		INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Error		VARCHAR(MAX),
			@EmployeeID INT;

	BEGIN TRY;
		BEGIN TRAN;
			DELETE	FROM [dbo].[Employee] 
			WHERE	[EmployeeID] = @pEmployeeID

			SET @EmployeeID = @pEmployeeID;
		COMMIT;
	END TRY
	BEGIN CATCH

		IF @@TRANCOUNT > 0
			ROLLBACK;
		THROW;

		SET @EmployeeID = 0;
	END CATCH

	SELECT @EmployeeID;
END
