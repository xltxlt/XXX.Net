using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.EventBus
{
    public class MqOptions
    {
        public string Host { get; set; } = string.Empty;
        public Int32 Port { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string VirtualHost { get; set; } = string.Empty;
    }
}
