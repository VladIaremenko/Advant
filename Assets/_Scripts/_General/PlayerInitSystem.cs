using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        readonly EcsFilterInject<Inc<PlayerControlledComponent>> _playerUnits = default;
        readonly EcsPoolInject<UnitStateComponent> _unitStates = default;

        public void Init(IEcsSystems systems)
        {
            foreach (var entity in _playerUnits.Value)
            {
                ref var unit = ref _unitStates.Value.Add(entity);

                unit.CurrentPositionIndex = 1;
            }
        }
    }
}


