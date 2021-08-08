using HarmonyLib;

namespace TASsenger.Inputs.Combat
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetRightTrigger")]
    public static class Tabi
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Tabi;
                return false;
            }
            return true;
        }
    }
}
