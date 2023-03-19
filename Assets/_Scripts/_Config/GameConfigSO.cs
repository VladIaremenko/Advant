using UnityEngine;

namespace Sagra.Assets._Scripts._Config
{
    [CreateAssetMenu(fileName = "GameConfigSO", menuName = "SO/Game/GameConfigSO", order = 1)]
    public class GameConfigSO : ScriptableObject
    {
        [HideInInspector] public float TimeElapsed;

        [Range(0.1f,10)]
        public float BackgroundScrollSpeed;
    }
}


