using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        readonly EcsPoolInject<InputCommandComponent> _commandPool = default;
        readonly EcsFilterInject<Inc<TranfsormComponent, PlayerControlledComponent>> _movingUnits = default;

        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private float _startTime;
        private float _endTime;

        private float _swipeTimeTreshold = 1f;
        private float _swipeDistanceTreshold = 0.2f;

        public void Run(IEcsSystems systems)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startTime = Time.time;
                _startPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _endTime = Time.time;
                _endPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                if (_endTime - _startTime >= _swipeTimeTreshold
                || Vector2.Distance(_startPosition, _endPosition) <= _swipeDistanceTreshold)
                {
                    return;
                }

                foreach (var entity in _movingUnits.Value)
                {
                    _commandPool.Value.Add(entity);

                    ref var component = ref _commandPool.Value.Get(entity);
                    component.Direction = (_startPosition - _endPosition).normalized;
                }
            }
        }
    }
}


