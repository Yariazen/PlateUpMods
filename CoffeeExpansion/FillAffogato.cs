using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using static KitchenData.Appliance;
using static KitchenData.Item;

namespace CoffeeExpansion
{
    internal class FillAffogato : CustomApplianceProcess
    {
        public override Process Process => (Process)GDOUtils.GetExistingGDO(Mod.FillCoffeeID);
        public override string UniqueName => "Fill Affogato";
        public override bool IsAutomatic => true;
        public override float Speed => 1f;
        public override ProcessValidity Validity => ProcessValidity.Generic;

        public override void Convert(out ApplianceProcesses applianceProcess)
        {
            base.Convert(out applianceProcess);
        }

        public override void Convert(out ItemProcess itemProcess)
        {
            throw new System.NotImplementedException();
        }
    }
}