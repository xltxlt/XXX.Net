# XXX.Net.Plugins.Inventory

通用库存插件，针对当前 `Fyyy.Net` 项目定制：`.NET 10 + Furion 4.9.9.73 + EF Core + SQL Server + CAP 10.0.2 + RabbitMQ + Redis`。

## 与当前项目的集成原则

1. **只引用 `XXX.Net.Core`**，不创建插件自己的 DbContext。
2. 所有实体实现 `IEntity<MasterDbContextLocator, SlaveDbContextLocator>` 和 `IEntityTypeBuilder<...>`，由现有 `MasterDbContext`/`SlaveDbContext` 接管模型。
3. 使用现有 `IMSRepository.Master/Slave`，不另造 Repository。
4. 使用现有 `XXX.Net.Core.IdGenerator.SnowflakeValueGenerator` 生成 bigint 雪花 ID。
5. 使用现有 `ICurrentUser`、`ICacheService`、`IEventBus`、Redis 分布式锁。
6. 使用现有 CAP + RabbitMQ，不在插件重复注册 CAP。
7. 库存数据同时按 `TenantId + InventoryDomain.DepartmentId` 隔离。

## 接入

当前压缩包已经：

- 将项目加入 `XXX.Net.sln`
- `XXX.Net.Web.Core` 引用本插件
- `XXX.Net.Database.Migrations` 引用本插件
- `Startup.ConfigureServices` 调用 `services.AddInventory()`

如果只复制插件到其他项目，需要：

```xml
<ProjectReference Include="..\XXX.Net.Plugins.Inventory\XXX.Net.Plugins.Inventory.csproj" />
```

并：

```csharp
using XXX.Net.Plugins.Inventory.Extensions;
services.AddInventory();
```

## 功能

### 配置

- InventoryDomain：部门库存域
- InventoryType：库存类型
- InventoryAttributeDefinition：动态属性定义
- InventoryItem：库存物品
- InventoryItemAttributeIndex：动态属性索引
- InventoryWarehouse：仓库
- InventoryLocation：库位

### 库存

- 入库
- 出库
- 调拨
- 库存调整/盘点
- 锁定库存
- 解锁库存
- 当前库存查询
- 库存列表
- 库存流水
- BusinessKey 幂等
- Redis 缓存
- Redis 分布式锁
- CAP 库存变化事件
- 库存不足事件缓存

### 单据

- 创建
- 草稿
- 完成
- 取消
- 入库单
- 出库单
- 调拨单
- 退货单

## 核心表

`InvDomain`
`InvType`
`InvAttributeDefinition`
`InvItem`
`InvItemAttributeIndex`
`InvWarehouse`
`InvLocation`
`InvStock`
`InvStockTransaction`
`InvDocument`
`InvDocumentItem`

## Migration

当前项目的 Migration 程序集仍然是 `XXX.Net.Database.Migrations`，上下文是 `MasterDbContext`。

```powershell
dotnet ef migrations add InitInventory --project XXX.Net.Database.Migrations --startup-project XXX.Net.Web.Entry --context MasterDbContext

dotnet ef database update --project XXX.Net.Database.Migrations --startup-project XXX.Net.Web.Entry --context MasterDbContext
```

如果你当前已有 `v0.0.1`，建议创建新 Migration，例如：

```powershell
dotnet ef migrations add AddInventory --project XXX.Net.Database.Migrations --startup-project XXX.Net.Web.Entry --context MasterDbContext
```

`Scripts/Inventory.sql` 是备用 SQL，不建议和 EF Migration 同时执行。
