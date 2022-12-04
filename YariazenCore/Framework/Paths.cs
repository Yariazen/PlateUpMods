using System.IO;
using UnityEngine;

namespace YariazenCore.Framework
{
    internal class Paths
    {
        public static string ModsPath;

        internal static void Initialize()
        {
            ModsPath = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Mods");
        }
    }
}
