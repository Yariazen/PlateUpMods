using BepInEx;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Reference;
using PastaPalace.Framework.Customs;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace PastaPalace
{
    [BepInProcess("PlateUp.exe")]
    [BepInPlugin(MOD_ID, MOD_NAME, MOD_VERSION)]
    public class Mod : BaseMod
    {
        public const string MOD_ID = "yariazen.pastapalace";
        public const string MOD_NAME = "Pasta Palace";
        public const string MOD_VERSION = "0.0.0";

        internal const int FlourID = ItemReference.Flour;
        internal const int EggCrackedID = ItemReference.EggCracked;

        internal static CustomItemGroup RawNoodles;

        internal static AssetBundle bundle;

        public Mod() : base($">={MOD_VERSION}", Assembly.GetExecutingAssembly())
        {
            string assets = Path.Combine(new string[] { Directory.GetParent(Application.dataPath).FullName, "BepInEx", "plugins", "PastaPalace", "assets", "pastapalacetextures" });
            bundle = AssetBundle.LoadFromFile(assets);
            Debug.Log($"Loaded Textures: {bundle != null}");
        }

        void Awake()
        {
            //Pastas
            RawNoodles = AddGameDataObject<RawNoodles>();
        }
    }
}