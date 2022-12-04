using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs
{
    internal class RawNoodles : CustomItemGroup
    {
        public override string UniqueNameID => "RawNoodles";

        public override GameObject Prefab => (GameObject)Mod.bundle.LoadAsset("pasta");

        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<ItemGroup.ItemSet> DerivedSets
        {
            get
            {
                List<ItemGroup.ItemSet> derivedSets = new List<ItemGroup.ItemSet>();

                ItemGroup.ItemSet ingredients = new ItemGroup.ItemSet();
                ingredients.Max = 2;
                ingredients.Min = 2;
                ingredients.IsMandatory = true;
                ingredients.Items.Add((Item)GDOUtils.GetExistingGDO(Mod.FlourID));
                ingredients.Items.Add((Item)GDOUtils.GetExistingGDO(Mod.EggCrackedID));

                derivedSets.Add(ingredients);
                return derivedSets;
            }
        }
    }
}
