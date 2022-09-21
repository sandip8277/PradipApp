CREATE PROCEDURE [dbo].[spGetPlantDetailsFromId]

@PlantId int = 1

AS
BEGIN
	select PlantName,AreaName,MachineName,MachineLocation from tblPlantDetails where PlantId = @PlantId;
END

=======================================================================

CREATE PROCEDURE [dbo].[spModifyDetailsById]
@PlantId nvarchar(50),
@PlantName varchar(255),
@AreaName varchar(255),
@MachineName varchar(255),
@MachineLocation varchar(255)	
AS
BEGIN
	Update [dbo].[tblPlantDetails] set PlantName=@PlantName,AreaName=@AreaName,MachineName=@MachineName,MachineLocation=@MachineLocation where PlantId=@PlantId
END

