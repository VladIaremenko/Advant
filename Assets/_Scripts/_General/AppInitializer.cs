using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Misc;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class AppInitializer : MonoBehaviour
    {
        EcsSystems _systems;

        void Start()
        {
            var world = new EcsWorld();
            _systems = new EcsSystems(world);

            WorldHolder.EcsWorld = world;

            GameBus.ConverEntitiesEvent.Invoke();

            _systems
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerMovementSystem())
                .Inject()
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



