IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AppConfigs] (
    [Key] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AppConfigs] PRIMARY KEY ([Key])
);

GO

CREATE TABLE [Banners] (
    [Id] int NOT NULL IDENTITY,
    [Hinh] nvarchar(max) NOT NULL,
    [ThuTu] int NOT NULL,
    CONSTRAINT [PK_Banners] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [DiaChis] (
    [Id] int NOT NULL IDENTITY,
    [Diachi] nvarchar(max) NOT NULL,
    [TinhThanh] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_DiaChis] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [DonHangs] (
    [Id] int NOT NULL IDENTITY,
    [NgayDat] datetime2 NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [NguoiNhan] nvarchar(max) NULL,
    [DiaChiNhan] nvarchar(200) NOT NULL,
    [SDT] nvarchar(max) NULL,
    [Tinhtrang] int NOT NULL,
    CONSTRAINT [PK_DonHangs] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Giaodichs] (
    [Id] int NOT NULL IDENTITY,
    [NgayGd] datetime2 NOT NULL,
    [ExternalTransactionId] nvarchar(max) NULL,
    [Amount] real NOT NULL,
    [Fee] real NOT NULL,
    [Result] nvarchar(max) NULL,
    [Message] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [Provider] nvarchar(max) NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Giaodichs] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Khuyenmais] (
    [Id] int NOT NULL IDENTITY,
    [FromDate] datetime2 NOT NULL,
    [ToDate] datetime2 NOT NULL,
    [ApplyForAll] bit NOT NULL,
    [DiscountPercent] int NULL,
    [DiscountAmount] real NULL,
    [MangaIds] nvarchar(max) NULL,
    [MangaTheloaiIds] nvarchar(max) NULL,
    [Status] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Khuyenmais] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [LienHes] (
    [Id] int NOT NULL IDENTITY,
    [HoTen] nvarchar(100) NOT NULL,
    [DiaChi] nvarchar(max) NOT NULL,
    [SDT] nvarchar(20) NOT NULL,
    [NoiDung] nvarchar(max) NOT NULL,
    [NgayGui] datetime2 NOT NULL,
    CONSTRAINT [PK_LienHes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Menus] (
    [Id] int NOT NULL IDENTITY,
    [TenMenu] nvarchar(max) NOT NULL,
    [ThuTu] int NOT NULL,
    CONSTRAINT [PK_Menus] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [NgonnguMns] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_NgonnguMns] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [SoLuotTruyCaps] (
    [Dem] bigint NOT NULL DEFAULT CAST(0 AS bigint),
    CONSTRAINT [PK_SoLuotTruyCaps] PRIMARY KEY ([Dem])
);

GO

CREATE TABLE [TacGias] (
    [Id] int NOT NULL IDENTITY,
    [TenTacGia] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TacGias] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Theloais] (
    [Id] int NOT NULL IDENTITY,
    [TenTL] nvarchar(max) NOT NULL,
    [Thutu] int NOT NULL,
    [Anhien] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_Theloais] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TinTucs] (
    [Id] int NOT NULL IDENTITY,
    [TieuDe] nvarchar(50) NOT NULL,
    [Hinh] nvarchar(200) NOT NULL,
    [NoiDung] nvarchar(max) NOT NULL,
    [NgayCapNhat] datetime2 NOT NULL,
    [AnHien] bit NOT NULL DEFAULT CAST(1 AS bit),
    CONSTRAINT [PK_TinTucs] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Mangas] (
    [Id] int NOT NULL IDENTITY,
    [Ma] nvarchar(max) NULL,
    [Ten] nvarchar(max) NOT NULL,
    [Gia] real NOT NULL,
    [Giagoc] real NOT NULL,
    [Anhien] bit NOT NULL DEFAULT CAST(1 AS bit),
    [NgonnguId] int NOT NULL,
    CONSTRAINT [PK_Mangas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mangas_NgonnguMns_NgonnguId] FOREIGN KEY ([NgonnguId]) REFERENCES [NgonnguMns] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [DonHangDetails] (
    [DonHangId] int NOT NULL,
    [MangaId] int NOT NULL,
    [Gia] real NOT NULL,
    [Soluongdat] int NOT NULL,
    [Tongtien] real NOT NULL,
    CONSTRAINT [PK_DonHangDetails] PRIMARY KEY ([DonHangId], [MangaId]),
    CONSTRAINT [FK_DonHangDetails_DonHangs_DonHangId] FOREIGN KEY ([DonHangId]) REFERENCES [DonHangs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DonHangDetails_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [GioHangs] (
    [Id] int NOT NULL IDENTITY,
    [MangaId] int NOT NULL,
    [Gia] real NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_GioHangs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GioHangs_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [MangaDetails] (
    [MangaId] int NOT NULL,
    [SoLuong] int NOT NULL,
    [TinhtrangMn] int NOT NULL,
    [Mota] nvarchar(max) NULL,
    [Tacgia] nvarchar(max) NULL,
    [NamXB] nvarchar(max) NULL,
    [Sotrang] int NOT NULL,
    CONSTRAINT [PK_MangaDetails] PRIMARY KEY ([MangaId]),
    CONSTRAINT [FK_MangaDetails_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [MangaImages] (
    [Id] int NOT NULL IDENTITY,
    [MangaId] int NOT NULL,
    [LinkAnh] nvarchar(200) NOT NULL,
    [ChuThich] nvarchar(200) NULL,
    [Anhmacdinh] bit NOT NULL,
    [ThuTu] int NOT NULL,
    [FileSize] bigint NOT NULL,
    CONSTRAINT [PK_MangaImages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MangaImages_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [MComments] (
    [Id] int NOT NULL IDENTITY,
    [MangaId] int NOT NULL,
    [TieuDe] nvarchar(50) NOT NULL,
    [NoiDung] nvarchar(200) NOT NULL,
    [NgayComment] datetime2 NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_MComments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MComments_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [MnTheloais] (
    [MangaId] int NOT NULL,
    [TheLoaiId] int NOT NULL,
    CONSTRAINT [PK_MnTheloais] PRIMARY KEY ([MangaId], [TheLoaiId]),
    CONSTRAINT [FK_MnTheloais_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MnTheloais_Theloais_TheLoaiId] FOREIGN KEY ([TheLoaiId]) REFERENCES [Theloais] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_DonHangDetails_MangaId] ON [DonHangDetails] ([MangaId]);

GO

CREATE INDEX [IX_GioHangs_MangaId] ON [GioHangs] ([MangaId]);

GO

CREATE INDEX [IX_MangaImages_MangaId] ON [MangaImages] ([MangaId]);

GO

CREATE INDEX [IX_Mangas_NgonnguId] ON [Mangas] ([NgonnguId]);

GO

CREATE INDEX [IX_MComments_MangaId] ON [MComments] ([MangaId]);

GO

CREATE INDEX [IX_MnTheloais_TheLoaiId] ON [MnTheloais] ([TheLoaiId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200401084213_Initial', N'3.1.3');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Key', N'Value') AND [object_id] = OBJECT_ID(N'[AppConfigs]'))
    SET IDENTITY_INSERT [AppConfigs] ON;
INSERT INTO [AppConfigs] ([Key], [Value])
VALUES (N'HomeTitle', N'This is home page of FMN'),
(N'HomeKeyword', N'This is Keyword of FMN'),
(N'HomeDescription', N'This is Description of FMN');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Key', N'Value') AND [object_id] = OBJECT_ID(N'[AppConfigs]'))
    SET IDENTITY_INSERT [AppConfigs] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[NgonnguMns]'))
    SET IDENTITY_INSERT [NgonnguMns] ON;
INSERT INTO [NgonnguMns] ([Id], [Name])
VALUES (1, N'Vietnamese'),
(2, N'Japanese');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[NgonnguMns]'))
    SET IDENTITY_INSERT [NgonnguMns] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'TenTL', N'Thutu') AND [object_id] = OBJECT_ID(N'[Theloais]'))
    SET IDENTITY_INSERT [Theloais] ON;
INSERT INTO [Theloais] ([Id], [TenTL], [Thutu])
VALUES (1, N'Hành Động', 0),
(2, N'Hài Hước', 0),
(3, N'Kinh Dị', 0),
(4, N'Trinh Thám', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'TenTL', N'Thutu') AND [object_id] = OBJECT_ID(N'[Theloais]'))
    SET IDENTITY_INSERT [Theloais] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Anhien', N'Gia', N'Giagoc', N'Ma', N'NgonnguId', N'Ten') AND [object_id] = OBJECT_ID(N'[Mangas]'))
    SET IDENTITY_INSERT [Mangas] ON;
INSERT INTO [Mangas] ([Id], [Anhien], [Gia], [Giagoc], [Ma], [NgonnguId], [Ten])
VALUES (1, CAST(1 AS bit), CAST(50000 AS real), CAST(50000 AS real), NULL, 1, N'OnePice Tap 1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Anhien', N'Gia', N'Giagoc', N'Ma', N'NgonnguId', N'Ten') AND [object_id] = OBJECT_ID(N'[Mangas]'))
    SET IDENTITY_INSERT [Mangas] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Anhien', N'Gia', N'Giagoc', N'Ma', N'NgonnguId', N'Ten') AND [object_id] = OBJECT_ID(N'[Mangas]'))
    SET IDENTITY_INSERT [Mangas] ON;
INSERT INTO [Mangas] ([Id], [Anhien], [Gia], [Giagoc], [Ma], [NgonnguId], [Ten])
VALUES (2, CAST(1 AS bit), CAST(30000 AS real), CAST(30000 AS real), NULL, 1, N'Conan Tap 10');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Anhien', N'Gia', N'Giagoc', N'Ma', N'NgonnguId', N'Ten') AND [object_id] = OBJECT_ID(N'[Mangas]'))
    SET IDENTITY_INSERT [Mangas] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MangaId', N'Mota', N'NamXB', N'SoLuong', N'Sotrang', N'Tacgia', N'TinhtrangMn') AND [object_id] = OBJECT_ID(N'[MangaDetails]'))
    SET IDENTITY_INSERT [MangaDetails] ON;
INSERT INTO [MangaDetails] ([MangaId], [Mota], [NamXB], [SoLuong], [Sotrang], [Tacgia], [TinhtrangMn])
VALUES (1, N'Hay lam ne hehe', N'1234', 1, 90, N'vvv', 1),
(2, N'Hấp dẫn nè', N'3452', 1, 97, N'fdsf', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MangaId', N'Mota', N'NamXB', N'SoLuong', N'Sotrang', N'Tacgia', N'TinhtrangMn') AND [object_id] = OBJECT_ID(N'[MangaDetails]'))
    SET IDENTITY_INSERT [MangaDetails] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MangaId', N'TheLoaiId') AND [object_id] = OBJECT_ID(N'[MnTheloais]'))
    SET IDENTITY_INSERT [MnTheloais] ON;
INSERT INTO [MnTheloais] ([MangaId], [TheLoaiId])
VALUES (1, 1),
(1, 2),
(2, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'MangaId', N'TheLoaiId') AND [object_id] = OBJECT_ID(N'[MnTheloais]'))
    SET IDENTITY_INSERT [MnTheloais] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200401091307_SeedData', N'3.1.3');

GO

CREATE TABLE [AppRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AppRoleClaims] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AppRoles] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [NormalizedName] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [Description] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_AppRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AppUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AppUserClaims] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AppUserLogins] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(max) NULL,
    [ProviderKey] nvarchar(max) NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    CONSTRAINT [PK_AppUserLogins] PRIMARY KEY ([UserId])
);

GO

CREATE TABLE [AppUserRoles] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AppUserRoles] PRIMARY KEY ([UserId], [RoleId])
);

GO

CREATE TABLE [AppUsers] (
    [Id] uniqueidentifier NOT NULL,
    [UserName] nvarchar(max) NULL,
    [NormalizedUserName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [NormalizedEmail] nvarchar(max) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [Ho] nvarchar(200) NOT NULL,
    [Ten] nvarchar(200) NOT NULL,
    [Dob] datetime2 NOT NULL,
    [GioiTinh] bit NOT NULL,
    CONSTRAINT [PK_AppUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AppUserTokens] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AppUserTokens] PRIMARY KEY ([UserId])
);

GO

CREATE TABLE [InforSells] (
    [MangaId] int NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_InforSells] PRIMARY KEY ([MangaId], [UserId]),
    CONSTRAINT [FK_InforSells_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_InforSells_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE
);

GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_MComments_UserId] ON [MComments] ([UserId]);

GO

CREATE INDEX [IX_GioHangs_UserId] ON [GioHangs] ([UserId]);

GO

CREATE INDEX [IX_Giaodichs_UserId] ON [Giaodichs] ([UserId]);

GO

CREATE INDEX [IX_DonHangs_UserId] ON [DonHangs] ([UserId]);

GO

CREATE INDEX [IX_DiaChis_UserId] ON [DiaChis] ([UserId]);

GO

CREATE INDEX [IX_InforSells_UserId] ON [InforSells] ([UserId]);

GO

ALTER TABLE [DiaChis] ADD CONSTRAINT [FK_DiaChis_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [DonHangs] ADD CONSTRAINT [FK_DonHangs_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [Giaodichs] ADD CONSTRAINT [FK_Giaodichs_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [GioHangs] ADD CONSTRAINT [FK_GioHangs_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [MComments] ADD CONSTRAINT [FK_MComments_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200401100402_AspIdentityDb', N'3.1.3');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Description', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AppRoles]'))
    SET IDENTITY_INSERT [AppRoles] ON;
INSERT INTO [AppRoles] ([Id], [ConcurrencyStamp], [Description], [Name], [NormalizedName])
VALUES ('8d04dce2-969a-435d-bba4-df3f325983dc', N'65c1a712-e373-4c88-832c-5c306554f343', N'Administrator role', N'admin', N'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Description', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AppRoles]'))
    SET IDENTITY_INSERT [AppRoles] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AppUserRoles]'))
    SET IDENTITY_INSERT [AppUserRoles] ON;
INSERT INTO [AppUserRoles] ([UserId], [RoleId])
VALUES ('69bd714f-9576-45ba-b5b7-f00649be00de', '8d04dce2-969a-435d-bba4-df3f325983dc');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'RoleId') AND [object_id] = OBJECT_ID(N'[AppUserRoles]'))
    SET IDENTITY_INSERT [AppUserRoles] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Dob', N'Email', N'EmailConfirmed', N'GioiTinh', N'Ho', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'Ten', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AppUsers]'))
    SET IDENTITY_INSERT [AppUsers] ON;
INSERT INTO [AppUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Dob], [Email], [EmailConfirmed], [GioiTinh], [Ho], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [Ten], [TwoFactorEnabled], [UserName])
VALUES ('69bd714f-9576-45ba-b5b7-f00649be00de', 0, N'f19e587b-6ec5-41cc-a5eb-4e30654b32c5', '2000-01-01T00:00:00.0000000', N'nutrinh@gmail.com', CAST(1 AS bit), CAST(1 AS bit), N'Lee', CAST(0 AS bit), NULL, N'nutrinh@gmail.com', N'admin', N'AQAAAAEAACcQAAAAEP9YE+2W0mpOvm8RImcvEbUqG399XULBo0cfGid8unV1MXf3izok9N1sQQNQZ4kLfg==', NULL, CAST(0 AS bit), N'', N'TiRin', CAST(0 AS bit), N'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Dob', N'Email', N'EmailConfirmed', N'GioiTinh', N'Ho', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'Ten', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AppUsers]'))
    SET IDENTITY_INSERT [AppUsers] OFF;

GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200401101132_SeedIdenUser', N'3.1.3');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[LienHes]') AND [c].[name] = N'NgayGui');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [LienHes] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [LienHes] ALTER COLUMN [NgayGui] datetime2 NOT NULL;
ALTER TABLE [LienHes] ADD DEFAULT (getdate()) FOR [NgayGui];

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'67130f0b-dbcc-43fc-a652-d06c1cec5d04'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'8a0ce7e2-b59e-4caa-91c5-3e948062fff0', [PasswordHash] = N'AQAAAAEAACcQAAAAEHkW9CONlOzAsn5vJ49ROUu69EniXBv2r7uezQliCoz2e9O8tUrQXpiWlN2951gecA=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200414091149_updatetblLH', N'3.1.3');

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TinTucs]') AND [c].[name] = N'NgayCapNhat');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TinTucs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [TinTucs] ALTER COLUMN [NgayCapNhat] datetime2 NOT NULL;
ALTER TABLE [TinTucs] ADD DEFAULT (getdate()) FOR [NgayCapNhat];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MComments]') AND [c].[name] = N'NgayComment');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [MComments] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [MComments] ALTER COLUMN [NgayComment] datetime2 NOT NULL;
ALTER TABLE [MComments] ADD DEFAULT (getdate()) FOR [NgayComment];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Khuyenmais]') AND [c].[name] = N'FromDate');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Khuyenmais] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Khuyenmais] ALTER COLUMN [FromDate] datetime2 NOT NULL;
ALTER TABLE [Khuyenmais] ADD DEFAULT (getdate()) FOR [FromDate];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Giaodichs]') AND [c].[name] = N'NgayGd');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Giaodichs] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Giaodichs] ALTER COLUMN [NgayGd] datetime2 NOT NULL;
ALTER TABLE [Giaodichs] ADD DEFAULT (getdate()) FOR [NgayGd];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DonHangs]') AND [c].[name] = N'SDT');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [DonHangs] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [DonHangs] ALTER COLUMN [SDT] nvarchar(max) NOT NULL;

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DonHangs]') AND [c].[name] = N'NguoiNhan');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [DonHangs] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [DonHangs] ALTER COLUMN [NguoiNhan] nvarchar(max) NOT NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DonHangs]') AND [c].[name] = N'NgayDat');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [DonHangs] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [DonHangs] ALTER COLUMN [NgayDat] datetime2 NOT NULL;
ALTER TABLE [DonHangs] ADD DEFAULT (getdate()) FOR [NgayDat];

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'8f36413d-bc7d-4db3-abf9-8fd766cc9a60'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'95b9779b-0d56-4592-9240-4b0eee80c6d5', [PasswordHash] = N'AQAAAAEAACcQAAAAECJrrN0lo/mV/f8bFeo2URQYEIRiikNfQ1CkMJKDdh08DMlFMSN5aTv2aIctyT8liA=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200414142724_updatedb', N'3.1.3');

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'2e6dd8b9-f220-447a-a8a9-38e5b55afa1d'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'c7d97725-b3f6-4778-bfd7-2615ebf3f1af', [PasswordHash] = N'AQAAAAEAACcQAAAAEGaV61RdYuzJL3BRY3+iougswkuKx5RF8jPGk1u1W/9vcAJNYN6rQQQYatLnlMxxXw=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200416073648_test', N'3.1.3');

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DonHangs]') AND [c].[name] = N'Tinhtrang');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [DonHangs] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [DonHangs] ALTER COLUMN [Tinhtrang] int NOT NULL;
ALTER TABLE [DonHangs] ADD DEFAULT 0 FOR [Tinhtrang];

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'89414d44-d02e-4add-bce3-1bfd2ba592d3'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'856bf655-1b9d-4498-b0d5-187eaac808ae', [PasswordHash] = N'AQAAAAEAACcQAAAAEAAzpAc4cxbOUp0cHpIAmXQl3Qjeb6yzEhpcEoMqnoZKPn/pJDKGRbrb0KtP3jcHEA=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200421051142_upTTDH', N'3.1.3');

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Mangas]') AND [c].[name] = N'Ma');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Mangas] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Mangas] DROP COLUMN [Ma];

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'da691773-0f24-4863-a0a1-e7ad9efc1936'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'523afc1c-8a42-4eb1-8d2d-73c136f83251', [PasswordHash] = N'AQAAAAEAACcQAAAAEJwAOTAgUF83+b1jQAWymfd7o4uamyvyRfrBeE3vG3ToQOp8RDsvX59e4Of41BI2hQ=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200502150414_uptest', N'3.1.3');

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppUsers]') AND [c].[name] = N'GioiTinh');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [AppUsers] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [AppUsers] ALTER COLUMN [GioiTinh] int NOT NULL;

GO

CREATE TABLE [Payments] (
    [Id] int NOT NULL IDENTITY,
    [PaymentStatus] nvarchar(max) NULL,
    [PaymentDate] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Payments] PRIMARY KEY ([Id])
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'67cb290f-c478-411d-a4bf-9f00dfe82979'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'78f7547c-406d-497a-b083-cf6949a6bea2', [GioiTinh] = 1, [PasswordHash] = N'AQAAAAEAACcQAAAAEN4HuAXdk4b63oFnSTagqro/RF08Lfl6MvM+zglCUmaVKoDfR/jEA9dewwfOKPmq2w=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200515175721_addtbPaym', N'3.1.3');

GO

ALTER TABLE [Payments] ADD [Amount] real NOT NULL DEFAULT CAST(0 AS real);

GO

ALTER TABLE [Payments] ADD [CreditCardId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [DonHangs] ADD [DiaChiId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [DonHangs] ADD [HoaDonId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [DonHangs] ADD [Ngaynhan] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [DonHangs] ADD [PaymentId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [DiaChis] ADD [AppUserId] uniqueidentifier NULL;

GO

ALTER TABLE [DiaChis] ADD [Ghichu] nvarchar(max) NULL;

GO

ALTER TABLE [DiaChis] ADD [Sdt] nvarchar(max) NULL;

GO

ALTER TABLE [DiaChis] ADD [Tennguoinhan] nvarchar(max) NULL;

GO

ALTER TABLE [Banners] ADD [Anhien] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

CREATE TABLE [CreditCards] (
    [Id] int NOT NULL IDENTITY,
    [CC_NUM] nvarchar(max) NULL,
    [Holder_name] nvarchar(max) NULL,
    [Expire_date] datetime2 NOT NULL,
    [DiaChiId] int NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_CreditCards] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CreditCards_DiaChis_DiaChiId] FOREIGN KEY ([DiaChiId]) REFERENCES [DiaChis] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [DonHangHistories] (
    [Id] int NOT NULL IDENTITY,
    [DonHangId] int NOT NULL,
    [Tongtien] real NOT NULL,
    [Trangthai] int NOT NULL,
    [Ghichu] nvarchar(max) NULL,
    [Ngaplap] datetime2 NOT NULL,
    CONSTRAINT [PK_DonHangHistories] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [HoaDons] (
    [Id] int NOT NULL IDENTITY,
    [CreditCardId] int NOT NULL,
    [Creation_date] datetime2 NOT NULL DEFAULT (getdate()),
    [State_desc] nvarchar(max) NULL,
    [Notes] nvarchar(max) NULL,
    [Timestamp] datetime2 NOT NULL,
    CONSTRAINT [PK_HoaDons] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HoaDons_CreditCards_CreditCardId] FOREIGN KEY ([CreditCardId]) REFERENCES [CreditCards] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [HoaDonHistories] (
    [HoaDonId] int NOT NULL,
    [State_desc] nvarchar(max) NULL,
    [Notes] nvarchar(max) NULL,
    [Timestamp] datetime2 NOT NULL,
    CONSTRAINT [PK_HoaDonHistories] PRIMARY KEY ([HoaDonId]),
    CONSTRAINT [FK_HoaDonHistories_HoaDons_HoaDonId] FOREIGN KEY ([HoaDonId]) REFERENCES [HoaDons] ([Id]) ON DELETE CASCADE
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'c1426bb8-7c56-4310-9b77-50b93b19f0f5'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'53ca57b6-828a-4f59-8947-c6c69c3ae33d', [PasswordHash] = N'AQAAAAEAACcQAAAAEC1uUeshhHaPD/IBWX+poDuqAW+R5um5X1eSc1bCwK7UKOAsQvNXAswApOS5pSkEhw=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_Payments_CreditCardId] ON [Payments] ([CreditCardId]);

GO

CREATE INDEX [IX_DonHangs_DiaChiId] ON [DonHangs] ([DiaChiId]);

GO

CREATE INDEX [IX_DonHangs_HoaDonId] ON [DonHangs] ([HoaDonId]);

GO

CREATE INDEX [IX_DonHangs_PaymentId] ON [DonHangs] ([PaymentId]);

GO

CREATE INDEX [IX_DiaChis_AppUserId] ON [DiaChis] ([AppUserId]);

GO

CREATE INDEX [IX_CreditCards_DiaChiId] ON [CreditCards] ([DiaChiId]);

GO

CREATE INDEX [IX_CreditCards_UserId] ON [CreditCards] ([UserId]);

GO

CREATE INDEX [IX_HoaDons_CreditCardId] ON [HoaDons] ([CreditCardId]);

GO

ALTER TABLE [DiaChis] ADD CONSTRAINT [FK_DiaChis_AppUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AppUsers] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Payments] ADD CONSTRAINT [FK_Payments_CreditCards_CreditCardId] FOREIGN KEY ([CreditCardId]) REFERENCES [CreditCards] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200521171122_HTHD', N'3.1.3');

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'd56bd054-c491-4833-9985-8410a8e2b6ed'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'fd800c58-1b35-48d8-8597-71ca5af0519c', [PasswordHash] = N'AQAAAAEAACcQAAAAEOK2euRp7l3V9bg2loUnlUt0VT2GsMuWUOwdInBp21pmPTNkdIeZNx31rhfiUYg8sg=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200523175653_upDH', N'3.1.3');

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'5c8f6fbd-9c90-4bd7-8803-fb539a9861fc'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'd612a4b5-89ee-40f3-861b-b5811fde152d', [PasswordHash] = N'AQAAAAEAACcQAAAAEF7VpkcXX6b2o6t+NrGIjy65lxdDUj6EM4tD6xTRMaQlURWH9wNjWdvo+QyUvvBZWw=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200523175953_mmm', N'3.1.3');

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'd14a6ca5-9592-4d8e-a94b-d78bce62ede2'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'f083d782-e966-46a1-a38a-eea0f0fd2f88', [PasswordHash] = N'AQAAAAEAACcQAAAAELGiOszBDevdimbo2BwFEdRW69f4X6U9jqyTXJbvDVYx0h27gQKUzlDX/TwzFaXAVg=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200523182259_ppp', N'3.1.3');

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'9d3c416f-87be-43fa-ae6f-8323a91c50ed'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'84004713-731e-4187-a6d3-94cf6e958dd3', [PasswordHash] = N'AQAAAAEAACcQAAAAEAYsJ/6YYEEBqNVMddNwIvCFjGnzPq7DsF20Lye88u1L7xjHWtFoSBZ3R1zh0DacvA=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200523195118_zzz', N'3.1.3');

GO

ALTER TABLE [DonHangDetails] DROP CONSTRAINT [PK_DonHangDetails];

GO

ALTER TABLE [Mangas] ADD [HinhAnh] nvarchar(max) NULL;

GO

ALTER TABLE [DonHangDetails] ADD CONSTRAINT [PK_DonHangDetails] PRIMARY KEY ([DonHangId], [MangaId]);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'56f459ce-9f4b-4f89-bfb6-c3d2af540491'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'7e3bdd79-cfee-45ad-8231-8c84b3dd66fa', [PasswordHash] = N'AQAAAAEAACcQAAAAEJiTCi/kKdK3Ux1YDsd/PJNG8ijj/Nd/mcON6yKM1zTl7wYHf8rdAkZ8DujsrS7MXA=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200524063350_upha', N'3.1.3');

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'90045954-5c66-4356-bdd5-3039c97833d9'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'4408eddd-6f26-4b86-bcaa-6bd4df0dfe4b', [PasswordHash] = N'AQAAAAEAACcQAAAAEC/okFrMrgOPvaRw3dmfABd71wsKqUG4uj3k0fPwR7xOGXCwI8bN+vH7i0tqfPPuVA=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200524082840_dxrm', N'3.1.3');

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppUsers]') AND [c].[name] = N'Dob');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [AppUsers] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [AppUsers] ALTER COLUMN [Dob] datetime2 NOT NULL;
ALTER TABLE [AppUsers] ADD DEFAULT (getdate()) FOR [Dob];

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'e80c6188-2b55-4781-bbae-ad86bf923bfa'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'088443aa-5dae-4aa5-871c-44db7976ed7c', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEJ/fhOvfFXOCLF5OKXlYe9aadXtl6Frf2Jkh+inlAbn9SCZEczLL+Nas5y0Xbw6WRg=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200601013846_upDOBuser', N'3.1.3');

GO

ALTER TABLE [TinTucs] ADD [Meta] nvarchar(max) NULL;

GO

ALTER TABLE [Theloais] ADD [Meta] nvarchar(max) NULL;

GO

ALTER TABLE [NgonnguMns] ADD [Anhien] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [NgonnguMns] ADD [Meta] nvarchar(max) NULL;

GO

ALTER TABLE [Menus] ADD [Anhien] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [Menus] ADD [Meta] nvarchar(max) NULL;

GO

ALTER TABLE [Mangas] ADD [Meta] nvarchar(max) NULL;

GO

ALTER TABLE [GioHangs] ADD [Meta] nvarchar(max) NULL;

GO

ALTER TABLE [Banners] ADD [Meta] nvarchar(max) NULL;

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'b822f53b-89be-4452-8f5a-9c4880cfe441'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'35c6f563-8a20-47c1-955d-4bcf2bd2b998', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEPj+1KLJi1BvCd8npbjSkPRWy1Kbg2SZpztE4cb39imBzLsoywSB5jUCNQFFJHS3SQ=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200617140812_addMeta', N'3.1.3');

GO

ALTER TABLE [DonHangs] ADD [Email] nvarchar(max) NULL;

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'79eb45de-3754-4388-9142-4ab3f10f0a6e'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'f91fe9d9-7ba7-4324-89d4-2f21791833ff', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAENyDqhaJJBL5hlo3SSzkxX/pPkBlM/+EoVF61S8+ombaxLRbgH4RdjA6bm22mXR6eQ=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200619202701_addeDH', N'3.1.3');

GO

ALTER TABLE [Banners] ADD [Noidung] nvarchar(max) NULL;

GO

ALTER TABLE [Banners] ADD [Tieude] nvarchar(max) NULL;

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'180725b0-2411-44cc-990e-f96a1abb90f5'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'0821c02b-bdf0-42eb-985b-43083db81732', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAECGonR5iyYZRSy2y4wIlE3itu5Mdd0o4K/mgkbYXrT/tClzcW5mu8WDhtJlGCehM6w=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200628003224_adddesBanner', N'3.1.3');

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Banners]') AND [c].[name] = N'Hinh');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Banners] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Banners] ALTER COLUMN [Hinh] nvarchar(200) NOT NULL;

GO

ALTER TABLE [Banners] ADD [FileSize] bigint NOT NULL DEFAULT CAST(0 AS bigint);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'f1b73308-4553-43ff-a73c-3c900e7b0599'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'b3c5f242-6c24-4c31-93ac-86c36bd0d355', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAENyirvdpwCRqgekhT3TUj/nvrD3YurBCZiq1onS41BTnTD4aqfB4KbhJUnVk7NKtOQ=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200628182400_upbanner', N'3.1.3');

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TinTucs]') AND [c].[name] = N'Hinh');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [TinTucs] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [TinTucs] DROP COLUMN [Hinh];

GO

ALTER TABLE [TinTucs] ADD [HinhAnhtintuc] nvarchar(200) NOT NULL DEFAULT N'';

GO

ALTER TABLE [TinTucs] ADD [NoiDungTomTat] nvarchar(max) NOT NULL DEFAULT N'';

GO

ALTER TABLE [TinTucs] ADD [Tacgia] nvarchar(max) NOT NULL DEFAULT N'';

GO

CREATE TABLE [Blogs] (
    [Id] int NOT NULL IDENTITY,
    [TuaDe] nvarchar(50) NOT NULL,
    [HinhAnhblog] nvarchar(200) NOT NULL,
    [NoiDungBlog] nvarchar(max) NOT NULL,
    [NgayCapNhat] datetime2 NOT NULL DEFAULT (getdate()),
    [AnHien] bit NOT NULL DEFAULT CAST(1 AS bit),
    [Meta] nvarchar(max) NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id])
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'2fbd283f-27d3-45e8-bf55-2e4f7682c4ed'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'66681dd6-d42a-41e6-bb0a-99be1da5817b', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEAe7DeoZ+ghIJvEfAUjTj85ryRT8qcMjLVFJ9pnzvAiGQ1D5lRPRchhCzcH17NjI5g=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200917153748_addtbBlog', N'3.1.3');

GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Khuyenmais]') AND [c].[name] = N'MangaIds');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Khuyenmais] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Khuyenmais] DROP COLUMN [MangaIds];

GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Khuyenmais]') AND [c].[name] = N'MangaTheloaiIds');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Khuyenmais] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [Khuyenmais] DROP COLUMN [MangaTheloaiIds];

GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Khuyenmais]') AND [c].[name] = N'ToDate');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Khuyenmais] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [Khuyenmais] ALTER COLUMN [ToDate] datetime2 NOT NULL;
ALTER TABLE [Khuyenmais] ADD DEFAULT (getdate()) FOR [ToDate];

GO

ALTER TABLE [Khuyenmais] ADD [CouponCode] nvarchar(max) NOT NULL DEFAULT N'';

GO

ALTER TABLE [Khuyenmais] ADD [MangaId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Khuyenmais] ADD [MaximumDiscountedQuantity] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Khuyenmais] ADD [TheLoaiId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [DonHangDetails] ADD [Khuyenmai] real NOT NULL DEFAULT CAST(0 AS real);

GO

CREATE TABLE [KhuyenmaiLichsuSudungs] (
    [Id] int NOT NULL IDENTITY,
    [KhuyenmaiId] int NOT NULL,
    [DonHangId] int NOT NULL,
    [NgayTao] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_KhuyenmaiLichsuSudungs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_KhuyenmaiLichsuSudungs_DonHangs_DonHangId] FOREIGN KEY ([DonHangId]) REFERENCES [DonHangs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_KhuyenmaiLichsuSudungs_Khuyenmais_KhuyenmaiId] FOREIGN KEY ([KhuyenmaiId]) REFERENCES [Khuyenmais] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [KhuyenmaiMangas] (
    [KhuyenmaiId] int NOT NULL,
    [MangaId] int NOT NULL,
    CONSTRAINT [PK_KhuyenmaiMangas] PRIMARY KEY ([KhuyenmaiId], [MangaId]),
    CONSTRAINT [FK_KhuyenmaiMangas_Khuyenmais_KhuyenmaiId] FOREIGN KEY ([KhuyenmaiId]) REFERENCES [Khuyenmais] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_KhuyenmaiMangas_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'5a211df3-8578-4b83-bd8a-d3e0c27066ba'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'4a996704-cb29-4806-9c5f-722f51eaf0c0', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEFzkwbpIOnl9khiYPVRvyEWPIMtsQbjeONJA2EzHlHCFAMMDf/o5QMN7wwHhQbCn7Q=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_KhuyenmaiLichsuSudungs_DonHangId] ON [KhuyenmaiLichsuSudungs] ([DonHangId]);

GO

CREATE INDEX [IX_KhuyenmaiLichsuSudungs_KhuyenmaiId] ON [KhuyenmaiLichsuSudungs] ([KhuyenmaiId]);

GO

CREATE INDEX [IX_KhuyenmaiMangas_MangaId] ON [KhuyenmaiMangas] ([MangaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201126171533_khuyenmai2', N'3.1.3');

GO

DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Khuyenmais]') AND [c].[name] = N'MangaId');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Khuyenmais] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [Khuyenmais] DROP COLUMN [MangaId];

GO

DECLARE @var18 sysname;
SELECT @var18 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Khuyenmais]') AND [c].[name] = N'TheLoaiId');
IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Khuyenmais] DROP CONSTRAINT [' + @var18 + '];');
ALTER TABLE [Khuyenmais] DROP COLUMN [TheLoaiId];

GO

CREATE TABLE [KhuyenmaiTheloais] (
    [KhuyenmaiId] int NOT NULL,
    [TheLoaiId] int NOT NULL,
    CONSTRAINT [PK_KhuyenmaiTheloais] PRIMARY KEY ([KhuyenmaiId], [TheLoaiId]),
    CONSTRAINT [FK_KhuyenmaiTheloais_Khuyenmais_KhuyenmaiId] FOREIGN KEY ([KhuyenmaiId]) REFERENCES [Khuyenmais] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_KhuyenmaiTheloais_Theloais_TheLoaiId] FOREIGN KEY ([TheLoaiId]) REFERENCES [Theloais] ([Id]) ON DELETE CASCADE
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'6fb480f5-8023-4d54-9e86-7d2029546151'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'aad3265f-c003-4fec-a376-d04ca8093d66', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEHNlGWb9JZLWkvDMKouGLLJpYGW3oMqri4XvX4SZnyh7Q2iZ4sjJb2HIfnEs2xOnEw=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_KhuyenmaiTheloais_TheLoaiId] ON [KhuyenmaiTheloais] ([TheLoaiId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201126173821_khuyenmaitheloai', N'3.1.3');

GO

DECLARE @var19 sysname;
SELECT @var19 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TinTucs]') AND [c].[name] = N'TieuDe');
IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [TinTucs] DROP CONSTRAINT [' + @var19 + '];');
ALTER TABLE [TinTucs] ALTER COLUMN [TieuDe] nvarchar(max) NOT NULL;

GO

DECLARE @var20 sysname;
SELECT @var20 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TinTucs]') AND [c].[name] = N'Tacgia');
IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [TinTucs] DROP CONSTRAINT [' + @var20 + '];');
ALTER TABLE [TinTucs] ALTER COLUMN [Tacgia] nvarchar(max) NULL;

GO

DECLARE @var21 sysname;
SELECT @var21 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TinTucs]') AND [c].[name] = N'HinhAnhtintuc');
IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [TinTucs] DROP CONSTRAINT [' + @var21 + '];');
ALTER TABLE [TinTucs] ALTER COLUMN [HinhAnhtintuc] nvarchar(max) NOT NULL;

GO

CREATE TABLE [WishLists] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_WishLists] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WishLists_AppUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AppUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [WishListItems] (
    [Id] int NOT NULL IDENTITY,
    [WishListId] int NOT NULL,
    [MangaId] int NOT NULL,
    [Gia] real NOT NULL,
    [Soluongdat] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_WishListItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WishListItems_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WishListItems_WishLists_WishListId] FOREIGN KEY ([WishListId]) REFERENCES [WishLists] ([Id]) ON DELETE CASCADE
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'e8b4163b-958a-4f43-8419-da46788bc456'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'37d8118b-c609-487d-899a-103167752578', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEOHBiQymLbfKTW6SWU1kl8/z+i+oVLi2wenQP5Ss+4O7rpU4269Jn6F+ZFV91GZI2g=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_WishListItems_MangaId] ON [WishListItems] ([MangaId]);

GO

CREATE INDEX [IX_WishListItems_WishListId] ON [WishListItems] ([WishListId]);

GO

CREATE INDEX [IX_WishLists_UserId] ON [WishLists] ([UserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201201183517_addWishList', N'3.1.3');

GO

ALTER TABLE [GioHangs] DROP CONSTRAINT [FK_GioHangs_Mangas_MangaId];

GO

DROP INDEX [IX_GioHangs_MangaId] ON [GioHangs];

GO

DECLARE @var22 sysname;
SELECT @var22 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GioHangs]') AND [c].[name] = N'Gia');
IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [GioHangs] DROP CONSTRAINT [' + @var22 + '];');
ALTER TABLE [GioHangs] DROP COLUMN [Gia];

GO

DECLARE @var23 sysname;
SELECT @var23 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GioHangs]') AND [c].[name] = N'MangaId');
IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [GioHangs] DROP CONSTRAINT [' + @var23 + '];');
ALTER TABLE [GioHangs] DROP COLUMN [MangaId];

GO

DECLARE @var24 sysname;
SELECT @var24 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[GioHangs]') AND [c].[name] = N'Meta');
IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [GioHangs] DROP CONSTRAINT [' + @var24 + '];');
ALTER TABLE [GioHangs] DROP COLUMN [Meta];

GO

ALTER TABLE [GioHangs] ADD [CouponCode] nvarchar(max) NULL;

GO

ALTER TABLE [GioHangs] ADD [CreatedOn] datetime2 NOT NULL DEFAULT (getdate());

GO

ALTER TABLE [GioHangs] ADD [OrderNote] nvarchar(max) NULL;

GO

CREATE TABLE [GioHangDetails] (
    [Id] int NOT NULL IDENTITY,
    [GioHangId] int NOT NULL,
    [MangaId] int NOT NULL,
    [Gia] real NOT NULL,
    [Soluongdat] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_GioHangDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GioHangDetails_GioHangs_GioHangId] FOREIGN KEY ([GioHangId]) REFERENCES [GioHangs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_GioHangDetails_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'9a7f9f7e-d48f-48a8-8f55-96eeb3bf2333'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'fcc18f67-ea39-46f8-8d2f-aae73f46b393', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEBjRu6XBFw9VvwZ3A34RwIct0VoVmZ0q/qS5uOdjS0dfYulU6MAICg1uHsbCmtxaIw=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_GioHangDetails_GioHangId] ON [GioHangDetails] ([GioHangId]);

GO

CREATE INDEX [IX_GioHangDetails_MangaId] ON [GioHangDetails] ([MangaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201202053535_upCartItem', N'3.1.3');

GO

DECLARE @var25 sysname;
SELECT @var25 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MComments]') AND [c].[name] = N'TieuDe');
IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [MComments] DROP CONSTRAINT [' + @var25 + '];');
ALTER TABLE [MComments] DROP COLUMN [TieuDe];

GO

DECLARE @var26 sysname;
SELECT @var26 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MComments]') AND [c].[name] = N'NoiDung');
IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [MComments] DROP CONSTRAINT [' + @var26 + '];');
ALTER TABLE [MComments] ALTER COLUMN [NoiDung] nvarchar(max) NOT NULL;

GO

ALTER TABLE [MComments] ADD [Status] int NOT NULL DEFAULT 0;

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'ee37d92c-02e2-47f1-adf6-9da93e5cf360'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'ab47ca11-2701-4516-ab71-a2b278fe960f', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAELctGGY6SHTDpiu0iJ957W1iwmAr/beYiPBQmN/Xgjp00dhm6TBoLZL7xBT+WrHM7g=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201210163400_upCmt', N'3.1.3');

GO

DECLARE @var27 sysname;
SELECT @var27 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DonHangs]') AND [c].[name] = N'DiaChiNhan');
IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [DonHangs] DROP CONSTRAINT [' + @var27 + '];');
ALTER TABLE [DonHangs] ALTER COLUMN [DiaChiNhan] nvarchar(500) NOT NULL;

GO

ALTER TABLE [DonHangs] ADD [TinhtrangThanhtoan] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [DonHangs] ADD [TongTien] real NOT NULL DEFAULT CAST(0 AS real);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'f39771a8-185c-4bba-8100-098d0f2109b7'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'd8b7851c-54e5-4b0b-bfd6-3fbb90543b4a', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEGb4H4Xn39dU1SQlT6X+qZQgqhtRdOcTlRw4fiWomGin37wDJXNR/OLnLuDmcB0BHA=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201214110039_upDonhang', N'3.1.3');

GO

CREATE TABLE [MenuItems] (
    [Id] int NOT NULL IDENTITY,
    [MenuId] int NOT NULL,
    [ParentId] int NOT NULL,
    [CustomLink] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Meta] nvarchar(max) NULL,
    [ThuTu] int NOT NULL,
    CONSTRAINT [PK_MenuItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_MenuItems_Menus_MenuId] FOREIGN KEY ([MenuId]) REFERENCES [Menus] ([Id]) ON DELETE CASCADE
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'96f62b9a-14f0-413a-ac31-f529b193ef49'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'bb26b8f3-8dc5-45cb-a66a-a7e8fcc7b9af', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEJYIsyRLfsPfu8XsbMu7VZFFsHji9tvM8IYtwsiaJq1eA6UOrkdqr0b8Mi4aDUxphQ=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_MenuItems_MenuId] ON [MenuItems] ([MenuId]);

GO

CREATE INDEX [IX_MenuItems_ParentId] ON [MenuItems] ([ParentId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201218171857_upMenu', N'3.1.3');

GO

CREATE TABLE [Shipments] (
    [Id] int NOT NULL IDENTITY,
    [OrderId] int NOT NULL,
    [VendorId] int NOT NULL,
    [CreateById] int NOT NULL,
    [CreateOn] datetime2 NOT NULL DEFAULT (getdate()),
    CONSTRAINT [PK_Shipments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Shipments_DonHangs_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [DonHangs] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ShipmentTableRates] (
    [Id] int NOT NULL IDENTITY,
    [DistricId] int NOT NULL,
    [Note] nvarchar(max) NULL,
    [ShippingPrice] decimal(18,2) NOT NULL DEFAULT 0.0,
    CONSTRAINT [PK_ShipmentTableRates] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ShipmentItems] (
    [Id] int NOT NULL IDENTITY,
    [ShipmentId] int NOT NULL,
    [OrderItemId] int NOT NULL,
    [MangaId] int NOT NULL,
    [Quantity] int NOT NULL,
    [DonHangDetailDonHangId] int NULL,
    [DonHangDetailMangaId] int NULL,
    CONSTRAINT [PK_ShipmentItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ShipmentItems_Mangas_MangaId] FOREIGN KEY ([MangaId]) REFERENCES [Mangas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ShipmentItems_Shipments_ShipmentId] FOREIGN KEY ([ShipmentId]) REFERENCES [Shipments] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ShipmentItems_DonHangDetails_DonHangDetailDonHangId_DonHangDetailMangaId] FOREIGN KEY ([DonHangDetailDonHangId], [DonHangDetailMangaId]) REFERENCES [DonHangDetails] ([DonHangId], [MangaId]) ON DELETE NO ACTION
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'adca3a20-06ab-4f00-82bb-f35635ceb64f'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'bf0ea9c3-da69-4f7a-874c-1c1b69c6b4d8', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEA96AXx0X/Lodf5bXZyqrW0lpxHEFSuH4HBomm8GYnGox+9/TCVPevOYUAcEYkP2tA=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_ShipmentItems_MangaId] ON [ShipmentItems] ([MangaId]);

GO

CREATE INDEX [IX_ShipmentItems_ShipmentId] ON [ShipmentItems] ([ShipmentId]);

GO

CREATE INDEX [IX_ShipmentItems_DonHangDetailDonHangId_DonHangDetailMangaId] ON [ShipmentItems] ([DonHangDetailDonHangId], [DonHangDetailMangaId]);

GO

CREATE INDEX [IX_Shipments_OrderId] ON [Shipments] ([OrderId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201219080421_addShipment', N'3.1.3');

GO

CREATE TABLE [ShipmentProviders] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [IsEnabled] bit NOT NULL DEFAULT CAST(1 AS bit),
    [ConfigureUrl] nvarchar(max) NULL,
    [AdditionalSettings] nvarchar(max) NULL,
    CONSTRAINT [PK_ShipmentProviders] PRIMARY KEY ([Id])
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'e3f24f5d-1078-4926-8ae1-9d19abdee8e1'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'823e4862-dc80-4fb8-a4a3-c2edd1121bca', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEI07tpxMJXiMYvOdSowUDTlGhjYxVubo32Y7+71uYYpJB9PGzR8ub20a/n63LAeJ5A=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201223043910_addShippingProvider', N'3.1.3');

GO

CREATE TABLE [Provinces] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Type] nvarchar(max) NULL,
    [TelephoneCode] int NOT NULL,
    [ZipCode] nvarchar(max) NULL,
    [CountryId] int NOT NULL,
    [CountryCode] nvarchar(max) NULL,
    [SortOrder] int NOT NULL,
    [IsPublished] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Provinces] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Districts] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Type] nvarchar(max) NULL,
    [LatiLongTude] nvarchar(max) NULL,
    [ProvinceId] int NOT NULL,
    [SortOrder] int NOT NULL,
    [IsPublished] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Districts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Districts_Provinces_ProvinceId] FOREIGN KEY ([ProvinceId]) REFERENCES [Provinces] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Wards] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Type] nvarchar(max) NULL,
    [LatiLongTude] nvarchar(max) NULL,
    [DistrictId] int NOT NULL,
    [SortOrder] int NOT NULL,
    [IsPublished] bit NOT NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Wards] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Wards_Districts_DistrictId] FOREIGN KEY ([DistrictId]) REFERENCES [Districts] ([Id]) ON DELETE CASCADE
);

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'79541fe9-90dd-4715-99c1-e4ea3449672c'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'58ec46b4-859d-437e-b2bc-cb5863f38c29', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAELmgQWWNAjm0pNDuO5mPh0u5wZ7FioP/7sC7aCX3zyuahUCrrSnU18XrE7QcEg8oEw=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_Districts_ProvinceId] ON [Districts] ([ProvinceId]);

GO

CREATE INDEX [IX_Wards_DistrictId] ON [Wards] ([DistrictId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201223084414_addLocal', N'3.1.3');

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'614183e3-a180-496d-8a6f-d946eda829a1'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'a268198c-33de-4f4e-b498-87ca0b7e2f57', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAELVG/U3416pceFmsaRkd+1N76h71v3mJnDOIwDoh3PdbNUNnQseU2Q+JduJ4M8XKQg=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Anhien', N'Meta', N'TenMenu', N'ThuTu') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] ON;
INSERT INTO [Menus] ([Id], [Anhien], [Meta], [TenMenu], [ThuTu])
VALUES (1, CAST(1 AS bit), N'menu-header', N'Menu Header', 1),
(2, CAST(1 AS bit), N'menu-footer', N'Menu Footer', 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Anhien', N'Meta', N'TenMenu', N'ThuTu') AND [object_id] = OBJECT_ID(N'[Menus]'))
    SET IDENTITY_INSERT [Menus] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201223143555_upseed', N'3.1.3');

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'c9cf8b89-1b68-47fa-a446-e1d212b24351'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'a31fdbf2-dae0-4b98-85db-27802816d486', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAELTO4D10AHfw8AcnUqY6idvsNldt2O7kh6bNDIULjSt8axGVPNZkqSArMsk3knFNGA=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201223182918_updatemenu', N'3.1.3');

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'25c5f5a9-2fa1-4838-9cd5-c880fe4c6ec7'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'4eb83ab3-141b-411e-b954-5cb31830b9d8', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEOKjeejwQ/nlQRUPd9Lm7NqxjGKe4gF18bZgVuSpK7h6wiRzedN1VUYbSYx21Iyfjg=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201223183316_umenui', N'3.1.3');

GO

DROP INDEX [IX_MenuItems_ParentId] ON [MenuItems];

GO

DECLARE @var28 sysname;
SELECT @var28 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MenuItems]') AND [c].[name] = N'ParentId');
IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [MenuItems] DROP CONSTRAINT [' + @var28 + '];');
ALTER TABLE [MenuItems] DROP COLUMN [ParentId];

GO

UPDATE [AppRoles] SET [ConcurrencyStamp] = N'a82842af-b117-4422-8d1d-8a3716b19809'
WHERE [Id] = '8d04dce2-969a-435d-bba4-df3f325983dc';
SELECT @@ROWCOUNT;


GO

UPDATE [AppUsers] SET [ConcurrencyStamp] = N'9706cb3a-36bd-4ca1-b663-5c01479665a4', [Dob] = '2000-01-01T00:00:00.0000000', [PasswordHash] = N'AQAAAAEAACcQAAAAEL7ij2uLwWaYkY+84mJ3LqnKV930FjgsocGRpXzipskZj2bG3CFfAlxBo/7ojAUSsg=='
WHERE [Id] = '69bd714f-9576-45ba-b5b7-f00649be00de';
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

UPDATE [Mangas] SET [Anhien] = CAST(1 AS bit)
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201223183803_upMenuu', N'3.1.3');

GO

