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
            Debug.Log(123);

            foreach (var entity in _playerUnits.Value)
            {
                Debug.Log("JONO");
                Debug.Log(entity);

                ref var unit = ref _unitStates.Value.Add(entity);

                unit.PositionIndex = 0;
                unit.MovingState = MovingState.Idle;
            }
        }
    }
}


