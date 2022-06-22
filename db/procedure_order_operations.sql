
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<william lopez>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE EmployeeProcedure 
	-- Add the parameters for the stored procedure here
	@Id varchar(50),
	@operation int,
	@Nombre varchar(50),
	@Apellido varchar(50),
	@Telefono varchar(50),
	@FechaNacimiento varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @operation = 0
	BEGIN
		select * from EMPLEADO where Id = @Id;
	END

	else if @operation = 1
	BEGIN
		Select * from EMPLEADO;
	END

	else if @operation = 2
	BEGIN
		INSERT INTO [dbo].[EMPLEADO]
           ([Id]
           ,[Apellido]
           ,[Nombre]
           ,[FechaNacimiento]
           ,[Telefoo])
		VALUES
           (@Id, @Apellido, @Nombre, @FechaNacimiento, @Telefono);
	END

	else if @operation = 3
	BEGIN
		UPDATE [dbo].[EMPLEADO]
			SET [Id] = @Id
			  ,[Apellido] = @Apellido
			  ,[Nombre] = @Nombre
			  ,[FechaNacimiento] = @FechaNacimiento
			  ,[Telefoo] = @Telefono
			WHERE id = @Id
	END

END
GO
