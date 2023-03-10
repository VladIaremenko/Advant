using Coin.Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Assets._Scripts._Puzzle
{
    public class UpdateCellViewsSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<CellData>> _units = default;
        readonly EcsFilterInject<Inc<DeletedCells>> _deletedCellsPool = default;
        readonly EcsCustomInject<CellDataHolderSO> _cellDataHolderSO = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var item in _units.Value)
            {
                ref var unit = ref _units.Pools.Inc1.Get(item);

                if (unit.IsDead)
                {
                    unit.CellView.SetIcon(_cellDataHolderSO.Value.GetDeadStateIcon(unit.CellType));
                    unit.CellView.HandleDefaultMode();
                    continue;
                }
                else if (unit.IsSelected)
                {
                    unit.CellView.HandleSelection();
                    unit.CellView.SetIcon(_cellDataHolderSO.Value.GetSelectedStateIcon(unit.CellType));
                }
                else
                {
                    unit.CellView.SetIcon(_cellDataHolderSO.Value.GetDefaultStateIcon(unit.CellType));
                    unit.CellView.HandleDefaultMode();
                }
            }
        }
    }
}


