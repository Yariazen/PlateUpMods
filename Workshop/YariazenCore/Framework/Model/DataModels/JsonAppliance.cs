using System.Collections.Generic;

namespace YariazenCore.Framework.Model.JsonModels
{
    public class JsonAppliance : JsonGameDataObject
    {
        public struct JsonApplianceProcess
        {
            public int Process { get; set; }
            public bool IsAutomatic { get; set; }
            public float Speed { get; set; }
            public string Validity { get; set; }
        }

        public struct JsonSection
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string RangeDescription { get; set; }
        }

        public string Prefab { get; set; }
        public string HeldAppliancePrefab { get; set; }
        public List<JsonApplianceProcess> Processes { get; set; }
        public int EffectRepresentation { get; set; }
        public bool IsNonInteractive { get; set; }
        public string Layer { get; set; }
        public bool ForceHighInteractionPriority { get; set; }
        public int PurchaseCost { get; set; } = 0;
        public bool SkipRotationAnimation { get; set; }
        public bool IsPurchasable { get; set; }
        public bool IsPurchasableAsUpgrade { get; set; }
        public string ThemeRequired { get; set; }
        public string ShoppingTags { get; set; } = "None";
        public string RarityTier { get; set; } = "Common";
        public string PriceTier { get; set; } = "Medium";
        public string ShopRequirementFilter { get; set; }
        public List<string> RequiresForShop { get; set; } = new List<string>();
        public List<string> RequiresProcessForShop { get; set; } = new List<string>();
        public bool StapleWhenMissing { get; set; }
        public bool SellOnlyAsDuplicate { get; set; }
        public bool PreventSale { get; set; }
        public List<string> Upgrades { get; set; } = new List<string>();
        public bool IsAnUpgrade { get; set; }
        public bool IsNonCrated { get; set; }
        public string CrateItem { get; set; }
        public string Name { get; set; } = "Appliance";
        public string Description { get; set; } = "A little something for your restaurant";
        public List<JsonSection> Sections { get; set; } = new List<JsonSection>();
        public List<string> Tags { get; set; } = new List<string>();

        //public virtual List<IApplianceProperty> Properties { get { return new List<IApplianceProperty>(); } }
        //public virtual IEffectRange EffectRange { get; internal set; }
        //public virtual IEffectCondition EffectCondition { get; internal set; }
        //public virtual IEffectType EffectType { get; internal set; }
        //public virtual EntryAnimation EntryAnimation { get; internal set; }
        //public virtual ExitAnimation ExitAnimation { get; internal set; }
    }
}
