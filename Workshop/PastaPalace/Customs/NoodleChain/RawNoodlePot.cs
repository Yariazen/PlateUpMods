using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs.NoodleChain
{
    internal class RawNoodlePot : CustomItemGroup
    {
        public override string UniqueNameID => "RawNoodlePot";
        public override GameObject Prefab => (GameObject)Mod.bundle.LoadAsset("Spaghetti_-_Pot");
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
                    Mod.Water,
                    Mod.RawNoodles
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
        public override List<ItemGroup.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 10,
                Process = Mod.Cook,
                Result = Mod.CookedNoodlePot
            }
        };
    }
}
