using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._Misc;
using Sagra.Assets._Scripts._UserData;

namespace Sagra.Assets._Scripts._General
{
    public class UserInputSystem : IEcsInitSystem, IEcsDestroySystem
    {
        private BuisnessViewModel _buisnessViewModel;
        private IEcsSystems _systems;
        private StorageSO _storage;
        private BuisnessDataItemsHolder _buisnessDataItemsHolder;

        public UserInputSystem(BuisnessViewModel buisnessViewModel, StorageSO storage, BuisnessDataItemsHolder buisnessDataItemsHolder)
        {
            _buisnessViewModel = buisnessViewModel;
            _storage = storage;
            _buisnessDataItemsHolder = buisnessDataItemsHolder;
        }

        public void Init(IEcsSystems systems)
        {
            _systems = systems;
            _buisnessViewModel.OnLevelUpItemClick += HandleLevelUpItemClick;
            _buisnessViewModel.OnUpgradeUpItemClick += HandleUpgradeItemClick;
        }

        public void Destroy(IEcsSystems systems)
        {
            _buisnessViewModel.OnLevelUpItemClick -= HandleLevelUpItemClick;
            _buisnessViewModel.OnUpgradeUpItemClick -= HandleUpgradeItemClick;
        }

        private void HandleUpgradeItemClick(int itemID, int upgradeId)
        {
            var world = _systems.GetWorld();
            var filter = world.Filter<BuisnessStateStruct>().End();
            var allData = world.GetPool<BuisnessStateStruct>();
            var viewsToUpdatePool = world.GetPool<ViewsToUpdate>();
            var states = _storage.UserDataContainer.BuisnesStates;

            var filterBalance = world.Filter<BalanceStateStruct>().End();
            var allDataBalance = world.GetPool<BalanceStateStruct>();

            foreach (var entity in filter)
            {
                ref var data = ref allData.Get(entity);

                if (data.Id == itemID)
                {
                    ref var upgradeData = ref data.Upgrade1Data;

                    if (upgradeId == 1)
                    {
                        upgradeData = ref data.Upgrade2Data;
                    }

                    if (upgradeData.IsBought)
                    {
                        return;
                    }

                    if (_storage.Balance - upgradeData.Price >= 0)
                    {
                        _storage.Balance -= upgradeData.Price;

                        upgradeData.IsBought = true;

                        _storage.UserDataContainer.BuisnesStates[itemID].Upgrades[upgradeId] = true;

                        _storage.UserDataContainer = _storage.UserDataContainer;

                        viewsToUpdatePool.Add(entity);

                        foreach (var entityBalance in filterBalance)
                        {
                            ref var dataBalance = ref allDataBalance.Get(entityBalance);

                            dataBalance.BalanceAmount = _storage.Balance;

                            viewsToUpdatePool.Add(entityBalance);
                        }
                    }
                }
            }
        }

        private void HandleLevelUpItemClick(int id)
        {
            var world = _systems.GetWorld();
            var filter = world.Filter<BuisnessStateStruct>().End();
            var allData = world.GetPool<BuisnessStateStruct>();
            var viewsToUpdatePool = world.GetPool<ViewsToUpdate>();
            var states = _storage.UserDataContainer.BuisnesStates;

            var filterBalance = world.Filter<BalanceStateStruct>().End();
            var allDataBalance = world.GetPool<BalanceStateStruct>();

            foreach (var entity in filter)
            {
                ref var data = ref allData.Get(entity);

                if (data.Id == id)
                {
                    var upgradePrice = BuisnessCalculator.CalculateUpdgradePrice(data.CurrentLevel, data.BasicPrice);

                    if (_storage.Balance - upgradePrice >= 0)
                    {
                        _storage.Balance -= upgradePrice;
                        _storage.UserDataContainer.BuisnesStates[id].Level++;
                        _storage.UserDataContainer = _storage.UserDataContainer;

                        data.CurrentLevel++;

                        viewsToUpdatePool.Add(entity);

                        foreach (var entityBalance in filterBalance)
                        {
                            ref var dataBalance = ref allDataBalance.Get(entityBalance);

                            dataBalance.BalanceAmount = _storage.Balance;

                            viewsToUpdatePool.Add(entityBalance);
                        }
                    }
                }
            }
        }
    }
}


