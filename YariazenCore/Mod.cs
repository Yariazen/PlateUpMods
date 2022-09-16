using HarmonyLib;
using KitchenData;
using Newtonsoft.Json;
using System.IO;
using YariazenCore.Framework;
using UnityEngine;
using KitchenLib.Customs;

namespace YariazenCore
{
    public class Mod : YariazenMod
    {
        internal ModConfig Config;

        public static AssetBundle bundle;
        public static CustomAppliance d;

        public Mod() : base("Yariazen.YariazenCore", ">=1.0.0", new[] { "KitchenLib" })
        {
            YariazenPatch.Initialize(Log, Error);
            YariazenUtility.Initialize(Log, Error);
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

            if (!Directory.Exists(ModPath))
            {
                Directory.CreateDirectory(ModPath);
            }
            if (!File.Exists(ConfigPath))
            {
                Config = new ModConfig();
                File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(Config));
            }
            else
            {
                Config = JsonConvert.DeserializeObject<ModConfig>(File.ReadAllText(ConfigPath));
            }

            if (Config.Debug)
            {
                d = AddAppliance<CreativeTerminal>();
            }
        }
    }
}
