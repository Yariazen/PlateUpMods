using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YariazenCore.Framework.Model;

namespace YariazenCore.Framework
{
    internal class PackManager
    {
        Dictionary<Manifest, List<Pack>> ContentPacks = new Dictionary<Manifest, List<Pack>>();

        internal PackManager()
        {
            foreach (string fullFileName in Directory.GetDirectories(Util.ModsPath))
            {
                if (Directory.Exists(fullFileName))
                {
                    SearchDirectory(fullFileName);
                }
            }
        }

        private void SearchDirectory(string path, Manifest manifest = null)
        {
            Dictionary<string, string> files = Directory.GetFiles(path).ToDictionary(f => Path.GetFileName(f).ToLower(), f => f);
            if (files.ContainsKey("manifest.json"))
            {
                manifest = JsonConvert.DeserializeObject<Manifest>(files["manifest.json"]);
                foreach (KeyValuePair<string, string> kvp in files) 
                { 
                    if(kvp.Key != "manifest.json" && Path.GetExtension(kvp.Value) == ".json")
                    {
                        ContentPacks[manifest].Add(JsonConvert.DeserializeObject<Pack>(kvp.Value));
                    }
                }
            }
            foreach (string fullFileName in Directory.GetDirectories(path))
            {
                if (Directory.Exists(fullFileName))
                {
                    SearchDirectory(fullFileName, manifest);
                }
            }
        }
    }
}
