CREATE TABLE [dbo].[Room]
(
	[roomNumber ] INT NOT NULL PRIMARY KEY, 
    [HotelID ] INT NULL, 
    [Cost ] MONEY NULL, 
    [Description ] NVARCHAR(50) NULL, 
    [Capacity ] INT NULL
)
