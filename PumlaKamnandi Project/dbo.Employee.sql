CREATE TABLE [dbo].[Employee] (
    [employeeID ]    INT           NOT NULL,
    [Name ]          NVARCHAR (50) NULL,
    [EmployeeRole ]  NVARCHAR (50) NULL,
    [Salary ]        MONEY         NULL,
    [NoOfShifts ]    INT           NULL,
    [Supervisor ]    NVARCHAR (50) NULL,
    [cellNumber ]    NCHAR (10)    NULL,
    [ReservationID ] INT           NULL,
    [HotelID ]       INT           NULL,
    PRIMARY KEY CLUSTERED ([employeeID ] ASC)
);

