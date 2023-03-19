using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Config;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class InitCameraSystem : IEcsInitSystem
    {
        readonly EcsCustomInject<Camera> _camera = default;
        readonly EcsCustomInject<GameConfigSO> _config = default;

        public void Init(IEcsSystems systems)
        {
            float unitsPerPixel = _config.Value.SceneWidth / Screen.width;

            float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

            _camera.Value.orthographicSize = desiredHalfHeight;
        }
    }
}


