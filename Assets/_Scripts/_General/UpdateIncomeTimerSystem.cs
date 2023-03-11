﻿using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._Misc;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class UpdateIncomeTimerSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<BuisnessStateStruct>().Inc<ViewsToUpdate>().End();
            var allData = world.GetPool<BuisnessStateStruct>();
            var viewsToUpdatePool = world.GetPool<ViewsToUpdate>();

            foreach (var entity in filter)
            {
                ref var data = ref allData.Get(entity);

                data.CurrentIncomeProgress += Time.fixedDeltaTime;
            }
        }
    }
}


