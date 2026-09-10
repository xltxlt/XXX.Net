using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace XXX.Net.Plugins.WorkFlow.Entity
{
    /// <summary>
    /// WorkFlow 专用 Mongo 实体基类。
    /// 不继承 Core 的 BaseMongoEntity（其 CreatedTime 上的 JsonConverter 缺少无参构造，会导致 System.Text.Json 序列化异常），
    /// 用 string 类型 Id 便于前端直接使用。
    /// </summary>
    public abstract class WorkFlowMongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
