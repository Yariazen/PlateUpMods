using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Framework.Customs
{
    internal class RawNoodles : CustomItemGroup
    {
        public override string UniqueNameID => "RawNoodles";

        public override GameObject Prefab => (GameObject)Mod.bundle.LoadAsset("pasta");

        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override List<ItemGroup.ItemSet> Sets
        {
            get
            {
                List<ItemGroup.ItemSet> derivedSets = new List<ItemGroup.ItemSet>();

                ItemGroup.ItemSet ingredients = new ItemGroup.ItemSet();
                ingredients.Max = 2;
                ingredients.Min = 2;
                ingredients.IsMandatory = true;
                List<Item> items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(Mod.FlourID),
                    (Item)GDOUtils.GetExistingGDO(Mod.EggCrackedID)
                };
                ingredients.Items = items;

                derivedSets.Add(ingredients);
                return derivedSets;
            }
        }

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Material[] materials = { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            MaterialUtils.ApplyMaterial(Prefab, "pasta.blend", materials);
        }
    }
}
