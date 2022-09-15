using HarmonyLib;
using KitchenData;
using KitchenLib;
using YariazenCore.Framework;

namespace YariazenCore
{
    public class YariazenMod : BaseMod
    {
        public string ModAuthor { get { return Info.Author; } }
        public string UniqueID { get { return $"{ModAuthor}.{ModName}"; } }
        public YariazenMod(string modID, string compatibleVersions, string[] modDependencies = null) : base(modID, compatibleVersions, modDependencies) { }

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            YariazenPatch.Initialize(Log, Error);
            YariazenUtility.Initialize(Log, Error);

            HarmonyLib.Harmony harmony = HarmonyInstance;
            harmony.Patch(
                original: AccessTools.Method(typeof(GameDataConstructor), "BuildGameData"),
                postfix: new HarmonyMethod(typeof(YariazenPatch), nameof(YariazenPatch.Postfix_GameDataConstructor_BuildGameData))
            );
        }
    }
}
