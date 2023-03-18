using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<PlayerControlledComponent>> _movingUnits = default;

        readonly EcsPoolInject<UnitStateComponent> _unitStatePool = default;
        readonly EcsPoolInject<InputCommandComponent> _commandPool = default;
        readonly EcsPoolInject<TranformAnchorsHolderComponent> _anchorsPool = default;
        readonly EcsPoolInject<TranfsormComponent> _transformPool = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _movingUnits.Value)
            {
                ref var tranfsorm = ref _transformPool.Value.Get(entity);
                ref var command = ref _commandPool.Value.Get(entity);
                ref var anchors = ref _anchorsPool.Value.Get(entity);
                ref var state = ref _unitStatePool.Value.Get(entity);

                var newPosition = Mathf.Clamp(state.PositionIndex + command.Direction, 0, anchors.Anchors.Length);

                if(newPosition != state.PositionIndex)
                {

                }

                _commandPool.Value.Del(entity);
            }
        }

        private void HandleMoveDirection(ref Vector3 direction, ref TranformAnchorsHolderComponent anchors, Transform transform)
        {

        }
    }
}


