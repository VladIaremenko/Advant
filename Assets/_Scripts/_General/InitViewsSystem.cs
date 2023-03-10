using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._Misc;
using Sagra.Assets._Scripts._UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Sagra.Assets._Scripts._General
{
    public class InitViewsSystem : IEcsInitSystem
    {
        private List<BuisnessItemView> _views;
        private TextMeshProUGUI _balanceText;

        public InitViewsSystem(List<BuisnessItemView> views, TextMeshProUGUI text)
        {
            _views = views;
            _balanceText = text;
        }

        public void Init(IEcsSystems systems)
        {
            foreach (var view in _views)
            {
                var entity = systems.GetWorld().NewEntity();
                ref var cellData = ref systems.GetWorld().GetPool<BuisnessStateStruct>().Add(entity);

                cellData.View = view;
            }

            var balanceEntity = systems.GetWorld().NewEntity();
            ref var balance = ref systems.GetWorld().GetPool<BalanceStateStruct>().Add(balanceEntity);
            balance.BalanceText = _balanceText;
        }
    }
}


