CREATE TABLE tblPlantPhoto (
    PlantPhotoId int IDENTITY(1,1) PRIMARY KEY,
    PlantId int NOT NULL,
    Image nvarchar(Max)
);

===================================================

CREATE PROCEDURE [dbo].[spSavePlantPhoto]
@PlantId int,
@Image nvarchar(max)
AS

BEGIN
	Insert into [dbo].[tblPlantPhoto] (PlantId,Image) Values (@PlantId,@Image)
END
