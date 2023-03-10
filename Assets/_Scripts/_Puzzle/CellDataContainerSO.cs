using UnityEngine;

namespace Assets._Scripts._Puzzle
{
    [CreateAssetMenu(fileName = "CellDataContainerSO", menuName = "SO/ECS/CellDataContainerSO", order = 1)]
    public class CellDataContainerSO : ScriptableObject
    {
        public Sprite DefaultSprite;
        public Sprite SelectedSprite;
        public Sprite DeadSprite;
    }
}


