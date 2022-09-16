using KitchenLib;
using System;
using System.IO;

namespace YariazenCore.Framework
{
    public class YariazenMod : BaseMod
    {
        public string ModAuthor { get { return Info.Author; } }
        public string UniqueID { get { return $"{ModAuthor}.{ModName}"; } }
        public string BasePath { get { return Environment.CurrentDirectory; } }
        public string ModPath { get { return Path.Combine(BasePath, "Mods", ModName); } }
        public string ConfigPath { get { return Path.Combine(ModPath, "Config.json"); } }

        public YariazenMod(string modID, string compatibleVersions, string[] modDependencies = null) : base(modID, compatibleVersions, modDependencies) { }
    }
}
