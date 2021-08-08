using HarmonyLib;

namespace TASsenger.Inputs.Menus
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetInteractDown")]
    public static class Interact
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Interact && !TASsenger.Previous.Interact;
                return false;
            }
            return true;
        }
    }
}
