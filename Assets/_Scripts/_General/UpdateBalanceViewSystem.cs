using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._Misc;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class UpdateBalanceViewSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<BalanceStateStruct>().Inc<ViewsToUpdate>().End();
            var allData = world.GetPool<BalanceStateStruct>();
            var viewsToUpdatePool = world.GetPool<ViewsToUpdate>();

            foreach (var entity in filter)
            {
                ref var data = ref allData.Get(entity);

                data.BalanceText.text = $"Balance: {data.BalanceAmount}$";

                viewsToUpdatePool.Del(entity);
            }
        }
    }
}


