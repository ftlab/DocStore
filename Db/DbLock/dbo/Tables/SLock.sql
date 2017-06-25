CREATE TABLE [dbo].[SLock] (
    [Resource] VARCHAR (255) NOT NULL,
    [Owner]    VARCHAR (255) NOT NULL
);

GO

CREATE CLUSTERED INDEX [IX_SLock_Column] ON [dbo].[SLock] ([Resource], [Owner])
