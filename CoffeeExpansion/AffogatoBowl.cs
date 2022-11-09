using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.Item;

namespace CoffeeExpansion
{
    internal class AffogatoBowl : CustomItem
    {
        public override GameObject Prefab => (GameObject)Mod.assetbundle.LoadAsset("Affogato");

        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override ItemValue ItemValue => ItemValue.SideLarge;

        public override int MaxOrderSharers => 2;
    }
}
