using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs.NoodleChain
{
    internal class BurntNoodlePot : CustomItem
    {
        public override string UniqueNameID => "BurntNoodlePot";
        public override GameObject Prefab => Mod.Tomato.Prefab;
        public override Item DisposesTo => Mod.Pot;
        public override int SplitCount => 6;
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            Mod.Pot
        };
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
    }
}
