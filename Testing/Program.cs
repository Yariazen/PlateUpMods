using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Testing
{
    public class Main : BaseMod
    {
        internal const string MOD_ID = $"{MOD_AUTHOR}.{MOD_NAME}";
        internal const string MOD_NAME = "Test Mod";
        internal const string MOD_VERSION = "1.0.0";
        internal const string MOD_AUTHOR = "Yariazen";
        internal const string PLATEUP_VERSION = "1.1.2";

        internal static Item Tomato => GetExistingGDO<Item>(ItemReferences.Tomato);
        internal static Item Plate => GetExistingGDO<Item>(ItemReferences.Plate);

        internal static Item Honey => GetModdedGDO<Item, Honey>();

        public Main() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, $"{PLATEUP_VERSION}", Assembly.GetExecutingAssembly()) { }

        protected override void Initialise()
        {
            AddGameDataObject<TestItemGroup>();
        }

        private static T1 GetModdedGDO<T1, T2>() where T1 : GameDataObject
        {
            return (T1)GDOUtils.GetCustomGameDataObject<T2>().GameDataObject;
        }

        private static T GetExistingGDO<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }

        internal class TestItemGroup : CustomItemGroup
        {
            public override string UniqueNameID => "TestItemGroup";
            public override GameObject Prefab => Tomato.Prefab;
            public override ItemCategory ItemCategory => ItemCategory.Generic;
            public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
            public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
            {
                new ItemGroup.ItemSet()
                {
                    Max = 2,
                    Min = 2,
                    Items = new List<Item>()
                    {
                        Honey,
                        Plate
                    }
                }
            };

            public override void OnRegister(GameDataObject gdo)
            {
                gdo.name = "Ingredient - Raw Noodles";
            }
        }
    }
}
