using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.File.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class SysFileOutput
    {
        /// <summary>文件ID（数据库主键）</summary>
        public long? FileId { get; set; } = null;

        /// <summary>原始文件名</summary>
        public string OriginalName { get; set; } = string.Empty;

        /// <summary>服务端存储文件名</summary>
        public string FileName { get; set; } = null;

        /// <summary>文件访问URL</summary>
        public string Url { get; set; } = string.Empty;

        /// <summary>文件大小（bytes）</summary>
        public long FileSize { get; set; }

        /// <summary>MIME类型</summary>
        public string ContentType { get; set; } = null;

        /// <summary>文件扩展名</summary>
        public string Extension { get; set; } = null;

        /// <summary>上传时间</summary>
        public DateTime UploadTime { get; set; }
    }
}
