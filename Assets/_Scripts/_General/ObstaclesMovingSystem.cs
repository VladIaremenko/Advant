using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class ObstaclesMovingSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<TranfsormComponent>,Exc<PlayerControlledComponent>> _units = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                ref var unit = ref _units.Pools.Inc1.Get(entity);

                if (!unit.Transform.gameObject.activeInHierarchy)
                {
                    continue;
                }

                unit.Transform.position += Vector3.down * Time.deltaTime * 3;

                if(unit.Transform.position.y < -10)
                {
                    unit.Transform.gameObject.SetActive(false);
                }
            }
        }
    }
}


