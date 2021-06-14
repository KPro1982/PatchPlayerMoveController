using HarmonyLib;
using PatchUpdate;

[HarmonyPatch(typeof(PlayerMoveController))]
[HarmonyPatch("Update")]
class Patch
{
    public static bool Prefix(PlayerMoveController __instance )
    {
        if (__instance.playerInput.Prefab.WasPressed)
        {
            // your stuff here
            KProCustomRadial.KProSetupRadial();
            return false;
        }
        return true;

    }
}
