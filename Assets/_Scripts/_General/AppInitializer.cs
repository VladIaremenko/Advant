using Assets._Scripts._Puzzle;
using Coin.Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Sagra.Assets._Scripts._UI;
using System.Collections.Generic;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class AppInitializer : MonoBehaviour
    {
        [SerializeField] private List<BuisnessItemView> _itemsViews;

        private EcsSystems _systems;
        private EcsWorld _ecsWorld;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        void Start()
        {
            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);

            _systems
                .Add(new InitViewsSystem(_itemsViews))
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
    }
}


