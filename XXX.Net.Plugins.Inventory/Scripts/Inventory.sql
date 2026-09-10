/* XXX.Net.Plugins.Inventory - SQL Server initial schema.
   Normally prefer EF Core Add-Migration/Update-Database so this script is only a fallback/reference. */

CREATE TABLE [InvDomain](
 [Id] bigint NOT NULL PRIMARY KEY,
 [TenantId] bigint NOT NULL,
 [DepartmentId] bigint NOT NULL,
 [Code] nvarchar(64) NOT NULL,
 [Name] nvarchar(128) NULL,
 [Enabled] bit NOT NULL DEFAULT(1),
 [IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()), [CreatedBy] bigint NOT NULL, [CreatedByName] nvarchar(64) NULL,
 [UpdatedTime] datetime NULL, [UpdatedBy] bigint NULL, [UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvDomain] ON [InvDomain]([TenantId],[DepartmentId],[Code]);

CREATE TABLE [InvType](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[DomainId] bigint NOT NULL,[Code] nvarchar(64) NOT NULL,[Name] nvarchar(128) NULL,[Enabled] bit NOT NULL DEFAULT(1),[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvType] ON [InvType]([TenantId],[DomainId],[Code]);

CREATE TABLE [InvAttributeDefinition](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[InventoryTypeId] bigint NOT NULL,[Code] nvarchar(64) NOT NULL,[Name] nvarchar(128) NULL,[DataType] int NOT NULL,[Required] bit NOT NULL,[Unique] bit NOT NULL,[IsKey] bit NOT NULL,[Sort] int NOT NULL,[OptionsJson] nvarchar(max) NULL,[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvAttributeDefinition] ON [InvAttributeDefinition]([TenantId],[InventoryTypeId],[Code]);

CREATE TABLE [InvItem](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[DomainId] bigint NOT NULL,[InventoryTypeId] bigint NOT NULL,[Code] nvarchar(128) NOT NULL,[Name] nvarchar(128) NULL,[Unit] nvarchar(32) NULL,[Status] int NOT NULL,[AttributesJson] nvarchar(max) NULL,[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvItem] ON [InvItem]([TenantId],[DomainId],[Code]);

CREATE TABLE [InvItemAttributeIndex](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[ItemId] bigint NOT NULL,[AttributeDefinitionId] bigint NOT NULL,[AttributeValue] nvarchar(512) NOT NULL,[Name] nvarchar(128) NULL,[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvItemAttributeIndex] ON [InvItemAttributeIndex]([TenantId],[ItemId],[AttributeDefinitionId]);
CREATE INDEX [IX_InvItemAttributeIndex_Search] ON [InvItemAttributeIndex]([TenantId],[AttributeDefinitionId],[AttributeValue]);

CREATE TABLE [InvWarehouse](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[DomainId] bigint NOT NULL,[DepartmentId] bigint NULL,[Code] nvarchar(64) NOT NULL,[Name] nvarchar(128) NULL,[Enabled] bit NOT NULL DEFAULT(1),[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvWarehouse] ON [InvWarehouse]([TenantId],[DomainId],[Code]);

CREATE TABLE [InvLocation](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[WarehouseId] bigint NOT NULL,[ParentId] bigint NULL,[Code] nvarchar(64) NOT NULL,[Name] nvarchar(128) NULL,[Enabled] bit NOT NULL DEFAULT(1),[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvLocation] ON [InvLocation]([TenantId],[WarehouseId],[Code]);

CREATE TABLE [InvStock](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[DomainId] bigint NOT NULL,[ItemId] bigint NOT NULL,[WarehouseId] bigint NOT NULL,[LocationId] bigint NULL,[Quantity] decimal(18,4) NOT NULL,[LockedQuantity] decimal(18,4) NOT NULL,[AvailableQuantity] decimal(18,4) NOT NULL,[MinQuantity] decimal(18,4) NOT NULL,[MaxQuantity] decimal(18,4) NOT NULL,[RowVersion] rowversion NOT NULL,[Name] nvarchar(128) NULL,[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvStock] ON [InvStock]([TenantId],[DomainId],[ItemId],[WarehouseId],[LocationId]);

CREATE TABLE [InvStockTransaction](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[DomainId] bigint NOT NULL,[ItemId] bigint NOT NULL,[WarehouseId] bigint NOT NULL,[LocationId] bigint NULL,[DocumentId] bigint NULL,[DocumentNo] nvarchar(64) NULL,[TransactionType] int NOT NULL,[Quantity] decimal(18,4) NOT NULL,[BeforeQuantity] decimal(18,4) NOT NULL,[AfterQuantity] decimal(18,4) NOT NULL,[BusinessKey] nvarchar(200) NOT NULL,[Remark] nvarchar(max) NULL,[Name] nvarchar(128) NULL,[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvStockTransaction] ON [InvStockTransaction]([TenantId],[BusinessKey]);
CREATE INDEX [IX_InvStockTransaction_Query] ON [InvStockTransaction]([TenantId],[ItemId],[WarehouseId],[CreatedTime]);

CREATE TABLE [InvDocument](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[DomainId] bigint NOT NULL,[DocumentNo] nvarchar(64) NOT NULL,[DocumentType] int NOT NULL,[Status] int NOT NULL,[FromWarehouseId] bigint NULL,[ToWarehouseId] bigint NULL,[Remark] nvarchar(max) NULL,[Name] nvarchar(128) NULL,[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE UNIQUE INDEX [UX_InvDocument] ON [InvDocument]([TenantId],[DocumentNo]);

CREATE TABLE [InvDocumentItem](
 [Id] bigint NOT NULL PRIMARY KEY,[TenantId] bigint NOT NULL,[DocumentId] bigint NOT NULL,[ItemId] bigint NOT NULL,[Quantity] decimal(18,4) NOT NULL,[FromLocationId] bigint NULL,[ToLocationId] bigint NULL,[Remark] nvarchar(max) NULL,[Name] nvarchar(128) NULL,[IsDeleted] bit NOT NULL DEFAULT(0),
 [CreatedTime] datetime NOT NULL DEFAULT(getdate()),[CreatedBy] bigint NOT NULL,[CreatedByName] nvarchar(64) NULL,[UpdatedTime] datetime NULL,[UpdatedBy] bigint NULL,[UpdatedByName] nvarchar(64) NULL
);
CREATE INDEX [IX_InvDocumentItem] ON [InvDocumentItem]([DocumentId]);
