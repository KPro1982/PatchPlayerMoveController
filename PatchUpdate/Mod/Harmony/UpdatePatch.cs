using HarmonyLib;
using KCustomRadial;


[HarmonyPatch(typeof(PlayerMoveController))]
[HarmonyPatch("Update")]
class Patch
{
    public static bool Prefix(PlayerMoveController __instance)
    {
        if (__instance.playerInput.Prefab.WasPressed)
        {
            // your stuff here
            
            KProCustomRadial.KSetupRadial(__instance);
            
            return false;
        }
        return true;

    }
}
