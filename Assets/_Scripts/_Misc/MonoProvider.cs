using Leopotam.EcsLite;
using UnityEngine;

namespace Sagra.Assets._Scripts._Misc
{
    [RequireComponent(typeof(EntityHolder))]
    public abstract class MonoProvider<T> : MonoBehaviour, IConvertToEntity where T : struct
    {
        [SerializeField] protected T value;

        public virtual void Convert(int entity, EcsWorld world)
        {
            var pool = world.GetPool<T>();
            pool.Add(entity);

            ref var component = ref pool.Get(entity);
            component = value;
        }
    }
}