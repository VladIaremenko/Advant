using System;
using UnityEngine;
using Voody.UniLeo;

namespace Sagra.Assets._Scripts._Fly._Components
{
    public sealed class TranfsormComponentProvider : MonoProvider<TranfsormComponent>{}

    [Serializable]
    public struct TranfsormComponent
    {
        public Transform Transform;
    }
}


