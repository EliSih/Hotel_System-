CREATE TABLE [dbo].[Booking] (
    [Reservation ]  INT        NOT NULL,
    [roomNumber ]   INT        NULL,
    [checkInDate ]  DATE       NULL,
    [checkOutDate ] DATE       NULL,
    [Description ]  NCHAR (10) NULL,
    [totalCost ]    NCHAR (10) NULL,
    [employeeID ]   NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Reservation ] ASC)
);

