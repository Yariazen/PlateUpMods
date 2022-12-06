using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs.PastaProcess
{
    internal class PlatedPasta : CustomItemGroup
    {
        public override string UniqueNameID => "Plated Pasta";
        public override GameObject Prefab => Mod.Tomato.Prefab;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    Mod.CookedNoodles
                }
            },
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                RequiresUnlock = true,
                Items = new List<Item>
                {
                    Mod.ServedRedSauce,
                    Mod.ServedWhiteSauce
                }
            },
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 0,
                Items = new List<Item>
                {
                    Mod.BroccoliChoppedContainerCooked,
                    Mod.MeatChoppedContainerCooked
                }
            },
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    Mod.Plate
                }
            }
        };
    }
}
