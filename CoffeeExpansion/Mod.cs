using HarmonyLib;
using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Event;
using KitchenLib.Reference;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static KitchenData.Item;

namespace CoffeeExpansion
{
    public class Mod : BaseMod
    {
        internal const int OrderingTerminalID = ApplianceReference.OrderingTerminal;
        internal const int FillCoffeeID = ProcessReference.FillCoffee;
        internal const int IceCreamGroupID = KitchenLib.Reference.ItemReference.IceCreamServing;
        internal const int CoffeeMachineID = ApplianceReference.CoffeeMachine;

        internal static GameData gamedata;
        internal static AssetBundle assetbundle;

        internal static CustomAppliance CreativeTerminal;
        internal static CustomApplianceProcess FillAffogato;
        internal static CustomItem AffogatoBowl;

        public Mod() : base("Yariazen.CoffeeExpansion", ">=1.0.0")
        {
            YariazenPatch.Initialize(Log, Error);

            Events.BuildGameDataEvent += OnBuildGameDataEvent;
        }

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();

            HarmonyLib.Harmony harmony = this.HarmonyInstance;
            harmony.Patch(
                original: AccessTools.Method(typeof(ProvideStartingEnvelopes), "OnUpdate"),
                postfix: new HarmonyMethod(typeof(YariazenPatch), nameof(YariazenPatch.Postfix_ProvideStartingEnvelopes_OnUpdate))
            );

            string assetBundlePath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "Mods", "CoffeeExpansion", "coffeeadditions");
            assetbundle = AssetBundle.LoadFromFile(assetBundlePath);
        }

        private void OnBuildGameDataEvent(object sender, BuildGameDataEventArgs e)
        {
            gamedata = e.gamedata;
            CreativeTerminal = AddGameDataObject<CreativeTerminal>();
            FillAffogato = AddSubProcess<FillAffogato>();
            AffogatoBowl = AddGameDataObject<AffogatoBowl>();
        }
    }
        /*
        internal const int CoffeeMachineID = -1609758240;
        internal const int FillCoffeeID = -1316622579;
        internal const int IceCreamGroupID = -1307479546;

        internal const int OrderingTerminalID = -1610332021;

        internal static GameData gamedata;
        internal static AssetBundle bundle;
        internal static FillAffogato fillAffogato = new FillAffogato();

        public Mod() : base("Yariazen.CoffeeExpansion", ">=1.0.0") 
        {
            YariazenPatch.Initialize(Log, Error);

            Events.BuildGameDataEvent += OnBuildGameDataEvent;
        }

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();

            HarmonyLib.Harmony harmony = this.HarmonyInstance;
            harmony.Patch(
                original: AccessTools.Method(typeof(ProvideStartingEnvelopes), "OnUpdate"),
                postfix: new HarmonyMethod(typeof(YariazenPatch), nameof(YariazenPatch.Postfix_ProvideStartingEnvelopes_OnUpdate))
            );

            string assetBundlePath = Path.Combine(Path.GetDirectoryName(Application.dataPath), "Mods", "CoffeeExpansion", "coffeeadditions");
            Log($"Path:\t\t{assetBundlePath}");
            Log($"Exists:\t{File.Exists(assetBundlePath)}");
            bundle = AssetBundle.LoadFromFile(assetBundlePath);
            Log($"Bundle:\t{(bundle == null)}");

            AddGameDataObject<AffogatoBowl>();
            AddSubProcess<FillAffogato>();

            
        }

        private void OnBuildGameDataEvent(object sender, BuildGameDataEventArgs e)
        {
            gamedata = e.gamedata;

            Appliance appliance = gamedata.Get<Appliance>().FirstOrDefault(a => a.ID == CoffeeMachineID);
            Appliance.ApplianceProcesses applianceProcess = new Appliance.ApplianceProcesses();
            fillAffogato.Convert(out applianceProcess);
            appliance.Processes.Add(applianceProcess);

            AddGameDataObject<CreativeTerminal>();
        }
        */
    }
}
