using HarmonyLib;

namespace TASsenger.Inputs.Combat
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetGraplou")]
    public static class Rope
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Rope;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetGraplouDown")]
    public static class RopeDown
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Rope && !TASsenger.Previous.Rope;
                return false;
            }
            return true;
        }
    }
}
