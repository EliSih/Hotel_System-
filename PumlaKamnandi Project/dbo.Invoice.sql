CREATE TABLE [dbo].[Invoice] (
    [invoiceNumber] INT        NOT NULL,
    [PaymentID ]    INT        NULL,
    [Description ]  NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([invoiceNumber] ASC)
);

