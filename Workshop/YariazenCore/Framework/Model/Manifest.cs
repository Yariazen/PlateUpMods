using System.Collections.Generic;

namespace YariazenCore.Framework.Model
{
    public class Manifest
    {
        public string ModName { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> ContentPackFor { get; set; } 
    }
}
