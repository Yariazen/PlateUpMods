using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.Appliance;

namespace YariazenCore.Framework
{
    public sealed class YariazenAppliance : CustomAppliance
    {
        private string YariazenName;
        private string YariazenDescription;
        private bool YariazenIsNonInteractive;
        private OccupancyLayer YariazenLayer;
        private bool YariazenForceHighInteractionPriority;
        private int YariazenPurchaseCost;
        private EntryAnimation YariazenEntryAnimation;
        private ExitAnimation YariazenExitAnimation;
        private bool YariazenSkipRotationAnimation;
        private bool YariazenIsPurchasable;
        private bool YariazenIsPurchasableAsUpgrade;
        private DecorationType YariazenThemeRequired;
        private ShoppingTags YariazenShoppingTags;
        private RarityTier YariazenRarityTier;
        private PriceTier YariazenPriceTier;
        private ShopRequirementFilter YariazenShopRequirementFilter;
        private List<Appliance> YariazenRequiresForShop;
        private List<Process> YariazenRequiresProcessForShop;
        private bool YariazenStapleWhenMissing;
        private bool YariazenSellOnlyAsDuplicate;
        private bool YariazenPreventSale;
        private List<Appliance> YariazenUpgrades;
        private bool YariazenIsAnUpgrade;
        private bool YariazenIsNonCrated;
        private Item YariazenCrateItem;

        private int YariazenID;
        private GameObject YariazenPrefab;
        private GameObject YariazenHeldAppliancePrefab;
        private IEffectRange YariazenEffectRange;
        private IEffectCondition YariazenEffectCondition;
        private IEffectType YariazenEffectType;
        private EffectRepresentation YariazenEffectRepresentation;
        private List<Appliance.ApplianceProcesses> YariazenProcesses;
        private List<IApplianceProperty> YariazenProperties;
        private List<Section> YariazenSections;
        private List<string> YariazenTags;

        private int YariazenBaseApplianceId;
        private int YariazenBasePrefabId;

        public YariazenAppliance()
        {
            this.YariazenName = "Appliance";
            this.YariazenDescription = "A little something for your restaurant";
        }

        public YariazenAppliance(string name, string description)
        {
            this.YariazenName = name;
            this.YariazenDescription = description;
        }

        public YariazenAppliance(string name, string description, Appliance appliance)
        {
            this.YariazenName = name;
            this.YariazenDescription = description;

            this.YariazenIsNonInteractive = appliance.IsNonInteractive;
            this.YariazenLayer = appliance.Layer;
            this.YariazenForceHighInteractionPriority = appliance.ForceHighInteractionPriority;
            this.YariazenPurchaseCost = appliance.PurchaseCost;
            this.YariazenEntryAnimation = appliance.EntryAnimation;
            this.YariazenExitAnimation = appliance.ExitAnimation;
            this.YariazenSkipRotationAnimation = appliance.SkipRotationAnimation;
            this.YariazenIsPurchasable = appliance.IsPurchasable;
            this.YariazenIsPurchasableAsUpgrade = appliance.IsPurchasableAsUpgrade;
            this.YariazenThemeRequired = appliance.ThemeRequired;
            this.YariazenShoppingTags = appliance.ShoppingTags;
            this.YariazenRarityTier = appliance.RarityTier;
            this.YariazenPriceTier = appliance.PriceTier;
            this.YariazenShopRequirementFilter = appliance.ShopRequirementFilter;
            this.YariazenRequiresForShop = appliance.RequiresForShop;
            this.YariazenRequiresProcessForShop = appliance.RequiresProcessForShop;
            this.YariazenStapleWhenMissing = appliance.StapleWhenMissing;
            this.YariazenSellOnlyAsDuplicate = appliance.SellOnlyAsDuplicate;
            this.YariazenPreventSale = appliance.PreventSale;
            this.YariazenUpgrades = appliance.Upgrades;
            this.YariazenIsAnUpgrade = appliance.IsAnUpgrade;
            this.YariazenIsNonCrated = appliance.IsNonCrated;
            this.YariazenCrateItem = appliance.CrateItem;
        }

        public sealed override string Name => this.YariazenName;
        public sealed override string Description => this.YariazenDescription;
        public sealed override bool IsNonInteractive => this.YariazenIsNonInteractive;
        public new OccupancyLayer Layer {get{return this.YariazenLayer;} }
        public sealed override bool ForceHighInteractionPriority => this.YariazenForceHighInteractionPriority;
        public new int PurchaseCost => this.YariazenPurchaseCost;
        public sealed override EntryAnimation EntryAnimation => this.YariazenEntryAnimation;
        public sealed override ExitAnimation ExitAnimation => this.YariazenExitAnimation;
        public sealed override bool SkipRotationAnimation => this.YariazenSkipRotationAnimation;
        public sealed override bool IsPurchasable => this.YariazenIsPurchasable;
        public sealed override bool IsPurchasableAsUpgrade => this.YariazenIsPurchasableAsUpgrade;
        public sealed override DecorationType ThemeRequired => this.YariazenThemeRequired;
        public sealed override ShoppingTags ShoppingTags => this.YariazenShoppingTags;
        public sealed override RarityTier RarityTier => this.YariazenRarityTier;
        public sealed override PriceTier PriceTier => this.YariazenPriceTier;
        public sealed override ShopRequirementFilter ShopRequirementFilter => this.YariazenShopRequirementFilter;
        public sealed override List<Appliance> RequiresForShop => this.YariazenRequiresForShop;
        public sealed override List<Process> RequiresProcessForShop => this.YariazenRequiresProcessForShop;
        public sealed override bool StapleWhenMissing => this.YariazenStapleWhenMissing;
        public sealed override bool SellOnlyAsDuplicate => this.YariazenSellOnlyAsDuplicate;
        public sealed override bool PreventSale => this.YariazenPreventSale;
        public sealed override List<Appliance> Upgrades => this.YariazenUpgrades;
        public sealed override bool IsAnUpgrade => this.YariazenIsAnUpgrade;
        public sealed override bool IsNonCrated => this.YariazenIsNonCrated;
        public new Item CrateItem => this.YariazenCrateItem;
        public new int ID => this.YariazenID;
        public new GameObject Prefab => this.YariazenPrefab;
        public new GameObject HeldAppliancePrefab => this.YariazenHeldAppliancePrefab;
        public new IEffectRange EffectRange => this.YariazenEffectRange;
        public new IEffectCondition EffectCondition => this.YariazenEffectCondition;
        public new IEffectType EffectType => this.YariazenEffectType;
        public new EffectRepresentation EffectRepresentation => this.YariazenEffectRepresentation;
        public new List<Appliance.ApplianceProcesses> Processes => this.YariazenProcesses;
        public new List<IApplianceProperty> Properties => this.YariazenProperties;
        public new List<Section> Sections => this.YariazenSections;
        public new List<string> Tags => this.YariazenTags;
        public sealed override int BaseApplianceId => this.YariazenBaseApplianceId;
        public sealed override int BasePrefabId => this.YariazenBasePrefabId;
    }
}
