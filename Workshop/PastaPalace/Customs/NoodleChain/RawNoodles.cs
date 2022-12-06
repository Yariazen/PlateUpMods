using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace PastaPalace.Customs.NoodleChain
{
    internal class RawNoodles : CustomItemGroup
    {
        public override string UniqueNameID => "RawNoodles";
        public override GameObject Prefab => (GameObject)Mod.bundle.LoadAsset("Spaghetti");
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
                    Mod.Flour,
                    Mod.EggCracked
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            //Material[] materials = { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            //MaterialUtils.ApplyMaterial(Prefab, "pasta.blend", materials);
        }
    }
}
