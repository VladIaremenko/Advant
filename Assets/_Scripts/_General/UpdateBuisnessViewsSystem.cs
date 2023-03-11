using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._Misc;

namespace Sagra.Assets._Scripts._General
{
    public class UpdateBuisnessViewsSystem : IEcsRunSystem
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

                var income = BuisnessCalculator
                    .CalculateIncome(data.CurrentLevel, data.BasicIncome,
                    data.Upgrade1Data.IsBought ? data.Upgrade1Data.IncomeMultiplier : 0,
                    data.Upgrade2Data.IsBought ? data.Upgrade2Data.IncomeMultiplier : 0);

                var upgradePrice = BuisnessCalculator
                    .CalculateUpdgradePrice(data.CurrentLevel, data.BasicPrice);

                data.View.TitleText.text = data.Title;
                data.View.CurrentLevelText.text = $"LVL\n{data.CurrentLevel}";
                data.View.CurrentIncomeText.text =
                    $"Income\n{income}$";

                data.View.LevelUpButtonText.text = $"LEVEL UP\nPrice: {upgradePrice}$";

                data.View.Upgrade1ButtonText.text = GetUpgradeButtonText(ref data.Upgrade1Data);
                data.View.Upgrade2ButtonText.text = GetUpgradeButtonText(ref data.Upgrade2Data);

                viewsToUpdatePool.Del(entity);
            }
        }

        private string GetUpgradeButtonText(ref UpgradeData data)
        {
            return $"Title\nIncome: +{data.IncomeMultiplier}%\n" +
                    $"{(data.IsBought ? "Purchased" : $"Price: {data.Price}$")}";
        }
    }
}


