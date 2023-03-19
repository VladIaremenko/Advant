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
        private bool _useSpawner = true;


        public void Run(IEcsSystems systems)
        {
            _spawner.Value.TimeSinceLastSpawn += Time.deltaTime;

            if (_spawner.Value.TimeSinceLastSpawn < _spawner.Value.TimeBetweenSpawns)
            {
                return;
            }

            _spawner.Value.TimeSinceLastSpawn = 0;

            foreach (var entity in _filter.Value)
            {
                ref var anchors = ref _filter.Pools.Inc1.Get(entity);

                _useSpawner = true;

                for (int i = 0; i < _spawner.Value.CreatedItems.Count; i++)
                {
                    if (!_spawner.Value.CreatedItems[i].gameObject.activeInHierarchy)
                    {
                        Debug.Log("Take from pool");

                        ActivateItem(anchors, _spawner.Value.CreatedItems[i]);
                        _useSpawner = false;
                    }
                }

                if (_useSpawner)
                {
                    var prefab = _spawner.Value.Items[Random.Range(0, _spawner.Value.Items.Count)];
                    var newItem = GameObject.Instantiate(prefab, _spawner.Value.ObstaclesParent);
                    _spawner.Value.CreatedItems.Add(newItem);
                    newItem.ConvertEntities();

                    ActivateItem(anchors, newItem);
                }
            }
        }

        private static void ActivateItem(TranformAnchorsHolderComponent anchors, EntityHolder item)
        {
            item.gameObject.SetActive(true);
            item.transform.position = anchors.Anchors[Random.Range(0, anchors.Anchors.Length)].position;
        }
    }
}
