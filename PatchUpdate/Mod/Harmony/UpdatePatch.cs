using HarmonyLib;
using KCustomRadial;


[HarmonyPatch(typeof(PlayerMoveController))]
[HarmonyPatch("Update")]
class Patch
{
    public static bool Prefix(PlayerMoveController __instance, LocalPlayerUI ___playerUI, EntityPlayerLocal ___entityPlayerLocal)
    {
        if (__instance.playerInput.Prefab.WasPressed)
        {
            // your stuff here
            XUiC_Radial _xuiRadialWindow = ___playerUI.xui.RadialWindow;
            KProCustomRadial.KSetupRadial(__instance, _xuiRadialWindow, ___entityPlayerLocal);
            			

            return false;
        }
        return true;

    }
}
