using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using Sagra.Assets._Scripts._Components;
using Sagra.Assets._Scripts._Config;
using Sagra.Assets._Scripts._Misc;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class AppInitializer : MonoBehaviour
    {
        [SerializeField] private ObstaclesSpawnerSO _spawnerSO;
        [SerializeField] private Transform _obstaclesParent;

        private EcsSystems _systems;
        private EcsWorld _world;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            WorldHolder.EcsWorld = _world;
            _spawnerSO.Init(_obstaclesParent);

            GameBus.ConverEntitiesEvent.Invoke();

            _systems
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Add(new BackgroundSystem())
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerMovementSystem())
                .Add(new ObstaclesSpawnSystem())
                .Add(new ObstaclesMovingSystem())
                .Add(new ObstaclesCollisionSystem())
                .DelHere<TriggerComponent>()
                .Inject(_spawnerSO)
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



