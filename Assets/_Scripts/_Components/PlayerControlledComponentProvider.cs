using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Misc;
using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._Components
{
    public sealed class PlayerControlledComponentProvider : MonoProvider<PlayerControlledComponent>
    {
        readonly EcsPoolInject<UnitStateComponent> _unitStates = default;
    }

    [Serializable]
    public struct PlayerControlledComponent
    {
    }
}


