using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Fly._Components;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<TranfsormComponent>> _movingUnits = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _movingUnits.Value)
            {
                ref var unit = ref _movingUnits.Pools.Inc1.Get(entity);

                unit.Transform.position += Vector3.up * Time.deltaTime * 5;
            }
        }
    }
}


