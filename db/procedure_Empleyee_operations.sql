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
	@Id varchar(50),
	@operation int,
	@EmpleadoID varchar(50),
	@DetallerOrdenes varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @operation = 0
	BEGIN
		select * from ORDENES where Id = @Id;
	END

	else if @operation = 1
	BEGIN
		Select * from ORDENES;
	END

	else if @operation = 2
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

	else if @operation = 3
	BEGIN
		UPDATE [dbo].[ORDENES]
	   SET [Id] = @Id
		  ,[EmpleadoID] = @EmpleadoID
		  ,[DetallerOrdenes] = @DetallerOrdenes
		WHERE Id = @Id
	END
END
GO
