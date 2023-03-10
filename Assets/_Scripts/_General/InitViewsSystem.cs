using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._Misc;
using Sagra.Assets._Scripts._UI;
using System.Collections.Generic;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class InitViewsSystem : IEcsInitSystem
    {
        private List<BuisnessItemView> _views;

        public InitViewsSystem(List<BuisnessItemView> views)
        {
            _views = views;
        }

        public void Init(IEcsSystems systems)
        {
            foreach (var view in _views)
            {
                var playerEntity = systems.GetWorld().NewEntity();
                ref var cellData = ref systems.GetWorld().GetPool<BuisnessStateStruct>().Add(playerEntity);

                cellData.View = view;
            }
        }
    }
}


