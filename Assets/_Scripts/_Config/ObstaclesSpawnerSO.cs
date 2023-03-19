using Sagra.Assets._Scripts._Misc;
using System.Collections.Generic;
using UnityEngine;

namespace Sagra.Assets._Scripts._Config
{
    [CreateAssetMenu(fileName = "ObstaclesSpawnerSO", menuName = "SO/Obstacles/ObstaclesSpawnerSO", order = 1)]
    public class ObstaclesSpawnerSO : ScriptableObject
    {
        [HideInInspector]
        public float TimeSinceLastSpawn;
        [HideInInspector]
        public Transform ObstaclesParent;

        public List<EntityHolder> Items;

        [HideInInspector]
        public List<EntityHolder> CreatedItems;

        public void Init(Transform obstaclesParent)
        {
            CreatedItems = new List<EntityHolder>();
            ObstaclesParent = obstaclesParent;
        }
    }
}


