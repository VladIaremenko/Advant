using Coin.Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts._Puzzle
{
    public class AnimateDeletedCellsSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<CellData>> _allUnits = default;
        readonly EcsCustomInject<PuzzleStateService> _puzzleStateService;
        readonly EcsCustomInject<CellDataHolderSO> _cellDataHolderSO = default;

        private bool _wait;

        public void Run(IEcsSystems systems)
        {
            if(_puzzleStateService.Value.PuzzleState != PuzzleState.AnimatingMove)
            {
                return;
            }

            _wait = !_wait;

            if (_wait)
            {
                return;
            }

            foreach (var id in _allUnits.Value)
            {
                ref var animateItem = ref _allUnits.Pools.Inc1.Get(id);

                if (animateItem.ViewChanged)
                {
                    animateItem.CellView
                        .SetIcon(_cellDataHolderSO.Value
                        .GetDefaultStateIcon(animateItem.CellType));

                    animateItem.ViewChanged = false;
  
                    var startPos = animateItem.CellView.Content.position;

                    if (animateItem.IsDeleted)
                    {
                        animateItem.IsDeleted = false;
                        continue;
                    }

                    animateItem.CellView.Content.position = animateItem.AnimateStartPosition;


                    animateItem.IsDeleted = false;
                }
            }

            _puzzleStateService.Value.PuzzleState = PuzzleState.Default;
        }
    }
}


