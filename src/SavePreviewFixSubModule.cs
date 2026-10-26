using HarmonyLib;
using TaleWorlds.MountAndBlade;

namespace SavePreviewFix
{
    public class SavePreviewFixSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            // Pass the assembly explicitly: the parameterless PatchAll() finds it from the call stack, which can miss our assembly.
            new Harmony("savepreviewfix.bannerlord").PatchAll(typeof(SavePreviewFixSubModule).Assembly);
        }
    }
}
