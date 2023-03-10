using System;
using UnityEngine;

namespace Assets._Scripts._Puzzle
{
    [CreateAssetMenu(fileName = "PuzzleViewModel", menuName = "SO/Puzzle/PuzzleViewModel", order = 1)]
    public class PuzzleViewModel : ScriptableObject
    {
        public event Action<Vector2Int> ItemClickedEvent = new((x) => { });
        public event Action SendSelectedItemsToDeleteSystemEvent = new(() => { });

        public void HandleSelectItem(Vector2Int pos)
        {
            ItemClickedEvent.Invoke(pos);
        }

        public void SendSelectedItemsToDeleteSystem()
        {
            SendSelectedItemsToDeleteSystemEvent.Invoke();
        }   
    }
}


