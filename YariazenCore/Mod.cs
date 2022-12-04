using HarmonyLib;
using Kitchen;
using KitchenMods;
using UnityEngine;
using YariazenCore.Framework;

namespace YariazenCore
{
    public class Mod : GenericSystemBase, IModSystem
    {
        internal const string MOD_NAME = "YariazenCore";
        internal const string MOD_VERSION = "0.0.0";

        public Mod()
        {
            Debug.Log($"{MOD_NAME} {MOD_VERSION}: Loaded");

            Paths.Initialize();

            Harmony harmony = new Harmony(MOD_NAME);
        }

        protected override void Initialise()
        {
            base.Initialise();
            
        }

        protected override void OnUpdate() { }
    }
}
