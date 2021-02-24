
CREATE PROCEDURE dbo.zSp_UpdateEmployee
(
	@pEmployeeID		INT,
	@pDocumentTypeID	INT,
	@pDocumentNumber	VARCHAR(20),
	@pName				VARCHAR(50),
	@pLastName			VARCHAR(50),
	@pBirthDate			DATETIME,
	@pAreaID			INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @Error		VARCHAR(MAX),
			@EmployeeID INT;

	DECLARE @tblResult TABLE(
			EmployeeID INT
			); 

	BEGIN TRY;
		BEGIN TRAN;
			IF(EXISTS(	SELECT	1
						FROM	[dbo].[Employee]
						WHERE	[DocumentTypeID] = @pDocumentTypeID 
						AND		[DocumentNumber] = @pDocumentNumber
						AND		[EmployeeID] <> @pEmployeeID))
			BEGIN
				RAISERROR ('ERROR: El documento ya existe.', 16, 1)
			END
			ELSE
			BEGIN
				UPDATE	[dbo].[Employee]
				SET		[DocumentTypeID] = @pDocumentTypeID,
						[DocumentNumber] = @pDocumentNumber,
						[Name] = @pName,
						[LastName] = @pLastName,
						[BirthDate] = @pBirthDate,
						[AreaID] = @pAreaID
				WHERE	[EmployeeID] = @pEmployeeID;
			END
		COMMIT;
	END TRY
	BEGIN CATCH

		IF @@TRANCOUNT > 0
			ROLLBACK;
		THROW;
	END CATCH
END
