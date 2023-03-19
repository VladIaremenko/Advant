using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;

namespace Sagra.Assets._Scripts._General
{
    public class ObstaclesCollisionSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<TriggerComponent>> _triggers = default;
        readonly EcsPoolInject<UnitStateComponent> _states = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _triggers.Value)
            {
                ref var item = ref _triggers.Pools.Inc1.Get(entity);
                ref var state = ref _states.Value.Get(entity);
                item.other.gameObject.SetActive(false);
                state.IsDead = true;
            }
        }
    }
}


