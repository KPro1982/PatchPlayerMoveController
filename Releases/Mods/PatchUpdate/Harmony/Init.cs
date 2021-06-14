using DMT;
using HarmonyLib;


public class KProInit : IHarmony
{
    public void Start()
    {
        var harmony = new Harmony("app.kpro.mod");
        harmony.PatchAll();
    }
}