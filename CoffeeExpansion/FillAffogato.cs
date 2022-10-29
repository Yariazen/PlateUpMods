using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine.Assertions.Comparers;

namespace CoffeeExpansion
{
    internal class FillAffogato : CustomApplianceProcess
    {
        public override Process Process => (Process)GDOUtils.GetExistingGDO(Mod.FillCoffeeID);
        public override string UniqueName => "Fill Affogato";
        public override bool IsAutomatic => true;
        public override float Speed => 1.5f;
        public override ProcessValidity Validity => ProcessValidity.Generic;

        public override void Convert(out Item.ItemProcess itemProcess)
        {
            throw new System.NotImplementedException();
        }
    }
}
