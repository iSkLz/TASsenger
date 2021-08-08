using UnityEngine;
using UModFramework.API;
using System;
using System.Linq;
using System.Collections.Generic;

namespace TASsenger
{
    [UMFHarmony(27)] //Set this to the number of harmony patches in your mod.
    [UMFScript]
    public class TASsenger : MonoBehaviour
    {
        public static List<Frame> Inputs;
        public static int Position = 1;
        public static bool Playing = false;
        public static Frame Current => Inputs[Position];
        public static Frame Previous => Inputs[Position - 1];

        internal static void Log(string text, bool clean = false)
        {
            using (UMFLog log = new UMFLog()) log.Log(text, clean);
        }

        [UMFConfig]
        public static void LoadConfig()
        {
            TASsengerConfig.Load();
        }

		void Awake()
		{
			Log("TASsenger v" + UMFMod.GetModVersion().ToString(), true);
		}

        void Update()
        {
        }
	}
}