namespace OxygenNotIncluded.PerPlanetoidMaterials
{
    public readonly struct MaterialSelectorKey
    {
        public readonly int WorldId;
        public readonly Tag Recipe;
        public readonly int SelectorIndex;

        public MaterialSelectorKey(int worldId, Tag recipe, int selectorIndex)
        {
            WorldId = worldId;
            Recipe = recipe;
            SelectorIndex = selectorIndex;
        }

        public override string ToString() => 
            $"{nameof(WorldId)}: {WorldId}, {nameof(Recipe)}: {Recipe}, {nameof(SelectorIndex)}: {SelectorIndex}";
    }
}