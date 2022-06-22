-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE OrderProcedure 
	-- Add the parameters for the stored procedure here
	@Id varchar(255)= NULL,
	@operation int,
	@EmpleadoID varchar(255)= NULL,
	@DetallerOrdenes varchar(255)= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @operation = 1
	BEGIN
		SELECT [Id]
		  ,[EmpleadoID]
		  ,[DetallerOrdenes]
	  FROM [dbo].[ORDENES]
	  where Id = @Id;
	END

	else if @operation = 2
	BEGIN
		SELECT [Id]
		  ,[EmpleadoID]
		  ,[DetallerOrdenes]
		FROM [dbo].[ORDENES];
	END

	else if @operation = 3
	BEGIN
		INSERT INTO [dbo].[ORDENES]
           ([Id]
           ,[EmpleadoID]
           ,[DetallerOrdenes])
     VALUES
           (@Id
           ,@EmpleadoID
           ,@DetallerOrdenes)
	END

	else if @operation = 4
	BEGIN
		UPDATE [dbo].[ORDENES]
	   SET [Id] = @Id
		  ,[EmpleadoID] = @EmpleadoID
		  ,[DetallerOrdenes] = @DetallerOrdenes
		WHERE Id = @Id
	END
END
GO
