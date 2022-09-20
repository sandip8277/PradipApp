CREATE TABLE tblPlantDetails (
    Id int IDENTITY(1,1) PRIMARY KEY,
	PlantId int,
    PlantName varchar(255) NOT NULL,
    AreaName varchar(255) NOT NULL,
	MachineName varchar(255) NOT NULL,
    MachineLocation varchar(255) NOT NULL,
);