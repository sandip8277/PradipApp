CREATE PROCEDURE [dbo].[spGetPlantPdf]
@PlantId int
AS
BEGIN
	Select top 1 pd.PlantId,pd.PlantName,pd.AreaName,pd.MachineName,pd.MachineLocation,pp.Image 
	from tblPlantDetails pd 
	inner join tblPlantPhoto pp on pd.PlantId=pp.PlantId 
	where pd.PlantId = @PlantId
	order by PlantPhotoId desc
END
