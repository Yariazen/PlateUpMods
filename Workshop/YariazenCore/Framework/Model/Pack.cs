using System.Collections.Generic;

namespace YariazenCore.Framework.Model
{
    public class Pack
    {
        public class Change
        {
            public string Action { get; set; }
            public string Type { get; set; }
            public List<string> Paths { get; set; }
        }

        public string Format;
        public List<Change> Changes;
    }
}
