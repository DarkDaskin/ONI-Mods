using System.Collections.Generic;
using KSerialization;

namespace OxygenNotIncluded.PerPlanetoidMaterials
{
    [SerializationConfig(MemberSerialization.OptIn)]
    public class ModState : KMonoBehaviour
    {
        [Serialize]
        private readonly Dictionary<MaterialSelectorKey, Tag> _selectedElements = new Dictionary<MaterialSelectorKey, Tag>();

        public static ModState Instance => SaveGame.Instance.FindOrAdd<ModState>();

        public bool TryGetPreviousElement(int selectorIndex, Tag recipe, out Tag element)
        {
            var key = GetKey(selectorIndex, recipe);
            return _selectedElements.TryGetValue(key, out element);
        }

        public void SetSelectedElement(int selectorIndex, Tag recipe, Tag element)
        {
            var key = GetKey(selectorIndex, recipe);
            _selectedElements[key] = element;
        }

        private static MaterialSelectorKey GetKey(int selectorIndex, Tag recipe)
        {
            var worldId = ClusterManager.Instance.activeWorldId;
            return new MaterialSelectorKey(worldId, recipe, selectorIndex);
        }
    }
}