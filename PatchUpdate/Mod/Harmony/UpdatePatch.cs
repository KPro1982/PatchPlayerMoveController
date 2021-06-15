using HarmonyLib;
using KPatchUpdate;

[HarmonyPatch(typeof(PlayerMoveController))]
[HarmonyPatch("Update")]
class Patch
{
    public static bool Prefix(PlayerMoveController __instance )
    {
        if (__instance.playerInput.Prefab.WasPressed)
        {
            KReadXml.GetXml();
            // KProCustomRadial.KProSetupRadial();
            
        }
        return true;

    }
}
