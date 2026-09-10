using XXX.Net.Core.Services.File.Dto;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;


namespace XXX.Net.Core.Services.File
{
    public class SysFileService : IDynamicApiController
    {
        private readonly IHttpContextAccessor _acc;
        private readonly IWebHostEnvironment _env;
        public SysFileService(IHttpContextAccessor acc, IWebHostEnvironment env)
        {
            _acc = acc;
            _env = env;
        }



        [HttpPost, NonUnify]
        public async Task<object> Upload(List<IFormFile> files)
        {
            // 按天生成目录：uploads/2026/08/14
            var dateDir = DateTime.Now.ToString("yyyy/MM/dd");
            var saveDir = Path.Combine(_env.WebRootPath ?? _env.ContentRootPath, "uploads", dateDir);

            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);

            var result = new List<string>();

            foreach (var file in files)
            {
                if (file.Length <= 0) continue;

                var ext = Path.GetExtension(file.FileName);
                var fileName = $"{Guid.NewGuid():N}{ext}";
                var fullPath = Path.Combine(saveDir, fileName);

                await using var stream = System.IO.File.Create(fullPath);
                await file.CopyToAsync(stream);

                // 返回相对路径（前端可直接访问）
                result.Add(Path.Combine("uploads", dateDir, fileName).Replace("\\", "/"));
            }

            return new
            {
                count = result.Count,
                files = result
            };
        }
        [HttpPost, NonUnify]
        public async Task<SysFileOutput> UploadSingle(IFormFile file)
        {
            if (file == null) {
                throw Oops.Oh("请上传文件");
            }
            // ========== 2. 文件类型校验（按需调整白名单）==========
            var allowedExts = new[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".webp", ".pdf", ".doc", ".docx", ".xls", ".xlsx" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExts.Contains(ext))
                throw Oops.Oh($"不支持的文件格式：{ext}");
            // ========== 3. 文件大小校验（限制 50MB）==========
            const long maxFileSize = 50 * 1024 * 1024;
            if (file.Length > maxFileSize)
                throw Oops.Oh("文件大小不能超过 50MB");


            // 按天生成目录：uploads/2026/08/14
            var dateDir = DateTime.Now.ToString("yyyy/MM/dd");
            var saveDir = Path.Combine(_env.WebRootPath ?? _env.ContentRootPath, "uploads", dateDir);

            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);

            var result = new List<string>();


            var fileName = $"{Guid.NewGuid():N}{ext}";
            var fullPath = Path.Combine(saveDir, fileName);

            await using var stream = System.IO.File.Create(fullPath);
            await file.CopyToAsync(stream);
            var relativePath = Path.Combine("uploads", dateDir, fileName).Replace("\\", "/");
            // 如果前端需要完整 URL（带域名），用这个：
            var fullUrl = $"{_acc.HttpContext.Request.Scheme}://{_acc.HttpContext.Request.Host}/{relativePath}";

            // ========== 8. 返回结果 ==========
            return new SysFileOutput
            {
                FileName = fileName,                      
                OriginalName = file.FileName,             
                Url = fullUrl,                            
                FileSize = file.Length,
                ContentType = file.ContentType,
                Extension = ext.TrimStart('.'),
                UploadTime = DateTime.Now
            };
        }


        [HttpGet, NonUnify, AllowAnonymous]
        public IActionResult Download(string fileId, string fileName)
        {
            var path = Path.Combine(App.HostEnvironment.ContentRootPath, "uploads", fileId);
            if (!System.IO.File.Exists(path)) return new NotFoundResult();

            _acc.HttpContext.Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");
            _acc.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            return new FileStreamResult(System.IO.File.OpenRead(path), "application/octet-stream")
            {
                FileDownloadName = fileName
            };
        }

    }
}
