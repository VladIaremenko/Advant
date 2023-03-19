using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sagra.Assets._Scripts._Components;
using Sagra.Assets._Scripts._Config;
using Sagra.Assets._Scripts._Misc;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    internal class ObstaclesSpawnSystem : IEcsRunSystem
    {
        readonly EcsFilterInject<Inc<TranformAnchorsHolderComponent>, Exc<PlayerControlledComponent>> _filter = default;
        readonly EcsCustomInject<ObstaclesSpawnerSO> _spawner = default;
        readonly EcsCustomInject<GameConfigSO> _config = default;

        public void Run(IEcsSystems systems)
        {
            _spawner.Value.TimeSinceLastSpawn += Time.deltaTime;

            if (_spawner.Value.TimeSinceLastSpawn < _config.Value.TimeBetweenSpawns)
            {
                return;
            }

            _spawner.Value.TimeSinceLastSpawn = 0;

            foreach (var entity in _filter.Value)
            {
                ref var anchors = ref _filter.Pools.Inc1.Get(entity);

                _config.Value.CreateNewEntity = true;

                for (int i = 0; i < _spawner.Value.CreatedItems.Count; i++)
                {
                    if (!_spawner.Value.CreatedItems[i].gameObject.activeInHierarchy)
                    {
                        ActivateItem(anchors, _spawner.Value.CreatedItems[i]);
                        _config.Value.CreateNewEntity = false;
                        break;
                    }
                }

                if (_config.Value.CreateNewEntity)
                {
                    ActivateItem(anchors, CreateNewEntity());
                }
            }
        }

        private EntityHolder CreateNewEntity()
        {
            var prefab = _spawner.Value.Items[Random.Range(0, _spawner.Value.Items.Count)];
            var newItem = GameObject.Instantiate(prefab, _spawner.Value.ObstaclesParent);
            _spawner.Value.CreatedItems.Add(newItem);
            newItem.ConvertEntities();
            return newItem;
        }

        private void ActivateItem(TranformAnchorsHolderComponent anchors, EntityHolder item)
        {
            item.gameObject.SetActive(true);
            item.transform.position = anchors.Anchors[Random.Range(0, anchors.Anchors.Length)].position;
        }
    }
}
