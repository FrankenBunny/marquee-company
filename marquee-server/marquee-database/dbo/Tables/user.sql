CREATE TABLE [dbo].[user] (
    [id]            UNIQUEIDENTIFIER NOT NULL,
    [username]      NVARCHAR (100)   NOT NULL,
    [password_hash] NVARCHAR (MAX)   NOT NULL,
    [name]          NVARCHAR (100)   NOT NULL,
    [email]         NVARCHAR (256)   NOT NULL,
    CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [unique_username]
    ON [dbo].[user]([username] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [unique_email]
    ON [dbo].[user]([email] ASC);

