using HarmonyLib;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.SaveLoad;

namespace SavePreviewFix
{
    // The hero tableau's texture provider is only created after the tableau widget has been rendered once,
    // but SaveLoadMainHeroVisualWidget hides the tableau until that provider reports a compatible character
    // code. Neither happens, so the save/load screen always falls back to the silhouette. Showing the
    // tableau while its provider is missing lets the provider be created; the vanilla logic takes over after.
    [HarmonyPatch(typeof(SaveLoadMainHeroVisualWidget), "OnLateUpdate")]
    public static class SaveLoadMainHeroVisualWidgetPatch
    {
        public static void Postfix(SaveLoadMainHeroVisualWidget __instance)
        {
            SaveLoadHeroTableauWidget tableau = __instance.SaveLoadHeroTableau;
            if (tableau == null || tableau.TextureProvider != null) return;
            if (__instance.IsVisualDisabledForMemoryPurposes || string.IsNullOrEmpty(tableau.HeroVisualCode)) return;

            tableau.IsVisible = true;
        }
    }
}
