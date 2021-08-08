using HarmonyLib;

namespace TASsenger.Inputs.Menus
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetConfirm")]
    public static class Confirm
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Confirm && !TASsenger.Previous.Confirm;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetConfirmDown")]
    public static class ConfirmDown
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Confirm && !TASsenger.Previous.Confirm;
                return false;
            }
            return true;
        }
    }
}
