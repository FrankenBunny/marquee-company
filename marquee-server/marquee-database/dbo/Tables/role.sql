CREATE TABLE [dbo].[role] (
    [id]   UNIQUEIDENTIFIER NOT NULL,
    [name] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [unique_name]
    ON [dbo].[role]([name] ASC);

