CREATE TABLE [dbo].[Tasks]
(
    [Id]                    [uniqueidentifier]      NOT NULL,
    [TaskClusteredId]       [bigint] IDENTITY (1,1) NOT NULL,
    [UserClusteredId]       [bigint]                NOT NULL,
    [Name]                  [nvarchar](255)         NOT NULL,
    [Description]           [nvarchar](1275)        NOT NULL,
    [Status]                [int]                   NOT NULL,
    [CreationDate]          datetimeoffset(7)       NOT NULL,
    [LastUpdateDate]        datetimeoffset(7)       NOT NULL,

    CONSTRAINT [PK_Tasks] PRIMARY KEY NONCLUSTERED (Id ASC),
    CONSTRAINT [FK_Tasks_Users] FOREIGN KEY (UserClusteredId) REFERENCES [Users] (UserClusteredId),
    CONSTRAINT [UQ_Tasks_ClusteredId] UNIQUE NONCLUSTERED (TaskClusteredId ASC),
);