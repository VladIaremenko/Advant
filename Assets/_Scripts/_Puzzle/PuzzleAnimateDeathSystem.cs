using Coin.Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Assets._Scripts._Puzzle
{
    public class PuzzleAnimateDeathSystem : IEcsRunSystem
    {
        readonly EcsPoolInject<DeletedCells> _deletedCellsPool = default;
        readonly EcsFilterInject<Inc<CellData, DeletedCells>> _deletedUnits = default;
        readonly EcsFilterInject<Inc<CellData>> _allUnits = default;
        readonly EcsCustomInject<PuzzleStateService> _puzzleStateService;
        readonly EcsCustomInject<CellDataHolderSO> _cellDataHolderSO = default;
        readonly EcsCustomInject<MonoBehaviour> _mono = default;


        public void Run(IEcsSystems systems)
        {
            if (_puzzleStateService.Value.PuzzleState != PuzzleState.AnimatingDeath)
            {
                return;
            }

            _puzzleStateService.Value.PuzzleState = PuzzleState.Default;

            foreach (var cell in _puzzleStateService.Value._selectedCells)
            {
                foreach (var deleteUnitId in _deletedUnits.Value)
                {
                    ref var deletedUnit = ref _deletedUnits.Pools.Inc1.Get(deleteUnitId);

                    if(cell.Position == deletedUnit.Position)
                    {
                        deletedUnit.IsDead = true;
                    }
                }
            }

            _puzzleStateService.Value._selectedCells.Clear();
        }
    }
}


