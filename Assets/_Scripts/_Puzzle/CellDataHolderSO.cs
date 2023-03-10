using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts._Puzzle
{
    [CreateAssetMenu(fileName = "CellDataHolderSO", menuName = "SO/ECS/CellDataHolderSO", order = 1)]
    public class CellDataHolderSO : ScriptableObject
    {
        [SerializeField] private List<CellDataContainerSO> _cellsData;

        public Sprite GetDefaultStateIcon(CellType cellType)
        {
            switch (cellType)
            {
                case CellType.Orange:
                    return _cellsData[0].DefaultSprite;
                case CellType.Green:
                    return _cellsData[1].DefaultSprite;
                case CellType.Red:
                    return _cellsData[2].DefaultSprite;
                case CellType.Yellow:
                    return _cellsData[3].DefaultSprite;
                default:
                    return _cellsData[0].DefaultSprite;
            }
        }

        public Sprite GetSelectedStateIcon(CellType cellType)
        {
            switch (cellType)
            {
                case CellType.Orange:
                    return _cellsData[0].SelectedSprite;
                case CellType.Green:
                    return _cellsData[1].SelectedSprite;
                case CellType.Red:
                    return _cellsData[2].SelectedSprite;
                case CellType.Yellow:
                    return _cellsData[3].SelectedSprite;
                default:
                    return _cellsData[0].SelectedSprite;
            }
        }

        public Sprite GetDeadStateIcon(CellType cellType)
        {
            switch (cellType)
            {
                case CellType.Orange:
                    return _cellsData[0].DeadSprite;
                case CellType.Green:
                    return _cellsData[1].DeadSprite;
                case CellType.Red:
                    return _cellsData[2].DeadSprite;
                case CellType.Yellow:
                    return _cellsData[3].DeadSprite;
                default:
                    return _cellsData[0].DeadSprite;
            }
        }
    }
}


