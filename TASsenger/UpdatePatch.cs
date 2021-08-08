using UnityEngine;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using UModFramework.API;

namespace TASsenger
{
    [HarmonyPatch(typeof(InputManager))]
    [HarmonyPatch("Update")]
    public static class UpdatePatch
    {
        public static string Filepath = Path.Combine(UMFData.GamePath, "MT.tas");

        public static void Prefix()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                TASsenger.Inputs = new List<Frame>(new Frame[]
                {
                    new Frame()
                });
                TASsenger.Position = 1;
                TASsenger.Playing = true;

                var file = File.ReadAllLines(Filepath);

                foreach (var sline in file)
                {
                    var fline = sline;
                    var count = 1;
                    var separate = false;
                    var line = fline.Replace(" ", "").Split(',');
                    if (line.Length == 0 || fline.StartsWith("#")) continue;
                    var frames = int.Parse(line[0]);

                    var frame = new Frame();

                    for (int i = 1; i < line.Length; i++)
                    {
                        var input = line[i];
                        if (input.StartsWith("*")) count = int.Parse(input.Substring(1));
                        if (input.StartsWith("+"))
                        {
                            count = int.Parse(input.Substring(1));
                            separate = true;
                        }

                        switch (input)
                        {
                            case "U":
                                frame.Up = true;
                                break;
                            case "L":
                                frame.Left = true;
                                break;
                            case "D":
                                frame.Down = true;
                                break;
                            case "R":
                                frame.Right = true;
                                break;
                            case "A":
                                frame.Attack = true;
                                break;
                            case "J":
                                frame.Jump = true;
                                break;
                            case "r":
                                frame.Rope = true;
                                break;
                            case "S":
                                frame.Shuriken = true;
                                break;
                            case "T":
                                frame.Tabi = true;
                                break;
                            case "s":
                                frame.Start = true;
                                break;
                            case "e":
                                frame.Interact = true;
                                break;
                            case "b":
                                frame.Back = true;
                                break;
                            case "c":
                                frame.Cancel = true;
                                break;
                            case "y":
                                frame.Confirm = true;
                                break;
                            case "i":
                                frame.Inventory = true;
                                break;
                            case "m":
                                frame.Map = true;
                                break;
                        }
                    }

                    while (count-- > 0)
                    {
                        while (frames-- > 0)
                        {
                            TASsenger.Inputs.Add(frame);
                            if (separate) TASsenger.Inputs.Add(new Frame());
                        }
                    }
                }
            }
            else if (TASsenger.Playing)
            {
                TASsenger.Position++;
                if (TASsenger.Position == TASsenger.Inputs.Count) TASsenger.Playing = false;
            }
        }
    }
}