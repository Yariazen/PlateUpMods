using Kitchen;
using KitchenData;
using KitchenLib.Utils;
using System;
using YariazenCore.Framework.Events;

namespace YariazenCore.Framework
{
    public class YariazenPatch
    {
        private static Action<string> Log;
        private static Action<string> Error;

        internal static void Initialize(Action<string> log, Action<string> error)
        {
            Log = log;
            Error = error;
        }

        private static bool Spawned = false;

        public static void Postfix_GameDataConstructor_BuildGameData(GameData __result)
        {
            GameDataConstructorEventArgs GameDataConstructorEventArgs = new GameDataConstructorEventArgs(__result);
            YariazenUtility.InvokeEvent(nameof(YariazenEvents.GameDataConstructor), YariazenEvents.GameDataConstructor?.GetInvocationList(), null, GameDataConstructorEventArgs);
        }

        public static void Postfix_ProvideStartingEnvelopes_OnUpdate(ProvideStartingEnvelopes __instance)
        {
            if(!Spawned)
            {
                SpawnUtils.SpawnApplianceBlueprint<CreativeTerminal>();
                Spawned = true;
            }
        }
    }
}
