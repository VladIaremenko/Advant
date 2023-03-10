using Assets._Scripts._Puzzle;
using UnityEngine;

namespace Coin.Assets._Scripts._Puzzle
{
    public struct CellData
    {
        public Vector2Int Position;
        public PuzzleCellView CellView;
        public CellType CellType;
        public bool IsSelected;
        public bool ViewChanged;
        public bool IsDeleted;
        public bool IsDead;

        public Vector3 AnimateStartPosition;
        public Vector3 AnimateEndPosition;
    }
}


