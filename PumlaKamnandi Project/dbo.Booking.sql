CREATE TABLE [dbo].[Booking] (
    [ReservationID]  INT         NOT NULL,
    [roomNumber ]   INT         NULL,
    [checkInDate ]  DATE        NULL,
    [checkOutDate ] DATE        NULL,
    [Description ]  NCHAR (150) NULL,
    [totalCost ]    NCHAR (10)  NULL,
    [employeeID ]   NCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([ReservationID] ASC)
);

