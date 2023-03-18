using Sagra.Assets._Scripts._Misc;
using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._Components
{
    public class TranformAnchorsHolderComponentProvider : MonoProvider<TranformAnchorsHolderComponent>
    {
    }

    [Serializable]
    public struct TranformAnchorsHolderComponent
    {
        public Transform[] Anchors;
    }
}


