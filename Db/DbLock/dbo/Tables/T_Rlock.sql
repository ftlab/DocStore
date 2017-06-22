CREATE TABLE [dbo].[T_Rlock] (
    [Id]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [Resource] VARCHAR (255) NOT NULL,
    [LockMode] TINYINT       NOT NULL,
    [Owner]    VARCHAR (255) NULL,
    CONSTRAINT [PK_T_Rlock] PRIMARY KEY CLUSTERED ([Resource] ASC, [LockMode] ASC)
);

