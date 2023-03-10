using Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Coin.Assets._Scripts._Puzzle
{
    public class PuzzleInputSystem : IEcsInitSystem
    {
        readonly EcsPoolInject<DeletedCells> _deletedCellsPool = default;
        readonly EcsFilterInject<Inc<CellData>> _units = default;

        readonly EcsCustomInject<PuzzleViewModel> _puzzleViewModel;
        readonly EcsCustomInject<PuzzleStateService> _puzzleStateService;

        public void Init(IEcsSystems systems)
        {
            _puzzleViewModel.Value.ItemClickedEvent += HandleClickEvent;
            _puzzleViewModel.Value.SendSelectedItemsToDeleteSystemEvent += HandleSelectionDeletion;
        }

        private void HandleSelectionDeletion()
        {
            if (_puzzleStateService.Value.PuzzleState != PuzzleState.Default)
            {
                return;
            }

            foreach (var item in _units.Value)
            {
                ref var unit = ref _units.Pools.Inc1.Get(item);

                if (unit.IsSelected)
                {
                    unit.IsDeleted = true;
                    _deletedCellsPool.Value.Add(item);
                }
            }

            _puzzleStateService.Value.PuzzleState = PuzzleState.AnimatingDeath;
        }

        private void HandleClickEvent(Vector2Int position)
        {
            if (_puzzleStateService.Value.PuzzleState != PuzzleState.Default)
            {
                return;
            }

            foreach (var item in _units.Value)
            {
                ref var unit = ref _units.Pools.Inc1.Get(item);

                if (position.Equals(unit.Position))
                {
                    if (_puzzleStateService.Value._selectedCells.Contains(unit))
                    {
                        break;
                    }

                    if (_puzzleStateService.Value._selectedCells.Count > 0)
                    {
                        var prevCell = _puzzleStateService.Value
                            ._selectedCells.Last();

                        if (Vector2Int.Distance(position, prevCell.Position) >= 1.5f)
                        {
                            ResetItemsList(ref unit);
                            break;
                        }

                        if (prevCell.CellType != unit.CellType)
                        {
                            ResetItemsList(ref unit);
                            break;
                        }
                    }

                    unit.IsSelected = true;
                    _puzzleStateService.Value._selectedCells.Add(unit);
                }
            }
        }

        private void ResetItemsList(ref CellData unit)
        {
            foreach (var item in _units.Value)
            {
                ref var unit1 = ref _units.Pools.Inc1.Get(item);
                unit1.IsSelected = false;
            }

            _puzzleStateService.Value._selectedCells.Clear();

            unit.IsSelected = true;
  
            _puzzleStateService.Value._selectedCells.Add(unit);
        }
    }
}


