/*
 Plantilla de script de limpieza de tablas de la BD							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se ejecutarán antes del script de compilación	
 Use la sintaxis de SQLCMD para incluir un archivo en el script anterior a la implementación			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script anterior a la implementación		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*
--------------------------------------------------------------------------------------
------------------------------------   VIEWS   --------------------------------------- 
--------------------------------------------------------------------------------------
*/

if (OBJECT_ID('VW_GetPersonas', 'V') IS NOT NULL)
    drop view dbo.VW_GetPersonas

/*
--------------------------------------------------------------------------------------
-----------------------------------   TABLES   --------------------------------------- 
--------------------------------------------------------------------------------------
*/

if (OBJECT_ID('dbo.Personas', 'U') IS NOT NULL)    
    DROP TABLE dbo.Personas
