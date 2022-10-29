using KitchenData;
using KitchenLib;
using KitchenLib.Event;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CoffeeExpansion
{
    public class Mod : BaseMod
    {
        internal const int CoffeeMachineID = -1609758240;
        internal const int FillCoffeeID = -1316622579;
        internal const int IceCreamGroupID = -1307479546;

        internal static AssetBundle bundle;
        internal static FillAffogato fillAffogato = new FillAffogato();

        public Mod() : base("Yariazen.CoffeeExpansion", ">=1.0.0") 
        {
            Events.BuildGameDataEvent += OnBuildGameDataEvent;
        }

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();
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
            Appliance appliance = e.gamedata.Get<Appliance>().FirstOrDefault(a => a.ID == CoffeeMachineID);
            Appliance.ApplianceProcesses applianceProcess = new Appliance.ApplianceProcesses();
            fillAffogato.Convert(out applianceProcess);
            appliance.Processes.Add(applianceProcess);
        }
    }
}
