CREATE TABLE [dbo].[SLock] (
    [Resource] VARCHAR (255) NOT NULL,
    [Owner]    VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_SLock] PRIMARY KEY CLUSTERED ([Resource] ASC, [Owner] ASC)
);

