CREATE TABLE tblPlantDetails (
    Id int IDENTITY(1,1) PRIMARY KEY,
	PlantId int,
    PlantName varchar(255) NOT NULL,
    AreaName varchar(255) NOT NULL,
	MachineName varchar(255) NOT NULL,
    MachineLocation varchar(255) NOT NULL,
);



CREATE PROCEDURE [dbo].[spSavePlantDetails]
@PlantId nvarchar(50),
@PlantName varchar(255),
@AreaName varchar(255),
@MachineName varchar(255),
@MachineLocation varchar(255),
@Message varchar(255) output

AS
BEGIN
		Insert into [dbo].[tblPlantDetails] (PlantId,PlantName,AreaName,MachineName,MachineLocation) 
		values (@PlantId,@PlantName,@AreaName,@MachineName,@MachineLocation)
	set @Message='Done'
END


