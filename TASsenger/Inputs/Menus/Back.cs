using HarmonyLib;

namespace TASsenger.Inputs.Menus
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetBackDown")]
    public static class Back
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Back && !TASsenger.Previous.Back;
                return false;
            }
            return true;
        }
    }
}
