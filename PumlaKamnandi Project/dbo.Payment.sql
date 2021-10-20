CREATE TABLE [dbo].[Payment] (
    [PaymentID]    INT           NOT NULL,
    [Type ]        NVARCHAR (50) NULL,
    [Description ] NVARCHAR (50) NULL,
    [Date ]        DATE          NULL,
    [Amount ]      MONEY         NULL,
    PRIMARY KEY CLUSTERED ([PaymentID] ASC)
);

