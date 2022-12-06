using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Reference;
using KitchenLib.Utils;
using PastaPalace.Customs.NoodleChain;
using PastaPalace.Customs.PastaProcess;
using PastaPalace.Customs.RedSauceChain;
using PastaPalace.Customs.WhiteSauceChain;
using System.IO;
using System;
using System.Reflection;
using UnityEngine;
using ItemReference = KitchenLib.Reference.ItemReference;

namespace PastaPalace
{
    public class Mod : BaseMod
    {
        internal const string MOD_NAME = "Pasta Palace";
        internal const string MOD_VERSION = "1.0.0";
        internal const string MOD_AUTHOR = "";
        internal const string PLATEUP_VERSION = "1.1.2";

        internal static Item Flour => GetExistingGDO<Item>(ItemReference.Flour);
        internal static Item EggCracked => GetExistingGDO<Item>(ItemReference.EggCracked);
        internal static Item Water => GetExistingGDO<Item>(ItemReference.Water);
        internal static Item Pot => GetExistingGDO<Item>(ItemReference.Pot);
        internal static Item Onion => GetExistingGDO<Item>(ItemReference.Onion);
        internal static Item TomatoSauce => GetExistingGDO<Item>(ItemReference.TomatoSauce);
        internal static Item Cheese => GetExistingGDO<Item>(ItemReference.Cheese);
        internal static Item BroccoliChoppedContainerCooked => GetExistingGDO<Item>(ItemReference.BroccoliChoppedContainerCooked);
        internal static Item MeatChoppedContainerCooked => GetExistingGDO<Item>(ItemReference.MeatChoppedContainerCooked);
        internal static Item Plate => GetExistingGDO<Item>(ItemReference.Plate);
        internal static Item Egg => GetExistingGDO<Item>(ItemReference.Egg);
        internal static Item Tomato => GetExistingGDO<Item>(ItemReference.Tomato);

        internal static Process Cook => GetExistingGDO<Process>(ProcessReference.Cook);
        internal static Process Chop => GetExistingGDO<Process>(ProcessReference.Chop);

        internal static ItemGroup RawNoodles => GetModdedGDO<ItemGroup, RawNoodles>();
        internal static ItemGroup RawNoodlePot => GetModdedGDO<ItemGroup, RawNoodlePot>();
        internal static Item CookedNoodles => GetModdedGDO<Item, CookedNoodles>();
        internal static Item CookedNoodlePot => GetModdedGDO<Item, CookedNoodlePot>();
        internal static Item BurntNoodlePot => GetModdedGDO<Item, BurntNoodlePot>();

        internal static ItemGroup UncookedRedSauce => GetModdedGDO<ItemGroup, UncookedRedSauce>();
        internal static Item ServedRedSauce => GetModdedGDO<Item, ServedRedSauce>();
        internal static Item CookedRedSauce => GetModdedGDO<Item, CookedRedSauce>();

        internal static ItemGroup UncookedWhiteSauce => GetModdedGDO<ItemGroup, UncookedWhiteSauce>();
        internal static Item ServedWhiteSauce => GetModdedGDO <Item, ServedWhiteSauce>();
        internal static Item CookedWhiteSauce => GetModdedGDO <Item, CookedWhiteSauce>();

        internal static ItemGroup PlatedPasta => GetModdedGDO <ItemGroup, PlatedPasta>();
        internal static Dish PastaBase => GetModdedGDO <Dish, PastaBase>();
        internal static Dish PastaWhite => GetModdedGDO <Dish, PastaWhite>();

        internal static AssetBundle bundle;
        internal static bool debug = true;

        public Mod() : base(MOD_NAME, MOD_VERSION, $"{PLATEUP_VERSION}", Assembly.GetExecutingAssembly())
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string commons = Uri.UnescapeDataString(uri.Path);
            string steamapps = Directory.GetParent(commons).FullName;
            string workshop = Path.Combine(steamapps, "workshop");
            string content = Path.Combine(workshop, "content");
            string bundlePath = "";

            if (debug) 
                bundlePath = Path.Combine(new string[] { Directory.GetParent(Application.dataPath).FullName, "BepInEx", "plugins", "PastaPalace", "assets", "pastapalacetextures" });

            bundle = AssetBundle.LoadFromFile(bundlePath);
            Debug.Log($"{MOD_NAME} {MOD_VERSION} {MOD_AUTHOR}: Loaded");
        }

        protected override void Initialise()
        {
            base.Initialise();

            AddGameDataObject<RawNoodles>();
            AddGameDataObject<CookedNoodles>();
            AddGameDataObject<BurntNoodlePot>();
            AddGameDataObject<RawNoodlePot>();
            AddGameDataObject<CookedNoodlePot>();

            AddGameDataObject<UncookedRedSauce>();
            AddGameDataObject<CookedRedSauce>();
            AddGameDataObject<ServedRedSauce>();

            AddGameDataObject<UncookedWhiteSauce>();
            AddGameDataObject<CookedWhiteSauce>();
            AddGameDataObject<ServedWhiteSauce>();

            AddGameDataObject<PlatedPasta>();
            AddGameDataObject<PastaBase>();
            AddGameDataObject<PastaWhite>();
        }

        protected override void OnUpdate() { }

        private static T1 GetModdedGDO<T1, T2>() where T1 : GameDataObject
        {
            return (T1)CustomGDO.GetGameDataObject<T2>().GameDataObject;
        }

        private static T GetExistingGDO<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }
    }
}
