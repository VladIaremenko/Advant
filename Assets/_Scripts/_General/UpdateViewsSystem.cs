using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._Misc;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class UpdateViewsSystem : IEcsRunSystem
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
                    .CalculateIncome(data.CurrentLevel, data.BasicIncome, data.Upgrade1Multiplier, data.Upgrade2Multiplier);

                var upgradePrice = BuisnessCalculator
                    .CalculateUpdgradePrice(data.CurrentLevel, data.BasicPrice);

                data.View.TitleText.text = data.Title;
                data.View.CurrentLevelText.text = $"LVL\n{data.CurrentLevel}";
                data.View.CurrentIncomeText.text = 
                    $"Income\n{income}$";

                data.View.LevelUpButtonText.text = $"LEVEL UP\nPrice: {upgradePrice}$";

                viewsToUpdatePool.Del(entity);
            }            
        }
    }
}


