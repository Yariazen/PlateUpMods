using HarmonyLib;
using KitchenData;
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

        public static void Postfix_GameDataConstructor_BuildGameData(GameDataConstructor __instance, GameData __result)
        {
            GameDataConstructorEventArgs GameDataConstructorEventArgs = new GameDataConstructorEventArgs(__result);
            YariazenUtility.InvokeEvent(nameof(YariazenEvents.GameDataConstructor), YariazenEvents.GameDataConstructor?.GetInvocationList(), null, GameDataConstructorEventArgs);
        }
    }
}
