using IdGen;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.IdGenerator
{
    public static  class SnowflakeIdProvider 
    {
        private static  readonly IdGen.IdGenerator _generator;

        static SnowflakeIdProvider()
        {

            var structure = new IdStructure(41, 10, 12);
            var idOptions = new IdGeneratorOptions(
                structure,
                timeSource: new DefaultTimeSource(new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                SequenceOverflowStrategy.SpinWait
            );

            var generatorId = Convert.ToInt32(App.Configuration["IdGen:GeneratorId"] ?? "1");
            _generator = new IdGen.IdGenerator(generatorId, idOptions);
        }
        public static long NewId() => _generator.CreateId();
    }
}
