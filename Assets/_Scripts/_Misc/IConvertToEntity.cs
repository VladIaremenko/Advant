using Leopotam.EcsLite;
using UnityEngine;

namespace Sagra.Assets._Scripts._Misc
{
    public interface IConvertToEntity
    {
        public void Convert(int entity, EcsWorld world);
    }
}


