using HarmonyLib;
using UnityEngine;

namespace TownOfUs
{
    //[HarmonyPriority(Priority.VeryHigh)] // to show this message first, or be overrided if any plugins do
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingTracker_Update
    {

        [HarmonyPostfix]
        public static void Postfix(PingTracker __instance)
        {
            var position = __instance.GetComponent<AspectPosition>();
            position.DistanceFromEdge = new Vector3(3.1f, 0.1f, 0);
            position.AdjustPosition();

            __instance.text.text =
                "<color=#00FF00FF>TownOfUs v2.4.0</color>\n" +
               __instance.text.text + 
                (!MeetingHud.Instance
                    ? "\n<color=#00FF00FF>Slushiegoose & Polus.gg</color>\n" + "<color=#00FF00FF>Donners ft. Guus</color>"
                    : "");
        }
    }
}
