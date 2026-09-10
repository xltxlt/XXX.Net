using XXX.Net.Core.MongoDb;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace XXX.Net.Core.BaseEntitys.Entity
{
    public class BaseMongoEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// 租户ID
        /// </summary>
        public System.Int64 TenantId { get; set; }

        /// <summary>
        /// 是否删除 0未删除 1已删除
        /// </summary>

        public System.Boolean Deleted { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [MongoJsonDateTime]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public System.Int64 CreatedBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [MongoJsonDateTime]
        public DateTime? UpdatedTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public Int64? UpdatedBy { get; set; }
    }
}
