using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace SavePreviewFix
{
    public class SavePreviewFixSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            new Harmony("savepreviewfix.bannerlord").PatchAll();
        }
    }
}
