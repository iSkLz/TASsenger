using HarmonyLib;

namespace TASsenger.Inputs.Menus
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetCancelDown")]
    public static class Cancel
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Cancel && !TASsenger.Previous.Cancel;
                return false;
            }
            return true;
        }
    }
}
