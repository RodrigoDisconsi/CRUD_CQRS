USE [Prestadores]
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[Zonas])
	INSERT INTO [dbo].[Zonas]
			   ([Descripcion])
		 VALUES
			   ('METROPOLITANA'),('CENTRO'),('CUYO'),('LITORAL')

IF NOT EXISTS(SELECT 1 FROM [dbo].[Agencias])
	INSERT INTO [dbo].[Agencias]
			   ([Descripcion])
		 VALUES
			   ('Agencia')

IF NOT EXISTS(SELECT 1 FROM [dbo].[CodigoPostales])
	INSERT INTO [dbo].[CodigoPostales]
			   ([Descripcion]
			   ,[CodPostal]
			   ,[AgenciaId]
			   ,[ZonaId])
		 VALUES
			   ('Codigo Postal', '1646' ,1, 2)

IF NOT EXISTS(SELECT 1 FROM [dbo].[Localidades])
	INSERT INTO [dbo].[Localidades]
			   ([Descripcion]
			   ,[ProvinciaId]
			   ,[CodigoPostalId])
		 VALUES
			   ('ADROGUE', 2, 1),
			   ('AVELLANEDA', 2, 1),
			   ('CAPITAL FEDERAL', 1, 1)

IF NOT EXISTS(SELECT 1 FROM [dbo].[Domicilios])
INSERT INTO [dbo].[Domicilios]
           ([Calle]
           ,[Numero]
           ,[Piso]
           ,[Departamento]
           ,[LocalidadId])
     VALUES
           ('CLINICA IMA...','123','PB','Fondo',1),
           ('RADIOLOGIA...','222','','',1),
           ('ROISA-CENT...','333','','',2),
           ('SERES SALUD...','22222','1','B',2),
           ('RODRIGUEZ...','123','','',2),
           ('TRAUMATO...','123','1','Fondo',3),
           ('RATINOF...','123','1','Fondo',2),
           ('REHTO SA','123','1','Fondo',3)

IF NOT EXISTS(SELECT 1 FROM [dbo].[Prestadores])
	INSERT INTO [dbo].[Prestadores]
			   ([Nombre]
			   ,[CodigoPrestador]
			   ,[CodigoGrupo]
			   ,[Gerenciador]
			   ,[DomicilioId]
			   ,[Activo]
			   ,[HabilitadoSRT]
			   ,[Principal])
	VALUES
		('CLINICA IMA...', NEWID(), 'CLIMA', 0, 1, 1, 1, 1),
		('RADIOLOGIA...', NEWID(), 'RADIOLG', 0, 2, 1, 1, 1),
		('ROISA-CENT...', NEWID(), 'ROISACENT', 0, 3, 1, 1, 1),
		('SERES SALUD...', NEWID(), 'SERESUD', 0, 4, 1, 1, 1),
		('RODRIGUEZ...', NEWID(), 'RDRIGZ', 0, 5, 1, 1, 0),
		('TRAUMATO...', NEWID(), 'TRMTO', 0, 6, 1, 1, 1),
		('RATINOF...', NEWID(), 'RATNOF', 0, 7, 1, 1, 1),
		('REHTO SA', NEWID(), 'RHTSA', 0, 8, 1, 1, 1)

IF NOT EXISTS(SELECT 1 FROM [dbo].[Contactos])
INSERT INTO [dbo].[Contactos]
           ([PrestadorId]
           ,[Email]
           ,[CodigoArea]
           ,[Numero]
           ,[ContactoTipoId]
           ,[ContactoDescripcion])
     VALUES
           (1, '', 341, '4456699', 1, ''),
           (2, '', 11, '4456699', 1, ''),
           (3, '', 11, '4456699', 1, ''),
           (4, '', 3451, '4456699', 1, ''),
           (5, '', 341, '4456699', 1, ''),
           (6, '', 11, '4456699', 1, ''),
           (7, '', 11, '4456699', 1, ''),
           (8, '', 3451, '4456699', 1, '')

IF NOT EXISTS(SELECT 1 FROM [dbo].[DatosFiscales])
INSERT INTO [dbo].[DatosFiscales]
           ([PrestadorId]
           ,[Cuit]
           ,[IngresoBruto]
           ,[CBU]
           ,[Percepciones]
           ,[PlazoPago]
           ,[Independiente]
           ,[FacturacionActiva])
     VALUES
           (1, '30587088025', '', '', 0, 0, 0, 0),
           (2, '30708318465', '', '', 0, 0, 0, 0),
           (3, '30661931066', '', '', 0, 0, 0, 0),
           (4, '30687220079', '', '', 0, 0, 0, 0),
           (5, '20111598712', '', '', 0, 0, 0, 0),
           (6, '30709203629', '', '', 0, 0, 0, 0),
           (7, '20125968377', '', '', 0, 0, 0, 0),
           (8, '30687484416', '', '', 0, 0, 0, 0)

GO