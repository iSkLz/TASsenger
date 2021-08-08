using HarmonyLib;

namespace TASsenger.Inputs.Menus
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetInventoryDown")]
    public static class Inventory
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Inventory && !TASsenger.Previous.Inventory;
                return false;
            }
            return true;
        }
    }
}
