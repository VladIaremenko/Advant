using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Misc;
using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._Components
{
    public sealed class PlayerControlledComponentProvider : MonoProvider<PlayerControlledComponent>
    {
        public override void Convert(int entity, EcsWorld world)
        {
            Debug.Log("Gamer");
            base.Convert(entity, world);
        }
    }

    [Serializable]
    public struct PlayerControlledComponent
    {
    }
}


