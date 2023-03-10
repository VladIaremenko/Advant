using Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System.Collections.Generic;
using UnityEngine;

namespace Coin.Assets._Scripts._Puzzle
{
    public class PuzzleCellsInitSystem : IEcsInitSystem
    {
        readonly EcsPoolInject<CellData> _unitPool = default;
        readonly EcsCustomInject<List<PuzzleCellView>> _cellViews = default;
        readonly EcsCustomInject<CellDataHolderSO> _cellDataHolderSO = default;

        public void Init(IEcsSystems systems)
        {
            foreach (PuzzleCellView cellView in _cellViews.Value)
            {
                var playerEntity = _unitPool.Value.GetWorld().NewEntity();
                ref var cellData = ref _unitPool.Value.Add(playerEntity);

                cellData.Position = cellView.Position;
                cellData.CellView = cellView;
                cellData.CellType = PuzzleExtenstions.GetRandomStandartCell();
                cellData.CellView.SetIcon(_cellDataHolderSO.Value.GetDefaultStateIcon(cellData.CellType));
            }
        }
    }
}


