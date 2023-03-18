using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;

namespace Sagra.Assets._Scripts._General
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<TranfsormComponent, PlayerControlledComponent>> _movingUnits = default;

        public void Run(IEcsSystems systems)
        {
            
        }
    }
}


