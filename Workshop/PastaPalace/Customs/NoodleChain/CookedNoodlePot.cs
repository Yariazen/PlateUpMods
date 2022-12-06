using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs.NoodleChain
{
    internal class CookedNoodlePot : CustomItem
    {
        public override string UniqueNameID => "CookedNoodlePot";
        public override GameObject Prefab => (GameObject)Mod.bundle.LoadAsset("Noodles_-_Pot_Cooked");
        public override Item DisposesTo => Mod.Pot;
        public override int SplitCount => 6;
        public override Item SplitSubItem => Mod.CookedNoodles;
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            Mod.Pot
        };
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 30,
                Process = Mod.Cook,
                Result = Mod.BurntNoodlePot
            }
        };
    }
}
