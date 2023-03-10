using Coin.Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Scripts._Puzzle
{
    public class PuzzleHandleDeletedSelectedCellsSystem : IEcsRunSystem, IEcsInitSystem
    {
        readonly EcsPoolInject<DeletedCells> _deletedCellsPool = default;
        readonly EcsFilterInject<Inc<CellData, DeletedCells>> _deletedUnits = default;
        readonly EcsFilterInject<Inc<CellData>> _allUnits = default;
        readonly EcsCustomInject<PuzzleStateService> _puzzleStateService;

        public void Init(IEcsSystems systems)
        {

        }

        public void Run(IEcsSystems systems)
        {
            HandlePuzzleRun();
        }

        private void HandlePuzzleRun()
        {
            if (_puzzleStateService.Value.PuzzleState != PuzzleState.CalculatigMove) 
            {
                return;
            }

            InitStartPositions();

            while (!TryComletePuzzle())
            {
      
            }

            _puzzleStateService.Value.PuzzleState = PuzzleState.AnimatingMove;
        }

        public void InitStartPositions()
        {
            foreach (var unitID in _allUnits.Value)
            {
                ref var unit = ref _allUnits.Pools.Inc1.Get(unitID);

                unit.AnimateStartPosition = unit.CellView.Content.position;
            }
        }

        private bool TryComletePuzzle()
        {
            foreach (var deleteUnitId in _deletedUnits.Value)
            {
                ref var deletedUnit = ref _deletedUnits.Pools.Inc1.Get(deleteUnitId);

                deletedUnit.IsSelected = false;

                if (deletedUnit.Position.y > 0)
                {
                    foreach (var unitID in _allUnits.Value)
                    {
                        ref var unit = ref _allUnits.Pools.Inc1.Get(unitID);

                        if (unit.Position.Equals(deletedUnit.Position + Vector2Int.down))
                        {
                            var delIndex = deletedUnit.CellView.transform.GetSiblingIndex();
                            var unitIndex = unit.CellView.transform.GetSiblingIndex();

                            var delPos = deletedUnit.Position;
                            var unitPos = unit.Position;

                            unit.Position = delPos;
                            deletedUnit.Position = unitPos;

                            deletedUnit.CellView.transform.SetSiblingIndex(unitIndex);
                            unit.CellView.transform.SetSiblingIndex(delIndex);

                            deletedUnit.CellView.SetPosition(deletedUnit.Position);
                            unit.CellView.SetPosition(unit.Position);

                            deletedUnit.ViewChanged = true;
                            unit.ViewChanged = true;

                            return false;
                        }
                    }
                }
                else
                {
                    _deletedCellsPool.Value.Del(deleteUnitId);
                    deletedUnit.CellType = PuzzleExtenstions.GetRandomStandartCell();
                    deletedUnit.ViewChanged = true;

                    return false;
                }
            }

            return true;
        }
    }
}


