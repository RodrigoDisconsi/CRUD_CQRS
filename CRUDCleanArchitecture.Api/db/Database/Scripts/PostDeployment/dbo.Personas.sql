IF NOT EXISTS (SELECT TOP (1) * FROM [dbo].[Personas])
BEGIN
	SET IDENTITY_INSERT [dbo].[Personas] ON 
	
	INSERT [dbo].[Personas] ([Id], [DNI], [Nombre], [Apellido]) VALUES ( 1, 41234123, 'Fernando', 'Díaz')
	INSERT [dbo].[Personas] ([Id], [DNI], [Nombre], [Apellido]) VALUES ( 2, 41234122, 'Fernanda', 'Díaz')
    INSERT [dbo].[Personas] ([Id], [DNI], [Nombre], [Apellido]) VALUES ( 3, 41234127, 'Roberto', 'Lopez')
    INSERT [dbo].[Personas] ([Id], [DNI], [Nombre], [Apellido]) VALUES ( 4, 41234130, 'Roberta', 'Lopez')
	
	SET IDENTITY_INSERT [dbo].[Personas] OFF
END
