using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._Misc;
using Sagra.Assets._Scripts._UserData;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class UpdateIncomeTimerSystem : IEcsRunSystem
    {
        private StorageSO _storageSO;
        private int _ticks;
        private const int _ticksToReset = 30;

        public UpdateIncomeTimerSystem(StorageSO storageSO)
        {
            _storageSO = storageSO;
        }

        public void Run(IEcsSystems systems)
        {
            _ticks++;

            var world = systems.GetWorld();
            var filter = world.Filter<BuisnessStateStruct>().End();
            var allData = world.GetPool<BuisnessStateStruct>();
            var viewsToUpdatePool = world.GetPool<ViewsToUpdate>();

            var filterBalance = world.Filter<BalanceStateStruct>().End();
            var allDataBalance = world.GetPool<BalanceStateStruct>();

            foreach (var entity in filter)
            {
                ref var data = ref allData.Get(entity);

                if (data.CurrentLevel <= 0)
                {
                    continue;
                }

                data.CurrentIncomeProgress += Time.fixedDeltaTime;

                //Save income progress every 30 frames
                if (_ticks >= _ticksToReset)
                {
                    _storageSO.UserDataContainer.BuisnesStates[data.Id].IncomeProgress = data.CurrentIncomeProgress;
                }

                if (data.CurrentIncomeProgress >= data.IncomeDelay)
                {
                    data.CurrentIncomeProgress = 0;

                    foreach (var entityBalance in filterBalance)
                    {
                        ref var dataBalance = ref allDataBalance.Get(entityBalance);

                        dataBalance.BalanceAmount += BuisnessCalculator
                        .CalculateIncome(data.CurrentLevel, data.BasicIncome,
                        data.Upgrade1Data.IsBought ? data.Upgrade1Data.IncomeMultiplier : 0,
                        data.Upgrade2Data.IsBought ? data.Upgrade2Data.IncomeMultiplier : 0);

                        _storageSO.Balance = dataBalance.BalanceAmount;

                        if (!viewsToUpdatePool.Has(entityBalance))
                        {
                            viewsToUpdatePool.Add(entityBalance);
                        }
                    }
                }
            }

            //Save income progress every 30 frames
            if (_ticks >= _ticksToReset)
            {
                _storageSO.UserDataContainer = _storageSO.UserDataContainer;
                _ticks = 0;
            }
        }
    }
}


