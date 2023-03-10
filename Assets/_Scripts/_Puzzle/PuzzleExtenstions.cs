using UnityEngine;

namespace Assets._Scripts._Puzzle
{
    public static class PuzzleExtenstions
    {
        public static CellType GetRandomStandartCell()
        {
            return (CellType)Random.Range(0, 4); ;
        }
    }

    public enum CellType
    {
        Orange,
        Green,
        Red,
        Yellow,
        Diamond,
        Blocked
    }
}


