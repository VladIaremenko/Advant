using Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using System.Collections.Generic;
using UnityEngine;

namespace Coin.Assets._Scripts._Puzzle
{
    public class Initializer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private PuzzleViewModel _puzzleViewModel;
        [SerializeField] private ConfigurationSO _configuration;
        [SerializeField] private CellDataHolderSO _cellDataHolder;
        [SerializeField] private List<PuzzleCellView> _cellViews;

        private EcsSystems _systems;
        private EcsWorld _ecsWorld;

        void Start()
        {
            SetUpCells();

            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);

            _configuration.EcsWorld = _ecsWorld;

            var sis = new PuzzleStateService();

            _systems
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Add(new PuzzleCellsInitSystem())
                .Add(new PuzzleInputSystem())
                .Add(new PuzzleDrawAttackPathSystem())
                .Add(new PuzzleAnimateDeathSystem())
                .Add(new PuzzleHandleDeletedSelectedCellsSystem())
                .Add(new AnimateDeletedCellsSystem())
                .Add(new UpdateCellViewsSystem())

                .Inject(_cellViews, _puzzleViewModel, sis, _lineRenderer, _cellDataHolder)
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            _systems?.Destroy();
            _systems?.GetWorld()?.Destroy();
            _systems = null;
        }

        [ContextMenu("SetupCells")]
        public void SetUpCells()
        {
            for (int i = 0; i < _cellViews.Count; i++)
            {
                var vec = new Vector2Int(i % _configuration.GridWidth, i / _configuration.Gridheight);
                _cellViews[i].SetPosition(vec);
                _cellViews[i].SeText(vec.ToString());
            }
        }
    }
}

