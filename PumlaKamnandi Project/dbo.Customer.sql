CREATE TABLE [dbo].[Customer] (
    [CustomerID]      INT           NOT NULL,
    [Name ]           NVARCHAR (50) NULL,
    [email Address]   NVARCHAR (50) NULL,
    [Balance ]        MONEY         NULL,
    [paymentType ] NCHAR(10) NULL, 
    [Description ] NVARCHAR(50) NULL, 
    [AccountNumber] INT NULL, 
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

