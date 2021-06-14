using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(PlayerMoveController))]
[HarmonyPatch("Update")]
class Patch
{
    public static bool Prefix()
    {
        return true;

    }
}


// Token: 0x17000031 RID: 49
// (get) Token: 0x06000089 RID: 137 RVA: 0x00003004 File Offset: 0x00001204
/*public bool IsPressed
{
    get
    {
        int num = this.keyCodes.Length;
        for (int i = 0; i < num; i++)
        {
            if (Input.GetKey(this.keyCodes[i]))
            {
                return true;
            }
        }
        return false;
    }
}*/