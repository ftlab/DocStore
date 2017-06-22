CREATE TABLE [dbo].[XLock] (
    [Resource] VARCHAR (255) NOT NULL,
    [Owner]    VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_XLock] PRIMARY KEY CLUSTERED ([Resource] ASC)
);

