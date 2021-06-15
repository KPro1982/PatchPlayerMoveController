using HarmonyLib;
using System.Collections.Generic;
using System.Text;
using KPatchUpdate;


namespace kScripts.Mod.Harmony
{
    // Make sure all items are available.
    [HarmonyPatch(typeof(ItemActionEntryRepair))]
    [HarmonyPatch("OnActivated")]
    public class SphereII_ItemActionEntryRepair_OnActivated
    {
        public static bool Prefix(ItemActionEntryRepair __instance)
        {
            SphereII_Guts.DoGuts(__instance);
            return true;
        }
    }

    

}

