using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._UserData;

namespace Sagra.Assets._Scripts._General
{
    public class InitBuisnessDataSystem : IEcsInitSystem
    {
        private StorageSO _storage;
        private BuisnessDataItemsHolder _dataHolder;

        public InitBuisnessDataSystem(StorageSO storage, BuisnessDataItemsHolder dataHolder)
        {
            _storage = storage;
            _dataHolder = dataHolder;
        }

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<BuisnessStateStruct>().End();
            var allData = world.GetPool<BuisnessStateStruct>();
            var viewsToUpdatePool = world.GetPool<ViewsToUpdate>();
            var _storageStates = _storage.UserDataContainer.BuisnesStates;

            int num = 0;

            foreach (var entity in filter)
            {
                ref var data = ref allData.Get(entity);

                viewsToUpdatePool.Add(entity);

                var soData = _dataHolder.BuisnessItems[num];

                data.Title = _dataHolder.TitlesHolderSO.Titles[num].BuisnessTitle;
                data.BasicIncome = soData.BasicIncome;
                data.BasicPrice = soData.BasicPrice;
                data.CurrentLevel = _storageStates[num].Level;
                data.IncomeDelay = _dataHolder.BuisnessItems[num].IncomeDelay;

                data.Upgrade1Data.IsBought = _storageStates[num].Upgrades[0];
                data.Upgrade2Data.IsBought = _storageStates[num].Upgrades[1];

                data.Upgrade1Data.Title = _dataHolder.TitlesHolderSO.Titles[num].Upgrade1Title;
                data.Upgrade2Data.Title = _dataHolder.TitlesHolderSO.Titles[num].Upgrade2Title;

                data.Upgrade1Data.Price = _dataHolder.BuisnessItems[num].Upgrade1.Price;
                data.Upgrade2Data.Price = _dataHolder.BuisnessItems[num].Upgrade2.Price;

                data.Upgrade1Data.IncomeMultiplier = _dataHolder.BuisnessItems[num].Upgrade1.IncomeIncrease;
                data.Upgrade2Data.IncomeMultiplier = _dataHolder.BuisnessItems[num].Upgrade2.IncomeIncrease;

                data.Id = num;
                data.View.ID = num;

                num++;
            }
        }
    }
}


