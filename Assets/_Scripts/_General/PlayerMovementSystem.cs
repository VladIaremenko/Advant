using DG.Tweening;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using Sagra.Assets._Scripts._Config;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<PlayerControlledComponent, InputCommandComponent>> _movingUnits = default;

        readonly EcsPoolInject<UnitStateComponent> _unitStatePool = default;
        readonly EcsPoolInject<InputCommandComponent> _commandPool = default;
        readonly EcsPoolInject<TranformAnchorsHolderComponent> _anchorsPool = default;
        readonly EcsPoolInject<TranfsormComponent> _transformPool = default;
        readonly EcsCustomInject<GameConfigSO> _config = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _movingUnits.Value)
            {
                ref var tranfsorm = ref _transformPool.Value.Get(entity);
                ref var command = ref _commandPool.Value.Get(entity);
                ref var anchors = ref _anchorsPool.Value.Get(entity);
                ref var state = ref _unitStatePool.Value.Get(entity);

                state.NextPositionIndex = Mathf.Clamp(state.CurrentPositionIndex + command.Direction, 0, anchors.Anchors.Length - 1);

                if (state.NextPositionIndex != state.CurrentPositionIndex)
                {
                    state.CurrentPositionIndex = state.NextPositionIndex;

                    tranfsorm.Transform.DOKill();
                    tranfsorm.Transform.DOMove(anchors.Anchors[state.NextPositionIndex].position, _config.Value.PlayerChangeLaneTime);
                }

                _commandPool.Value.Del(entity);
            }
        }
    }
}


