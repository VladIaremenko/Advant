using Leopotam.Ecs;
using UnityEngine;

namespace Sagra.Assets._Scripts._Misc
{
    public abstract class MonoProvider<T> : MonoBehaviour, IConvertToEntity where T : struct
    {
        [SerializeField] protected T value;

        public void Convert(EcsEntity entity)
        {
            entity.Replace(value);
        }
    }
}