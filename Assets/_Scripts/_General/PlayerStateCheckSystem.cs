using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using Sagra.Assets._Scripts._Config;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerStateCheckSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<PlayerControlledComponent>> _playerUnits = default;
        readonly EcsPoolInject<UnitStateComponent> _unitStates = default;
        readonly EcsCustomInject<GameConfigSO> _config = default;

        public void Run(IEcsSystems systems)
        {
            if (_config.Value.GameIsOver)
            {
                _config.Value.TimeAfterReloadCount += Time.deltaTime;

                if(_config.Value.TimeAfterReloadCount >= _config.Value.TimeBeforeReload)
                {
                    SceneManager.LoadScene(0);
                }

                return;
            }

            foreach (var entity in _playerUnits.Value)
            {
                ref var unit = ref _unitStates.Value.Get(entity);

                if (unit.IsDead)
                {
                    _config.Value.GameIsOver = true;
                    return;
                }
            }
        }
    }
}


