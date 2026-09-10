
# 创建主数据库表 默认项目选XXX.Net.DataBase.Mlgrations 
Add-Migration v0.0.1 -Context MasterDbContext
Update-Database -Context MasterDbContext
 
# 创建主数据库表 默认项目选XXX.Net.DataBase.Mlgrations 
Add-Migration v0.0.1 -Context SlaveDbContext
Update-Database -Context SlaveDbContext



## 调试错误 power shell 命令
dotnet ef migrations add v0.0.1 `
    --context MasterDbContext `
    --project .\XXX.Net.Database.Migrations\XXX.Net.Database.Migrations.csproj `
    --startup-project .\XXX.Net.Web.Entry\XXX.Net.Web.Entry.csproj `
    --verbose