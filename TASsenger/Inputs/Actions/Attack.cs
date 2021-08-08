using HarmonyLib;

namespace TASsenger.Inputs.Combat
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetAttack")]
    public static class Attack
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Attack;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetAttackDown")]
    public static class AttackDown
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = TASsenger.Current.Attack && !TASsenger.Previous.Attack;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("GetAttackUp")]
    public static class AttackUp
    {
        public static bool Prefix(ref bool __result, InputManager __instance)
        {
            if (TASsenger.Playing)
            {
                if (__instance.blockAllInputs) return __result = false;
                __result = !TASsenger.Current.Attack && TASsenger.Previous.Attack;
                return false;
            }
            return true;
        }
    }
}
