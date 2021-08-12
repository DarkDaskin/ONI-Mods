using System.Diagnostics.CodeAnalysis;
using HarmonyLib;

namespace OxygenNotIncluded.PerPlanetoidMaterials
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [HarmonyPatch(typeof(MaterialSelectorSerializer), nameof(MaterialSelectorSerializer.GetPreviousElement))]
    public class Patch_MaterialSelectorSerializer_GetPreviousElement
    {
        public static void Postfix(ref Tag __result, int selectorIndex, Tag recipe)
        {
            if (ModState.Instance.TryGetPreviousElement(selectorIndex, recipe, out var element))
                __result = element;
        }
    }

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [HarmonyPatch(typeof(MaterialSelectorSerializer), nameof(MaterialSelectorSerializer.SetSelectedElement))]
    public class Patch_MaterialSelectorSerializer_SetSelectedElement
    {
        public static void Postfix(int selectorIndex, Tag recipe, Tag element)
        {
            ModState.Instance.SetSelectedElement(selectorIndex, recipe, element);
        }
    }
}