using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using Sagra.Assets._Scripts._Config;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class BackgroundSystem : IEcsInitSystem, IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<SpriteRendererComponent>> _units = default;
        readonly EcsCustomInject<GameConfigSO> _config = default;

        public void Init(IEcsSystems systems)
        {
            _config.Value.TimeElapsed = 0;

            foreach (var entity in _units.Value)
            {
                ref var unit = ref _units.Pools.Inc1.Get(entity);

                unit.SpriteRenderer.material.SetTextureOffset(_config.Value.ParameterName,
                    new Vector2(0, 0));
            }
        }

        public void Run(IEcsSystems systems)
        {
            _config.Value.TimeElapsed += Time.deltaTime;

            foreach (var entity in _units.Value)
            {
                ref var unit = ref _units.Pools.Inc1.Get(entity);

                unit.SpriteRenderer.material.SetTextureOffset(_config.Value.ParameterName,
                    new Vector2(0, _config.Value.TimeElapsed * _config.Value.BackgroundScrollSpeed / 100));
            }
        }
    }
}
