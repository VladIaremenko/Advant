using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<TranfsormComponent, InputCommandComponent, PlayerControlledComponent>> _movingUnits = default;
        readonly EcsPoolInject<InputCommandComponent> _commandPool = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _movingUnits.Value)
            {
                ref var tranfsorm = ref _movingUnits.Pools.Inc1.Get(entity);
                ref var command = ref _movingUnits.Pools.Inc2.Get(entity);

                HandleMoveDirection(command.Direction, tranfsorm.Transform);

                _movingUnits.Pools.Inc2.Del(entity);
            }
        }

        private void HandleMoveDirection(Vector3 direction, Transform transform)
        {
            throw new NotImplementedException();
        }
    }
}


