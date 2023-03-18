using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._Fly._Components;
using Unity.Burst.CompilerServices;
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
            world.GetPool<T>().Add(entity);

            ref var hitComponent = ref pool.Get(entity);
            hitComponent = value;
        }
    }
}