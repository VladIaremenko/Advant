using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using Sagra.Assets._Scripts._Config;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    internal class ObstaclesSpawnSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<TranformAnchorsHolderComponent>, Exc<PlayerControlledComponent>> _filter = default;
        readonly EcsCustomInject<ObstaclesSpawnerSO> _spawner = default;

        public void Run(IEcsSystems systems)
        {
            _spawner.Value.TimeSinceLastSpaen += Time.deltaTime;

            if (_spawner.Value.TimeSinceLastSpaen < _spawner.Value.TimeBetweenSpawns)
            {
                return;
            }

            _spawner.Value.TimeSinceLastSpaen = 0;

            foreach (var entity in _filter.Value)
            {
                ref var anchors = ref _filter.Pools.Inc1.Get(entity);

                var prefab = _spawner.Value.Items[Random.Range(0, _spawner.Value.Items.Count)];
                var newItem = GameObject.Instantiate(prefab, _spawner.Value.ObstaclesParent);
                newItem.ConvertEntities();
                newItem.transform.position = anchors.Anchors[Random.Range(0, anchors.Anchors.Length)].position;
            }
        }
    }
}
