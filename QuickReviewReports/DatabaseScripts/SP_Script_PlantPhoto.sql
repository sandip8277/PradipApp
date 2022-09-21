CREATE PROCEDURE [dbo].[spSavePlantPhoto]
@PlantId int,
@Image nvarchar(max)
AS

BEGIN
	Insert into [dbo].[tblPlantPhoto] (PlantId,Image) Values (@PlantId,@Image)
END
