
CREATE PROCEDURE dbo.zSp_CreateEmployee
(
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
						AND		[DocumentNumber] = @pDocumentNumber))
			BEGIN
				RAISERROR ('ERROR: El documento ya existe.', 16, 1)
			END
			ELSE
			BEGIN
				INSERT	INTO [dbo].[Employee]
						(
						[DocumentTypeID],
						[DocumentNumber],
						[Name],
						[LastName],
						[BirthDate],
						[AreaID]
						)
				OUTPUT	INSERTED.EmployeeID 
				INTO	@tblResult
				VALUES
						(
						@pDocumentTypeID,
						@pDocumentNumber,
						@pName,
						@pLastName,
						@pBirthDate,
						@pAreaID
						);

				IF(EXISTS(SELECT 1 FROM @tblResult WHERE EmployeeID > 0))
				BEGIN
					SET @EmployeeID = (SELECT TOP 1 EmployeeID FROM @tblResult);

					SELECT	[EmployeeID],
							[DocumentTypeID],
							[DocumentNumber],
							[Name],
							[LastName],
							[BirthDate],
							[AreaID]
					FROM	[dbo].[Employee]
					WHERE	[EmployeeID] = @EmployeeID;
				END
				ELSE
				BEGIN
					RAISERROR ('ERROR: No fue posible crear el empleado.', 16, 1);
					RETURN;
				END
			END
		COMMIT;
	END TRY
	BEGIN CATCH

		IF @@TRANCOUNT > 0
			ROLLBACK;
		THROW;
	END CATCH
END
