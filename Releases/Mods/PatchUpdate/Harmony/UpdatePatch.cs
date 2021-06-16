using System;
using System.Collections.Generic;
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
            KProCustomRadial.Test();
            KHelper.EasyLog("K was pressed.", LogLevel.Chat);
        }
        return true;

    }
}
