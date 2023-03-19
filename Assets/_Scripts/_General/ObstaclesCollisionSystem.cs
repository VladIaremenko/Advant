using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class ObstaclesCollisionSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<TriggerComponent>> _triggers = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _triggers.Value)
            {
                ref var item = ref _triggers.Pools.Inc1.Get(entity);
                item.other.gameObject.SetActive(false);
            }
        }
    }
}


