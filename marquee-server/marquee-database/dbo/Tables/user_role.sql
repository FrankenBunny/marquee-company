CREATE TABLE [dbo].[user_role] (
    [user_id] UNIQUEIDENTIFIER NOT NULL,
    [role_id] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_user_role_role_id] FOREIGN KEY ([role_id]) REFERENCES [dbo].[role] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [fk_user_role_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[user] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

