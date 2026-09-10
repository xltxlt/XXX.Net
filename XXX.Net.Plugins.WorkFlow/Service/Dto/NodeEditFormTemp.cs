using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.Service.Dto
{
        public class NodeEditFormTemp
        {
            public int FormType { get; set; }
            public object? Rules { get; set; }
            public string? Placeholder { get; set; }
            public bool? Custom { get; set; }
            public string? Code { get; set; }
            public string? PIdent { get; set; }
            public string? Ident { get; set; }
            public string FieldName { get; set; }
            public string? Title { get; set; }
            public string? Label { get; set; }
            public string? UploadPath { get; set; }
            public List<ComponentAttr>? ComponentAttr { get; set; } // componentAttr[]
            public bool? Must { get; set; }
            public object? Props { get; set; } // string | [] | {}
            public object? Option { get; set; }
            public List<NodeEditFormTemp>? Child { get; set; }
            public bool? Hide { get; set; } // boolean | Ref<boolean> -> bool
            public bool? ShowPicker { get; set; }
        }
}
