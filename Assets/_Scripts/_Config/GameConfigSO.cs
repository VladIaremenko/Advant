using UnityEngine;

namespace Sagra.Assets._Scripts._Config
{
    [CreateAssetMenu(fileName = "GameConfigSO", menuName = "SO/Game/GameConfigSO", order = 1)]
    public class GameConfigSO : ScriptableObject
    {
        public readonly string ParameterName = "_MainTex";

        [Range(0.1f, 10)]
        public float BackgroundScrollSpeed;
        [Range(-20, -5)]
        public float YBottomDistanceBeforeReset;
        [Range(0.1f, 10)]
        public float ObstacleSpeed;
        [Range(0.1f, 10)]
        public float PlayerChangeLaneTime;
        [Range(0.1f, 10)]
        public float TimeBeforeReload = 3;

        public bool CreateNewEntity { get; set; }

        public float TimeElapsed { get; set; }
        public Vector2 StartPosition { get; set; }
        public Vector2 EndPosition { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
        public float SwipeTimeTreshold { get; set; } = 1f;
        public float SwipeDistanceTreshold { get; set; } = 0.2f;
        public bool GameIsOver { get; set; } = false;
        public float TimeAfterReloadCount { get; set; } = 0;
    }
}


