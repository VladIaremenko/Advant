using Coin.Assets._Scripts._Puzzle;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts._Puzzle
{
    sealed class PuzzleStateService 
    {
        public List<CellData> _selectedCells = new();
        public PuzzleState PuzzleState;
    }

    public enum PuzzleState
    {
        Default,
        CalculatigMove,
        AnimatingDeath,
        AnimatingMove
    }
}


