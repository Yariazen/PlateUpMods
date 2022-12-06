using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs.WhiteSauceChain
{
    internal class CookedWhiteSauce : CustomItem
    {
        public override string UniqueNameID => "CookedWhiteSauce";
        public override GameObject Prefab => Mod.Tomato.Prefab;
        public override Item DisposesTo => Mod.Pot;
        public override int SplitCount => 4;
        public override bool PreventExplicitSplit => true;
        public override Item SplitSubItem => Mod.ServedWhiteSauce;
        public override List<Item> SplitDepletedItems => new List<Item>
        {
           Mod.Pot
        };
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
    }
}
