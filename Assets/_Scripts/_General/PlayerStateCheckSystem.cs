using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerStateCheckSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<PlayerControlledComponent>> _playerUnits = default;
        readonly EcsPoolInject<UnitStateComponent> _unitStates = default;

        private bool _gameIsOver = false;
        private float _timeAfterReloadCount = 0;
        private float _timeBeforeReload = 3;

        public void Run(IEcsSystems systems)
        {
            if (_gameIsOver)
            {
                _timeAfterReloadCount += Time.deltaTime;

                if(_timeAfterReloadCount >= _timeBeforeReload)
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
                    _gameIsOver = true;
                    return;
                }
            }
        }
    }
}


