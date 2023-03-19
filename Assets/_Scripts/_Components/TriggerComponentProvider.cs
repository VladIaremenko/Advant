using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Misc;
using UnityEngine;

namespace Sagra.Assets._Scripts._Components
{
    public class TriggerComponentProvider : MonoBehaviour, IConvertToEntity
    {
        private int _entity;
        private EcsWorld _world;

        public virtual void Convert(int entity, EcsWorld world)
        {
            _entity = entity;
            _world = world;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var pool = _world.GetPool<TriggerComponent>();
            pool.Add(_entity);

            ref var component = ref pool.Get(_entity);
            component.first = gameObject;
            component.other = collision.gameObject;
        }
    }

    public struct TriggerComponent
    {
        public GameObject first;
        public GameObject other;
    }
}


