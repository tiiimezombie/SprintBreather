using System.Collections.Generic;
using UnityEngine;

using GameNetcodeStuff;
using HarmonyLib;
using BepInEx.Logging;
using System.Linq;
using System;
using System.Collections;

namespace TZ.SprintBreather
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PatchedPlayerController
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void FasterSprintRegen(ref float ___sprintMeter, ref float ___sprintTime, ref bool ___isWalking, ref bool ___isJumping) //, ref bool ___isExhausted, ref bool ___isCrouching, ref bool ___isClimbingLadder
        {
            if (!___isWalking && !___isJumping)
                ___sprintMeter = Mathf.Clamp(___sprintMeter + Time.deltaTime / ___sprintTime, 0f, 1f);
        }
    }
}
