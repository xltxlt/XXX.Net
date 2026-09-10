using XXX.Net.Core.BaseEntitys.Enums;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Generate.Attr;
using XXX.Net.Core.Services.Menu.Dto;
using XXX.Net.Core.Services.Menu.Enums;
using XXX.Net.Core.Services.Option;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualStudio.TextTemplating;
using Mono.TextTemplating;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Xml.Linq;
using static XXX.Net.Core.Services.Generate.GenerateService;

namespace XXX.Net.Core.Services.Generate
{
    public class GenerateService : IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        private readonly IHostEnvironment _hostEnvironment;
        public GenerateService(IHostEnvironment hostEnvironment,IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
            _hostEnvironment = hostEnvironment;
        }
        /// <summary>
        /// 
        /// </summary>
        public class GenerateDto
        {
            public SysMenuDto SysMenuDto { get; set; } = null;
            /// <summary>
            /// 关联Dto
            /// </summary>
            [Required]
            public string DtoName { get; set; }
            /// <summary>
            /// 命名空间
            /// </summary>
            [Required]
            public string NamespaceName { get; set; }
            /// <summary>
            /// 关联实体
            /// </summary>
            [Required]
            public string EntityName { get; set; }
            /// <summary>
            /// 关联服务
            /// </summary>
            [Required]
            public string ServiceName { get; set; }
            /// <summary>
            /// 文件名称
            /// </summary>

            public string MenuName { get; set; }
            /// <summary>
            /// 新增功能
            /// </summary>
            public bool AddBtn { get; set; }
            /// <summary>
            /// 修改功能
            /// </summary>
            public bool EditBtn { get; set; }
            /// <summary>
            /// 查看功能
            /// </summary>
            public bool LockBtn { get; set; }
            /// <summary>
            /// 删除功能
            /// </summary>
            public bool DelBtn { get; set; }
            /// <summary>
            /// 导入功能
            /// </summary>
            public bool ImportBtn { get; set; }
            /// <summary>
            /// 导出功能
            /// </summary>
            public bool ExportBtn { get; set; }
            /// <summary>
            /// 菜单生成
            /// </summary>
            public bool MenuGenerate { get; set; }
        }
        public class GenerateField
        {
            public string FieldName { get; set; }
            public string FieldLabel { get; set; }
            public bool Generate { get; set; }
            public PageTableFieldTypeEnum? FieldType { get; set; }
        }

        /// <summary>
        /// 生成页面 
        /// </summary>
        /// <param name="generateDto"></param>
        /// <returns></returns>
        [DisplayName("生成页面")]
        [ApiDescriptionSettings(Name = "Detail", Order = 100), HttpPost]
        [UnitOfWork]
        public virtual async Task GeneratePage(GenerateDto generateDto)
        {
            //查找实体类名
            string namespaceName = generateDto.NamespaceName;
            string className = generateDto.DtoName;

            Type entityType = FindType(namespaceName, className);
            if (entityType == null)
            {
                Console.WriteLine("");
                throw Oops.Oh("未找到对应的实体类");
            }
            var list = new List<GenerateField>();
            var fields = GetFieldLabels(entityType).ToList();
            foreach (var (fieldName, fieldLabel, generate,  fieldType) in fields)
            {
                var generateField = new GenerateField()
                {
                    FieldName = fieldName,
                    FieldLabel = fieldLabel,
                    FieldType = PageTableFieldTypeEnum.Default
                };
                var actualType = Nullable.GetUnderlyingType(fieldType) ?? fieldType;
                if (actualType == typeof(bool))
                {
                    generateField.FieldType = PageTableFieldTypeEnum.StatusColor;
                }
                list.Add(generateField);
            }

            //添加menu 、menuButton 、menuField
            if (generateDto.MenuGenerate)
            {
                var menuEntity = generateDto.SysMenuDto.Adapt<SysMenu>();
                var now = DateTime.Now;
                menuEntity.CreatedByName = _currentUser.UserName;
                menuEntity.CreatedTime = now;
                menuEntity.CreatedBy = _currentUser.UserId;
                menuEntity.UpdatedBy = _currentUser.UserId;
                menuEntity.UpdatedTime = now;
                menuEntity.UpdatedByName = _currentUser.UserName;
                menuEntity.MenuType = (int)MenuTypeEnum.Menu; ;

                var addMlmenuButton = new List<SysMenuButton>();
                var baseMenuButtons = new SysMenuButton();
                baseMenuButtons.CreatedByName = _currentUser.UserName;
                baseMenuButtons.CreatedTime = now;
                baseMenuButtons.CreatedBy = _currentUser.UserId;
                baseMenuButtons.UpdatedBy = _currentUser.UserId;
                baseMenuButtons.UpdatedTime = now;
                baseMenuButtons.UpdatedByName = _currentUser.UserName;

                baseMenuButtons.Deleted = false;
                baseMenuButtons.General = true;
                baseMenuButtons.Enabled = true;
                baseMenuButtons.Target = (int)TargetAppEnum.All;
                baseMenuButtons.TenantId = menuEntity.TenantId;
                #region 生成按钮
                if (generateDto.AddBtn)
                {
                    var addMenuButton = baseMenuButtons.ShallowCopy();
                    addMenuButton.Name = "新增";
                    addMenuButton.Label = "新增";
                    addMenuButton.EventName = "add";
                    addMenuButton.BgColor = "#28a745";
                    addMenuButton.Sort = 10;
                    addMenuButton.ButtonType = (int)MenuButtonTypeEnum.Button;
                    addMlmenuButton.Add(addMenuButton);
                }
                if (generateDto.EditBtn)
                {
                    var addMenuButton = baseMenuButtons.ShallowCopy();
                    addMenuButton.Name = "修改";
                    addMenuButton.Label = "修改";
                    addMenuButton.EventName = "edit";
                    addMenuButton.BgColor = "#28a745";
                    addMenuButton.Sort = 10;
                    addMenuButton.ButtonType = (int)MenuButtonTypeEnum.TableButton;
                    addMlmenuButton.Add(addMenuButton);
                }
                if (generateDto.DelBtn)
                {
                    var addMenuButton = baseMenuButtons.ShallowCopy();
                    addMenuButton.Name = "删除";
                    addMenuButton.Label = "删除";
                    addMenuButton.EventName = "del";
                    addMenuButton.BgColor = "#FA5151";
                    addMenuButton.Sort = 990;
                    addMenuButton.ButtonType = (int)MenuButtonTypeEnum.TableButton;
                    addMlmenuButton.Add(addMenuButton);

                    var batchDelMenuButton = baseMenuButtons.ShallowCopy();
                    addMenuButton.Name = "批量删除";
                    addMenuButton.Label = "批量删除";
                    addMenuButton.EventName = "batchDel";
                    addMenuButton.BgColor = "#FA5151";
                    addMenuButton.Sort = 990;
                    addMenuButton.ButtonType = (int)MenuButtonTypeEnum.Button;
                    addMlmenuButton.Add(addMenuButton);
                }
                if (generateDto.LockBtn)
                {
                    var addMenuButton = baseMenuButtons.ShallowCopy();
                    addMenuButton.Name = "查看";
                    addMenuButton.Label = "查看";
                    addMenuButton.EventName = "lock";
                    addMenuButton.BgColor = "rgba(87, 107, 149, 1)";
                    addMenuButton.Sort = 20;
                    addMenuButton.ButtonType = (int)MenuButtonTypeEnum.TableButton;
                    addMlmenuButton.Add(addMenuButton);
                }
                #endregion
                #region 生成字段
                var addMlMenuField = new List<SysMenuField>();
                var baseMenuField = new SysMenuField();
                baseMenuField.CreatedByName = _currentUser.UserName;
                baseMenuField.CreatedTime = now;
                baseMenuField.CreatedBy = _currentUser.UserId;
                baseMenuField.UpdatedBy = _currentUser.UserId;
                baseMenuField.UpdatedTime = now;
                baseMenuField.UpdatedByName = _currentUser.UserName;
                baseMenuField.SearchField = true;
                baseMenuField.Deleted = false;
                baseMenuField.General = true;
                baseMenuField.Enabled = true;
                baseMenuField.InitHide = false;
                baseMenuField.Target = (int)TargetAppEnum.All;
                var index = 1;
                foreach (var item in fields)
                {
                    
                    var menuField = baseMenuField.ShallowCopy();
                    menuField.FieldName = item.FieldName;
                    menuField.Name = item.FieldLabel;
                    menuField.Label = item.FieldLabel;
                    menuField.FieldType =(int)PageTableFieldTypeEnum.Default;
                    menuField.SearchType = (int)PageSearchTypeEnum.Default;
                    menuField.Width = (item.FieldLabel.Length * 20 + 60).ToString();
                    menuField.Sort = index++ * 10;
                    if (item.FieldName == "tenantId") {
                        menuField.General =(int)GeneralEnum.Tenant==1;
                    }
                    if (item.FieldName == "description") {
                        menuField.SearchField = false;
                    }
                    addMlMenuField.Add(menuField);
                }
                if (addMlmenuButton.Count() > 0) {
                    var menuField = baseMenuField.ShallowCopy();
                    menuField.FieldName = "rightTools";
                    menuField.Name = "功能操作";
                    menuField.Label = "功能操作";
                    menuField.FieldType = (int)PageTableFieldTypeEnum.RightTools;
                    menuField.Width = "160";
                    menuField.Sort = 9990;
                    addMlMenuField.Add(menuField);
                }
                #endregion
                menuEntity.MenuButtons = addMlmenuButton;
                menuEntity.MenuFields = addMlMenuField;
                if (generateDto.SysMenuDto.Path == null || generateDto.SysMenuDto.Path.Count() == 0)
                {
                    menuEntity.ClassLevel = 1;
                    menuEntity.Path = "";

                }
                else
                {
                    menuEntity.Path = string.Join("/", generateDto.SysMenuDto.Path);
                    if (!string.IsNullOrEmpty(menuEntity.Path))
                    {
                        menuEntity.Path = "/" + menuEntity.Path + "/";
                    }
                    menuEntity.ClassLevel = generateDto.SysMenuDto.Path.Count() + 1;
                    menuEntity.ParentId = generateDto.SysMenuDto.Path.LastOrDefault();
                }
                menuEntity = (await _msRepository.Master<SysMenu>().InsertAsync(menuEntity)).Entity;
            }

            var solutionRoot = _hostEnvironment.ContentRootPath;
            var componentName = generateDto.ServiceName.Replace("Service", "").ToFirstUpperInvariant();
            var apiServiceName = generateDto.ServiceName.Replace("Sys", "").ToFirstLowerInvariant();
            var pageName= apiServiceName.Replace("Service", "").ToFirstLowerInvariant();
            #region 生成 List.vue
            var templatePath = Path.Combine(solutionRoot,  "Template", "Vue", "ListVue.tt");
            var outPath = Path.Combine(solutionRoot,  "Template", "Vue", "Generate");
            if (!System.IO.File.Exists(templatePath)) throw new FileNotFoundException(templatePath);
            var cmd = $"t4 \"{templatePath}\" -p:ComponentName=\"{componentName}\" -p:ServiceName=\"{generateDto.ServiceName}\" -p:ApiServiceName=\"{apiServiceName}\" -p:PageName=\"{pageName}\" -p:addBtn={generateDto.AddBtn} -p:editBtn={generateDto.EditBtn} -p:delBtn={generateDto.DelBtn} -p:lockBtn={generateDto.LockBtn} -o:\"{outPath}/{pageName.ToFirstUpperInvariant()}.vue\"";
            ExecuteCommandAsync(cmd);

            #endregion
            #region 生成Edit.vue
            var formFields = fields.Select(item =>
            {
                var actualType = Nullable.GetUnderlyingType(item.FieldType) ?? item.FieldType;

                var formType =nameof(PageFormTypeEnum.Input) ;
                if (item.FieldName == "path")
                {
                    formType = nameof(PageFormTypeEnum.TreeSelect);
                }
                else if (item.FieldName == "description")
                {
                    formType = nameof(PageFormTypeEnum.TextAreaInput);
                }
                else if (actualType == typeof(bool))
                {
                    formType = nameof(PageFormTypeEnum.Radio);
                }
                else if (actualType == typeof(int) || actualType == typeof(long) || item.FieldName == "tenantId")
                {
                    formType = nameof(PageFormTypeEnum.OneSelectSearch);
                }
                else if (actualType == typeof(decimal))
                {
                    formType = nameof(PageFormTypeEnum.DecimalInput);
                }
                return new
                {
                    formType = formType,
                    label = item.FieldLabel,
                    fieldName = item.FieldName
                };
            });
            var editTemplatePath = Path.Combine(solutionRoot,  "Template", "Vue", "EditVue.tt");
            var editOutPath = Path.Combine(solutionRoot, "Template", "Vue","Generate");
            if (!System.IO.File.Exists(editTemplatePath)) throw new FileNotFoundException(editTemplatePath);
            
            var editVuecmd = $"t4 \"{editTemplatePath}\" -p:ComponentName=\"{componentName}\" -p:ServiceName=\"{generateDto.ServiceName}\" -p:ApiServiceName=\"{apiServiceName}\" -p:pageName=\"{pageName}\"  -p:FieldsJson=\"{Furion.JsonSerialization.JSON.Serialize(formFields).Replace("\"","\"\"")}\"  -o:\"{editOutPath}/{pageName.ToFirstUpperInvariant()}Edit.vue\"";
           ExecuteCommandAsync(editVuecmd);
            #endregion
            return;
        }
        public static void ExecuteCommandAsync(string command)
        {
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c {command}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            // 使用 StringBuilder 收集输出
            var output = new System.Text.StringBuilder();
            var error = new System.Text.StringBuilder();

            process.OutputDataReceived += (sender, e) => output.AppendLine(e.Data);
            process.ErrorDataReceived += (sender, e) => error.AppendLine(e.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            var err = error.ToString().Replace("\r","").Replace("\n","");
            if (err != "") {
                throw Oops.Oh($"错误: {error}\n输出: {output}");
            }
        }

        /// <summary>
        /// 获取新增修改页面选项 
        /// </summary>
        /// <param name="optionService"></param>
        /// <returns></returns>
        [DisplayName("获取新增修改页面选项")]
        [ApiDescriptionSettings(Name = "PageOption", Order = 110), HttpGet]
        public virtual async Task<object> PageOption([FromServices] OptionService optionService)
        {
            var options = await optionService.GetOptions<SysMenuDto>();
            //获取所有服务 继承了BaseService
            //获取所有Dto 继承BaseUpdate的
            return new
            {
                options = options
            };
        }
        #region 帮助类
        public static string GetDescription(MemberInfo member)
        {
            var descAttr = member.GetCustomAttribute<DescriptionAttribute>();
            return descAttr?.Description;
        }
        public static bool GetNonGenerate(MemberInfo member)
        {
            var descAttr = member.GetCustomAttribute<NonGenerateAttribute>();
            return descAttr != null;
        }
        public static Type FindType(string namespaceName, string className)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a =>
                {
                    try { return a.GetTypes(); }
                    catch (ReflectionTypeLoadException) { return Type.EmptyTypes; }
                })
                .FirstOrDefault(t => t.IsClass &&
                                     t.Namespace == namespaceName &&
                                     t.Name == className);
        }
        public static string GetXmlSummary(MemberInfo member)
        {
            // 获取成员所属程序集的 XML 文档路径
            var assembly = member.DeclaringType.Assembly;
            string xmlPath = Path.ChangeExtension(assembly.Location, ".xml");
            if (!System.IO.File.Exists(xmlPath))
                return null;

            // 构造 XML 成员名称（例如：P:Namespace.Class.Property 或 F:Namespace.Class.field）
            string memberName = member.MemberType switch
            {
                MemberTypes.Property => $"P:{member.DeclaringType.FullName}.{member.Name}",
                MemberTypes.Field => $"F:{member.DeclaringType.FullName}.{member.Name}",
                _ => null
            };
            if (memberName == null) return null;

            var doc = XDocument.Load(xmlPath);
            var summary = doc.Descendants("member")
                .FirstOrDefault(m => m.Attribute("name")?.Value == memberName)?
                .Element("summary")?.Value;

            return summary?.Trim();
        }
        public static string GetFieldLabel(MemberInfo member)
        {
            return GetDescription(member) ?? GetXmlSummary(member) ?? member.Name;
        }
        public static List<(string FieldName, string FieldLabel, bool generate, Type FieldType)> GetFieldLabels(Type entityType)
        {
            var result = new List<(string FieldName, string FieldLabel, bool generate, Type FieldType)>();

            // 获取公共实例字段
            foreach (var field in entityType.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(w=>w.DeclaringType!= entityType))
            {
                result.Add((field.Name.ToFirstLowerInvariant(), GetFieldLabel(field), GetNonGenerate(field), field.FieldType));
            }
            // 获取公共实例属性
            foreach (var prop in entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(w => w.DeclaringType != entityType))
            {
                result.Add((prop.Name.ToFirstLowerInvariant(), GetFieldLabel(prop), GetNonGenerate(prop), prop.PropertyType));
            }
            foreach (var field in entityType.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(w => w.DeclaringType == entityType))
            {
                result.Add((field.Name.ToFirstLowerInvariant(), GetFieldLabel(field), GetNonGenerate(field), field.FieldType));
            }
            // 获取公共实例属性
            foreach (var prop in entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(w => w.DeclaringType == entityType))
            {
                result.Add((prop.Name.ToFirstLowerInvariant(), GetFieldLabel(prop), GetNonGenerate(prop), prop.PropertyType));
            }
            return result.Where(w=>w.FieldName!="id").ToList();
        }
        #endregion
    }
}
