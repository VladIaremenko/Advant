using Sagra.Assets._Scripts._Misc;
using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._Components
{
    public sealed class SpriteRendererComponentProvider : MonoProvider<SpriteRendererComponent> { }

    [Serializable]
    public struct SpriteRendererComponent
    {
        public SpriteRenderer SpriteRenderer;
    }
}
