using System;
using TaleWorlds.Core;
using TaleWorlds.Library;
using BetterCombat.Settings;
using TaleWorlds.InputSystem;

namespace BetterCombat.Utils {
    public class Helper {
        public static string modName = "ForgotToSet";
        public static ISettings settings;
        public static InputKey bandageKey = InputKey.Q;

        public static void SetModName(string name) {
            modName = name;
            DisplayFriendlyMsg(modName + " Loaded.");
        }

        public static void RegisterBandageKey() {
            try {
                if (Enum.IsDefined(typeof(InputKey), settings.BandageKey)) {
                    bandageKey = (InputKey)Enum.Parse(typeof(InputKey), settings.BandageKey);
                    //DisplayWarningMsg("Key: " + settings.CallKey);
                } else {
                    throw new Exception();
                }
            } catch (Exception e) {
                DisplayWarningMsg("Issue registering bandage key. '" + settings.BandageKey + "' is not a valid key. Using deafult 'Q' key.");
                Helper.WriteToLog("register key exception: " + e);
            }
        }

        public static void DisplayFriendlyMsg(string msg) {
            InformationManager.DisplayMessage(new InformationMessage(msg, Colors.Green));
            WriteToLog(msg);
        }

        public static void DisplayMsg(string msg) {
            InformationManager.DisplayMessage(new InformationMessage(msg));
            WriteToLog(msg);
        }

        public static void DisplayWarningMsg(string msg) {
            InformationManager.DisplayMessage(new InformationMessage(msg, Colors.Red));
            WriteToLog(msg);
        }

        public static void WriteToLog(string text) {
            Debug.Print(modName + ": " + text);
        }
    }
}