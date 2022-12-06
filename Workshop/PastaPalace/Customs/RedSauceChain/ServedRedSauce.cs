using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace PastaPalace.Customs.RedSauceChain
{
    internal class ServedRedSauce : CustomItem
    {
        public override string UniqueNameID => "ServedRedSauce";
        public override GameObject Prefab => Mod.Tomato.Prefab;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            // Material[] materials = { MaterialUtils.GetExistingMaterial("Tomato Flesh") };
            // MaterialUtils.ApplyMaterial(Prefab, "sauce.blend", materials);
        }
    }
}
