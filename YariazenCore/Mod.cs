using HarmonyLib;
using KitchenData;
using YariazenCore.Framework;
using KitchenLib.Customs;
using YariazenCore.Framework.Events;
using Kitchen;
namespace YariazenCore
{
    public class Mod : YariazenMod
    {
        public CustomAppliance d;
        public int CreativeTerminalID;
        public static GameData gamedata;

        public Mod() : base("Yariazen.YariazenCore", ">=1.0.0", new[] { "KitchenLib" })
        {
            YariazenPatch.Initialize(Log, Error);
            YariazenUtility.Initialize(Log, Error);
            YariazenEvents.GameDataConstructor += OnGameDataConstructor;
        }

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            HarmonyLib.Harmony harmony = this.HarmonyInstance;

            harmony.Patch(
                original: AccessTools.Method(typeof(GameDataConstructor), "BuildGameData"),
                postfix:
                    new HarmonyMethod(
                        typeof(YariazenPatch).GetMethod(nameof(YariazenPatch.Postfix_GameDataConstructor_BuildGameData)),
                        priority: HarmonyLib.Priority.First)
            );

            harmony.Patch(
                original: AccessTools.Method(typeof(ProvideStartingEnvelopes), "OnUpdate"),
                postfix: new HarmonyMethod(typeof(YariazenPatch), nameof(YariazenPatch.Postfix_ProvideStartingEnvelopes_OnUpdate))
            );
        }

        private void OnGameDataConstructor(object sender, GameDataConstructorEventArgs e)
        {
            gamedata = e.gamedata;
            d = AddAppliance<CreativeTerminal>();
        }
    }
}
