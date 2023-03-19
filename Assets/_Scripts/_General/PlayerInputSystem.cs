using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using Sagra.Assets._Scripts._Config;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        readonly EcsPoolInject<InputCommandComponent> _commandPool = default;
        readonly EcsFilterInject<Inc<TranfsormComponent, PlayerControlledComponent>> _movingUnits = default;
        readonly EcsCustomInject<GameConfigSO> _config = default;
        readonly EcsCustomInject<Camera> _camera = default;

        public void Run(IEcsSystems systems)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _config.Value.StartTime = Time.time;
                _config.Value.StartPosition = _camera.Value.ScreenToViewportPoint(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _config.Value.EndTime = Time.time;
                _config.Value.EndPosition = _camera.Value.ScreenToViewportPoint(Input.mousePosition);

                if (_config.Value.EndTime - _config.Value.StartTime >= _config.Value.SwipeTimeTreshold
                || Mathf.Abs(_config.Value.StartPosition.x - _config.Value.EndPosition.x) <= _config.Value.SwipeDistanceTreshold)
                {
                    return;
                }

                foreach (var entity in _movingUnits.Value)
                {
                    _commandPool.Value.Add(entity);

                    ref var component = ref _commandPool.Value.Get(entity);
                    component.Direction = (_config.Value.StartPosition.x - _config.Value.EndPosition.x) >= 0 ? -1 : 1;
                }
            }
        }
    }
}


