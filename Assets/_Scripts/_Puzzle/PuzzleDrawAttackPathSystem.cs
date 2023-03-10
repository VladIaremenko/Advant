using Coin.Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Assets._Scripts._Puzzle
{
    public class PuzzleDrawAttackPathSystem : IEcsRunSystem
    {
        readonly EcsPoolInject<DeletedCells> _deletedCellsPool = default;
        readonly EcsFilterInject<Inc<CellData, DeletedCells>> _deletedUnits = default;
        readonly EcsFilterInject<Inc<CellData>> _allUnits = default;
        readonly EcsCustomInject<PuzzleStateService> _puzzleStateService;
        readonly EcsCustomInject<LineRenderer> _lineRenderer;

        public void Run(IEcsSystems systems)
        {
            _lineRenderer.Value.positionCount = _puzzleStateService.Value._selectedCells.Count;

            if(_lineRenderer.Value.positionCount <= 0)
            {
                return;
            }

            float offset = Time.time * -1;

            _lineRenderer.Value.material
                .SetTextureOffset("_MainTex", new Vector2(offset, 0));

            for (int i = 0; i < _puzzleStateService.Value._selectedCells.Count; i++)
            {
                _lineRenderer.Value.
                    SetPosition(i, 
                    _puzzleStateService.Value._selectedCells[i]
                    .CellView.transform.position);
            }
        }
    }
}


