using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class BackgroundSystem : IEcsInitSystem,IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<SpriteRendererComponent>> _units = default;

        private float _timeElapsed;

        public void Init(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                ref var unit = ref _units.Pools.Inc1.Get(entity);

                unit.SpriteRenderer.material.SetTextureOffset("_MainTex",
                    new Vector2(0, 0));
            }
        }

        public void Run(IEcsSystems systems)
        {
            _timeElapsed += Time.deltaTime;

            foreach (var entity in _units.Value)
            {
                ref var unit = ref _units.Pools.Inc1.Get(entity);

                unit.SpriteRenderer.material.SetTextureOffset("_MainTex", 
                    new Vector2(0, _timeElapsed/100));
            }
        }
    }
}
