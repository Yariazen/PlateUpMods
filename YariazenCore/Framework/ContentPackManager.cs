using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace YariazenCore.Framework
{
    internal class ContentPackManager
    {
        List<JObject> packs = new List<JObject>();

        internal ContentPackManager()
        {
            foreach (string fileName in Directory.GetDirectories(Paths.ModsPath))
            {
                packs.Add(JObject.Parse(File.ReadAllText(Directory.GetFiles(fileName, "*.json", SearchOption.AllDirectories).FirstOrDefault())));
            }
        }
    }
}
