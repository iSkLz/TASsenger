using System;
using System.Collections.Generic;
using HarmonyLib;

namespace TASsenger
{
    [HarmonyPatch(typeof(BreakableCollision))]
    [HarmonyPatch("OnEnterRoom")]
    public class BreakablePatch
    {
        public static void Prefix(BreakableCollision __instance)
        {
            __instance.repairOnEnterRoom = true;
        }
    }
}
