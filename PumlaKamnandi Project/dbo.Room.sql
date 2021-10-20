CREATE TABLE [dbo].[Room] (
    [roomNumber ]  INT           NOT NULL,
    [HotelID ]     INT           NULL,
    [Cost ]        MONEY         NULL,
    [Description ] NVARCHAR (50) NULL,
    [Capacity ]    INT           NULL,
    PRIMARY KEY CLUSTERED ([roomNumber ] ASC)
);

