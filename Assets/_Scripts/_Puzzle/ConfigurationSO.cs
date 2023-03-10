using Leopotam.EcsLite;
using UnityEngine;

namespace Coin.Assets._Scripts._Puzzle
{
    [CreateAssetMenu(fileName = "ConfigurationSO", menuName = "SO/ECS/ConfigurationSO", order = 1)]
    public class ConfigurationSO : ScriptableObject
    {
        public int GridWidth;
        public int Gridheight;
        public EcsWorld EcsWorld;
    }
}


