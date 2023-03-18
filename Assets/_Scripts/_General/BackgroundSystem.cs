using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class BackgroundSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<SpriteRendererComponent>> _units = default;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _units.Value)
            {
                ref var unit = ref _units.Pools.Inc1.Get(entity);

                unit.SpriteRenderer.material.SetTextureOffset("_MainTex", 
                    new Vector2(0, Time.time/100));
            }
        }
    }
}
