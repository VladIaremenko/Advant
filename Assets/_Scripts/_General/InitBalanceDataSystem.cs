using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._UserData;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class InitBalanceDataSystem : IEcsInitSystem
    {
        private StorageSO _storage;

        public InitBalanceDataSystem(StorageSO storage)
        {
            _storage = storage;
        }

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<BalanceStateStruct>().End();
            var allData = world.GetPool<BalanceStateStruct>();
            var viewsToUpdatePool = world.GetPool<ViewsToUpdate>();

            foreach (var entity in filter)
            {
                ref var data = ref allData.Get(entity);

                data.BalanceAmount = _storage.Balance;

                viewsToUpdatePool.Add(entity);
            }
        }
    }
}


