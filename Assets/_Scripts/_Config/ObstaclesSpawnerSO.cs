using Sagra.Assets._Scripts._Misc;
using System.Collections.Generic;
using UnityEngine;

namespace Sagra.Assets._Scripts._Config
{
    [CreateAssetMenu(fileName = "ObstaclesSpawnerSO", menuName = "SO/Obstacles/ObstaclesSpawnerSO", order = 1)]
    public class ObstaclesSpawnerSO : ScriptableObject
    {
        [HideInInspector]
        public float TimeSinceLastSpaen;
        [HideInInspector]
        public Transform ObstaclesParent;

        public float TimeBetweenSpawns;
        public List<EntityHolder> Items;
    }
}


