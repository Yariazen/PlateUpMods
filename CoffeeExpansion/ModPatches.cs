using Kitchen;
using KitchenLib.Utils;
using System;

namespace CoffeeExpansion
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

        public static void Postfix_ProvideStartingEnvelopes_OnUpdate(ProvideStartingEnvelopes __instance)
        {
            if (!Spawned)
            {
                SpawnUtils.SpawnApplianceBlueprint<CreativeTerminal>();
                Spawned = true;
            }
        }
    }
}
