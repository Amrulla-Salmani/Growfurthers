IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807152548_initial')
BEGIN
    CREATE TABLE [Amenities] (
        [amenityId] int NOT NULL IDENTITY,
        [amenityName] nvarchar(50) NOT NULL,
        [description] nvarchar(500) NOT NULL,
        [status] nvarchar(50) NOT NULL,
        [active] nvarchar(1) NOT NULL,
        CONSTRAINT [PK_Amenities] PRIMARY KEY ([amenityId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807152548_initial')
BEGIN
    CREATE TABLE [Bookings] (
        [bookingId] int NOT NULL IDENTITY,
        [hotelId] int NOT NULL,
        [guestName] nvarchar(max) NOT NULL,
        [checkInDate] datetime2 NOT NULL,
        [checkOutDate] datetime2 NOT NULL,
        [numAdults] int NOT NULL,
        [numChildren] int NOT NULL,
        [bookingStatus] nvarchar(max) NOT NULL,
        [totalAmt] decimal(18,0) NOT NULL,
        [paymentStatus] nvarchar(max) NOT NULL,
        [active] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Bookings] PRIMARY KEY ([bookingId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807152548_initial')
BEGIN
    CREATE TABLE [Hotels] (
        [hotelId] int NOT NULL IDENTITY,
        [hotelName] nvarchar(100) NOT NULL,
        [address] nvarchar(500) NOT NULL,
        [city] int NOT NULL,
        [country] int NOT NULL,
        [phoneNo] nvarchar(15) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [website] nvarchar(max) NOT NULL,
        [checkInTime] datetime2 NOT NULL,
        [checkOutTime] datetime2 NOT NULL,
        [rating] decimal(18,2) NOT NULL,
        [Amenities] int NULL,
        [active] nvarchar(1) NOT NULL,
        CONSTRAINT [PK_Hotels] PRIMARY KEY ([hotelId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807152548_initial')
BEGIN
    CREATE TABLE [Reviews] (
        [reviewId] int NOT NULL IDENTITY,
        [userId] int NOT NULL,
        [hotelId] int NOT NULL,
        [rating] decimal(18,2) NULL,
        [comment] nvarchar(max) NULL,
        [reviewDate] datetime2 NULL,
        [active] nvarchar(1) NOT NULL,
        CONSTRAINT [PK_Reviews] PRIMARY KEY ([reviewId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807152548_initial')
BEGIN
    CREATE TABLE [Rooms] (
        [roomId] int NOT NULL IDENTITY,
        [hotelId] int NOT NULL,
        [roomNumber] int NOT NULL,
        [roomType] nvarchar(max) NOT NULL,
        [pricePerNight] int NOT NULL,
        [active] nvarchar(1) NOT NULL,
        CONSTRAINT [PK_Rooms] PRIMARY KEY ([roomId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807152548_initial')
BEGIN
    CREATE TABLE [Users] (
        [UserId] int NOT NULL IDENTITY,
        [LoginId] nvarchar(50) NOT NULL,
        [UserName] nvarchar(50) NOT NULL,
        [Password] nvarchar(10) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [phoneNo] nvarchar(15) NOT NULL,
        [memberSince] datetime2 NOT NULL,
        [membership] nvarchar(max) NOT NULL,
        [userRole] nvarchar(50) NOT NULL,
        [active] nvarchar(1) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807152548_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230807152548_initial', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807155124_addCityColumn')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Hotels]') AND [c].[name] = N'country');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Hotels] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Hotels] DROP COLUMN [country];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807155124_addCityColumn')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Hotels]') AND [c].[name] = N'Amenities');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Hotels] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Hotels] ALTER COLUMN [Amenities] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807155124_addCityColumn')
BEGIN
    CREATE TABLE [City] (
        [cityId] int NOT NULL IDENTITY,
        [cityName] nvarchar(max) NOT NULL,
        [Active] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_City] PRIMARY KEY ([cityId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230807155124_addCityColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230807155124_addCityColumn', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810150420_changedDatatypeForHotel')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Hotels]') AND [c].[name] = N'city');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Hotels] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Hotels] ALTER COLUMN [city] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810150420_changedDatatypeForHotel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230810150420_changedDatatypeForHotel', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810170426_minor-change-1')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Hotels]') AND [c].[name] = N'Amenities');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Hotels] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Hotels] DROP COLUMN [Amenities];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810170426_minor-change-1')
BEGIN
    ALTER TABLE [Amenities] ADD [hotelId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810170426_minor-change-1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230810170426_minor-change-1', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810190735_minor-change-2')
BEGIN
    ALTER TABLE [Hotels] ADD [imagePath] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230810190735_minor-change-2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230810190735_minor-change-2', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230811141147_minor-change-3')
BEGIN
    EXEC sp_rename N'[Users].[UserName]', N'LastName', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230811141147_minor-change-3')
BEGIN
    EXEC sp_rename N'[Users].[LoginId]', N'FirstName', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230811141147_minor-change-3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230811141147_minor-change-3', N'7.0.8');
END;
GO

COMMIT;
GO

