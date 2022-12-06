using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs.WhiteSauceChain
{
    public class UncookedWhiteSauce : CustomItemGroup
    {
        public override string UniqueNameID => "RawWhiteSauce";
        public override GameObject Prefab => Mod.Tomato.Prefab;
        public override Item DisposesTo => Mod.Pot;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>
                {
                    Mod.Onion,
                    Mod.Cheese
                }
            },
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    Mod.Pot
                }
            }
        };
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 8,
                Process = Mod.Cook,
                Result = Mod.CookedWhiteSauce
            }
        };
    }
}
