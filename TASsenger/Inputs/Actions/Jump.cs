using HarmonyLib;

namespace TASsenger.Inputs.Combat
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetJump")]
    public static class Jump
    {
        public static bool Prefix(ref bool __result, InputManager __instance, bool overrideBlockedInput)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs && !overrideBlockedInput) return __result = false;
                __result = TASsenger.Current.Jump;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetJumpDown")]
    public static class JumpDown
    {
        public static bool Prefix(ref bool __result, InputManager __instance, bool overrideBlockedInput)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs && !overrideBlockedInput) return __result = false;
                __result = TASsenger.Current.Jump && !TASsenger.Previous.Jump;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetJumpUp")]
    public static class JumpUp
    {
        public static bool Prefix(ref bool __result, InputManager __instance, bool overrideBlockedInput)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs && !overrideBlockedInput) return __result = false;
                __result = !TASsenger.Current.Jump && TASsenger.Previous.Jump;
                return false;
            }
            return true;
        }
    }
}
