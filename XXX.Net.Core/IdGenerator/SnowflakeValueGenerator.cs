using IdGen;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Text;
namespace XXX.Net.Core.IdGenerator
{
    public class SnowflakeValueGenerator : ValueGenerator<long>
    {
       
        public SnowflakeValueGenerator() 
        {
        }

        public override bool GeneratesTemporaryValues => false;

        public override long Next(EntityEntry entry)
        {
            return SnowflakeIdProvider.NewId();
        }
    }
}

