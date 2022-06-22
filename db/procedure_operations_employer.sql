
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
	@Id varchar(255)= NULL,
	@operation int,
	@Nombre varchar(255)= NULL,
	@Apellido varchar(255)= NULL,
	@Telefono varchar(255)= NULL,
	@FechaNacimiento varchar(255)= NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @operation = 1
	BEGIN
		SELECT [Id]
		  ,[Apellido]
		  ,[Nombre]
		  ,[FechaNacimiento]
		  ,[Telefoo]
		FROM [dbo].[EMPLEADO] where Id = @Id;
	END

	else if @operation = 2
	BEGIN
		SELECT [Id]
		  ,[Apellido]
		  ,[Nombre]
		  ,[FechaNacimiento]
		  ,[Telefoo]
		FROM [dbo].[EMPLEADO];
	END

	else if @operation = 3
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

	else if @operation = 4
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
