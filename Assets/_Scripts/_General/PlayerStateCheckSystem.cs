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

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _playerUnits.Value)
            {
                ref var unit = ref _unitStates.Value.Get(entity);

                if (!unit.IsDead)
                {
                    return;
                }
            }

            SceneManager.LoadScene(0);
        }
    }
}


