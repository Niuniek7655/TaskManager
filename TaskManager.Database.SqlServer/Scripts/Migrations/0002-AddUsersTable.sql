CREATE TABLE [dbo].[Users]
(
    [Id]                    [uniqueidentifier]      NOT NULL,
    [UserClusteredId]       [bigint] IDENTITY (1,1) NOT NULL,
    [FullDomainName]        [nvarchar](255)         NOT NULL,
    [UserType]              [int]                   NOT NULL,
    [UserStatus]            [int]                   NOT NULL,
    [CreationDate]          datetimeoffset(7)       NOT NULL,
    [LastUpdateDate]        datetimeoffset(7)       NOT NULL,

    CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED (Id ASC),
    CONSTRAINT [UQ_Users_ClusteredId] UNIQUE NONCLUSTERED (UserClusteredId ASC),
);