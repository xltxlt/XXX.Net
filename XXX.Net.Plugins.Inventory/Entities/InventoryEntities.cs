using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.BaseEntitys.Enums;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Enums;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Plugins.Inventory.Enums;

namespace XXX.Net.Plugins.Inventory.Entities;

public abstract class InventoryEntityBase : BaseTenantEntity, IPrivateEntity
{
    protected static void ConfigureCommon<TEntity>(EntityTypeBuilder<TEntity> b) where TEntity : InventoryEntityBase
    {
        b.Property(x => x.Id).HasValueGenerator<SnowflakeValueGenerator>();
        b.Property(x => x.Name).HasMaxLength(128);
        b.Property(x => x.CreatedByName).HasMaxLength(64);
        b.Property(x => x.UpdatedByName).HasMaxLength(64);
        b.Property(x => x.CreatedTime).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
        b.Property(x => x.UpdatedTime).HasColumnType("datetime");
        b.HasQueryFilter(x => !x.Deleted);
    }
}

public class InventoryDomain : InventoryEntityBase, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryDomain, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long DepartmentId { get; set; }
    public string Code { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public void Configure(EntityTypeBuilder<InventoryDomain> b, DbContext db, Type locator)
    {
        ConfigureCommon(b); b.ToTable("InvDomain");
        b.Property(x => x.Code).HasMaxLength(64).IsRequired();
        b.HasIndex(x => new { x.TenantId, x.DepartmentId, x.Code }).IsUnique();
    }
}

public class InventoryType : InventoryEntityBase, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryType, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long DomainId { get; set; }
    public string Code { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public void Configure(EntityTypeBuilder<InventoryType> b, DbContext db, Type locator)
    {
        ConfigureCommon(b);
        b.ToTable("InvType");
        b.Property(x => x.Code).HasMaxLength(64).IsRequired();
        b.HasIndex(x => new { x.TenantId, x.DomainId, x.Code }).IsUnique();
    }
}

public class InventoryAttributeDefinition : InventoryEntityBase, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryAttributeDefinition, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long InventoryTypeId { get; set; }
    public long DomainId { get; set; }
    public string Code { get; set; } = string.Empty;
    public PageFormTypeEnum DataType { get; set; }
    public bool Required { get; set; }
    public bool Unique { get; set; }
    public bool IsKey { get; set; }
    public int Sort { get; set; }
    public string? OptionsJson { get; set; }
    public void Configure(EntityTypeBuilder<InventoryAttributeDefinition> b, DbContext db, Type locator)
    {
        ConfigureCommon(b); b.ToTable("InvAttributeDefinition");
        b.Property(x => x.Code).HasMaxLength(64).IsRequired();
        b.Property(x => x.OptionsJson).HasColumnType("nvarchar(max)");
        b.HasIndex(x => new { x.TenantId, x.InventoryTypeId, x.Code }).IsUnique();
    }
}

public class InventoryItem : InventoryEntityBase, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryItem, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long DomainId { get; set; }
    public long InventoryTypeId { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public EnabledEnum Enabled { get; set; } = EnabledEnum.Enabled;
    public string? AttributesJson { get; set; }
    public void Configure(EntityTypeBuilder<InventoryItem> b, DbContext db, Type locator)
    {
        ConfigureCommon(b); b.ToTable("InvItem");
        b.Property(x => x.Code).HasMaxLength(128).IsRequired();
        b.Property(x => x.Unit).HasMaxLength(32);
        b.Property(x => x.AttributesJson).HasColumnType("nvarchar(max)");
        b.HasIndex(x => new { x.TenantId, x.DomainId, x.Code }).IsUnique();
    }
}

public class InventoryItemAttributeIndex : InventoryEntityBase, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryItemAttributeIndex, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long ItemId { get; set; }
    public long AttributeDefinitionId { get; set; }
    public string AttributeValue { get; set; } = string.Empty;
    public void Configure(EntityTypeBuilder<InventoryItemAttributeIndex> b, DbContext db, Type locator)
    {
        ConfigureCommon(b); b.ToTable("InvItemAttributeIndex");
        b.Property(x => x.AttributeValue).HasMaxLength(512).IsRequired();
        b.HasIndex(x => new { x.TenantId, x.ItemId, x.AttributeDefinitionId }).IsUnique();
        b.HasIndex(x => new { x.TenantId, x.AttributeDefinitionId, x.AttributeValue });
    }
}

public class InventoryWarehouse : InventoryEntityBase, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryWarehouse, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long DomainId { get; set; }
    public long? DepartmentId { get; set; }
    public string Code { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public void Configure(EntityTypeBuilder<InventoryWarehouse> b, DbContext db, Type locator)
    {
        ConfigureCommon(b); b.ToTable("InvWarehouse");
        b.Property(x => x.Code).HasMaxLength(64).IsRequired();
        b.HasIndex(x => new { x.TenantId, x.DomainId, x.Code }).IsUnique();
    }
}

public class InventoryLocation : BaseTenantTreeEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryLocation, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long WarehouseId { get; set; }
    public string Code { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public void Configure(EntityTypeBuilder<InventoryLocation> b, DbContext db, Type locator)
    {
        BaseTenantTreeEntity.BaseConfigure(b); b.ToTable("InvLocation");

        b.Property(x => x.Code).HasMaxLength(64).IsRequired();
        b.HasIndex(x => new { x.TenantId, x.WarehouseId, x.Code }).IsUnique();
    }
}

public class InventoryStock : InventoryEntityBase, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryStock, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long DomainId { get; set; }
    public long ItemId { get; set; }
    public long WarehouseId { get; set; }
    public long? LocationId { get; set; }
    public decimal Quantity { get; set; }
    public decimal LockedQuantity { get; set; }
    public decimal AvailableQuantity { get; set; }
    public decimal MinQuantity { get; set; }
    public decimal MaxQuantity { get; set; }
    public byte[] RowVersion { get; set; } = [];
    public void Configure(EntityTypeBuilder<InventoryStock> b, DbContext db, Type locator)
    {
        ConfigureCommon(b); b.ToTable("InvStock");
        b.Property(x => x.Quantity).HasPrecision(18, 4);
        b.Property(x => x.LockedQuantity).HasPrecision(18, 4);
        b.Property(x => x.AvailableQuantity).HasPrecision(18, 4);
        b.Property(x => x.MinQuantity).HasPrecision(18, 4);
        b.Property(x => x.MaxQuantity).HasPrecision(18, 4);
        b.Property(x => x.RowVersion).IsRowVersion();
        b.HasIndex(x => new { x.TenantId, x.DomainId, x.ItemId, x.WarehouseId, x.LocationId }).IsUnique();
    }
}

public class InventoryStockTransaction : InventoryEntityBase, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryStockTransaction, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long DomainId { get; set; }
    public long ItemId { get; set; }
    public long WarehouseId { get; set; }
    public long? LocationId { get; set; }
    public long? DocumentId { get; set; }
    public string? DocumentNo { get; set; }
    public InventoryTransactionType TransactionType { get; set; }
    public decimal Quantity { get; set; }
    public decimal BeforeQuantity { get; set; }
    public decimal AfterQuantity { get; set; }
    public string BusinessKey { get; set; } = string.Empty;
    public string? Remark { get; set; }
    public void Configure(EntityTypeBuilder<InventoryStockTransaction> b, DbContext db, Type locator)
    {
        ConfigureCommon(b); b.ToTable("InvStockTransaction");
        b.Property(x => x.DocumentNo).HasMaxLength(64);
        b.Property(x => x.Quantity).HasPrecision(18, 4);
        b.Property(x => x.BeforeQuantity).HasPrecision(18, 4);
        b.Property(x => x.AfterQuantity).HasPrecision(18, 4);
        b.Property(x => x.BusinessKey).HasMaxLength(200).IsRequired();
        b.HasIndex(x => new { x.TenantId, x.BusinessKey }).IsUnique();
        b.HasIndex(x => new { x.TenantId, x.ItemId, x.WarehouseId, x.CreatedTime });
    }
}

public class InventoryDocument : BaseTenantParentSonEntity<InventoryDocumentItem>, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryDocument, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long DomainId { get; set; }
    public string DocumentNo { get; set; } = string.Empty;
    public int DocumentType { get; set; }
    public int Status { get; set; } = (int)InventoryDocumentStatus.Draft;
    public long? FromWarehouseId { get; set; }
    public long? ToWarehouseId { get; set; }
    public string? Remark { get; set; }

    public void Configure(EntityTypeBuilder<InventoryDocument> b, DbContext db, Type locator)
    {
        BaseTenantParentSonEntity<InventoryDocumentItem>.BaseConfigure(b); 
        b.ToTable("InvDocument");
        b.Property(x => x.DocumentNo).HasMaxLength(64).IsRequired();
        b.HasIndex(x => new { x.TenantId, x.DocumentNo }).IsUnique();
    }
}

public class InventoryDocumentItem : BaseSonEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<InventoryDocumentItem, MasterDbContextLocator, SlaveDbContextLocator>
{
    public long ItemId { get; set; }
    public decimal Quantity { get; set; }
    public long? FromLocationId { get; set; }
    public long? ToLocationId { get; set; }
    public string? Remark { get; set; }
    public void Configure(EntityTypeBuilder<InventoryDocumentItem> b, DbContext db, Type locator)
    {
        BaseSonEntity.BaseConfigure(b);
        b.ToTable("InvDocumentItem");
        b.Property(x => x.Quantity).HasPrecision(18, 4);
    }
}
