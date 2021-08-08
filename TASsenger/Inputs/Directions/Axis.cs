using HarmonyLib;

namespace TASsenger.Inputs.Directions
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetHorizontalInput")]
    public static class Horizontal
    {
        public static bool Prefix(ref float __result, InputManager __instance,
            bool realInput,
            ref bool ___horizontalInputForced, ref float ___forcedHorizontalInput)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) __result = 0f;
                else if (___horizontalInputForced && !realInput) __result = ___forcedHorizontalInput;
                else __result = TASsenger.Current.Hor;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetVerticalInput")]
    public static class Vertical
    {
        public static bool Prefix(ref float __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) __result = 0f;
                else __result = TASsenger.Current.Ver;
                return false;
            }
            return true;
        }
    }
}
