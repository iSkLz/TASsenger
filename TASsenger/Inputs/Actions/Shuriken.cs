using HarmonyLib;

namespace TASsenger.Inputs.Combat
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetShuriken")]
    public static class Shuriken
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Shuriken;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetShurikenDown")]
    public static class ShurikenDown
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Shuriken && !TASsenger.Previous.Shuriken;
                return false;
            }
            return true;
        }
    }
}
