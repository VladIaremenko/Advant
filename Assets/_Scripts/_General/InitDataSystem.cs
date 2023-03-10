﻿using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._UserData;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Sagra.Assets._Scripts._General
{
    public class InitDataSystem : IEcsInitSystem
    {
        private StorageSO _storage;
        private BuisnessDataItemsHolder _dataHolder;

        public InitDataSystem(StorageSO storage, BuisnessDataItemsHolder dataHolder)
        {
            _storage = storage;
            _dataHolder = dataHolder;
        }

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<BuisnessStateStruct>().End();
            var allData = world.GetPool<BuisnessStateStruct>();
            var states = _storage.UserDataContainer.BuisnesStates;

            int num = 0;

            foreach (var entity in filter)
            {
                ref var data = ref allData.Get(entity);
                var soData = _dataHolder.Items[num];

                data.Title = soData.Title;
                data.BasicIncome = soData.BasicIncome;
                data.BasicPrice = soData.BasicPrice;
                data.CurrentLevel = states[num].Level;

                num++;
            }
        }
    }
}

