GO

CREATE VIEW [dbo].[VW_GetPersonas]
	AS 
	SELECT 
		personas.Id AS PersonaId,
		personas.DNI AS DNI,
		personas.Nombre AS Nombre,
		personas.Apellido AS Apellido
	FROM [dbo].[Personas] personas

GO