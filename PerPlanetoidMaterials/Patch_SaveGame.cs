using System.Diagnostics.CodeAnalysis;
using HarmonyLib;

namespace OxygenNotIncluded.PerPlanetoidMaterials
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [HarmonyPatch(typeof(SaveGame), "OnPrefabInit")]
    public class Patch_SaveGame
    {
        public static void Postfix(SaveGame __instance)
        {
            __instance.FindOrAdd<ModState>();
        }
    }
}