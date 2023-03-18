using Sagra.Assets._Scripts._Misc;
using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._Components
{
    public sealed class TranfsormComponentProvider : MonoProvider<TranfsormComponent>{}

    [Serializable]
    public struct TranfsormComponent
    {
        public Transform Transform;
    }
}


