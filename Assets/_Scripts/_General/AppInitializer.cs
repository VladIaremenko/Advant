using Assets._Scripts._Puzzle;
using Coin.Assets._Scripts._Puzzle;
using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._UI;
using Sagra.Assets._Scripts._UserData;
using System.Collections.Generic;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class AppInitializer : MonoBehaviour
    {
        [SerializeField] private BuisnessViewModel _buisnessViewModel;
        [SerializeField] private BuisnessDataItemsHolder _buisnessDataItemsHolder;
        [SerializeField] private StorageSO _storageSO;
        [SerializeField] private List<BuisnessItemView> _itemsViews;

        private EcsSystems _systems;
        private EcsWorld _ecsWorld;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        void Start()
        {
            _storageSO.Init();

            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);

            _systems
                .Add(new InitViewsSystem(_itemsViews))
                .Add(new InitDataSystem(_storageSO, _buisnessDataItemsHolder))
                .Add(new UpdateViewsSystem())
                .Add(new UserInputSystem(_buisnessViewModel))
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


