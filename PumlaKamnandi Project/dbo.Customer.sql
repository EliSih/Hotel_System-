CREATE TABLE [dbo].[Customer] (
    [CustomerID]      INT           NOT NULL,
    [Name ]           NVARCHAR (50) NULL,
    [email Address]   NVARCHAR (50) NULL,
    [ReservationID  ] INT           NULL,
    [Balance ]        MONEY         NULL,
    [paymentType ] NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

