using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Config;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sagra.Assets._Scripts._Misc
{
    public class EntityHolder : MonoBehaviour
    {
        [SerializeField] private GameConfigSO _gameConfigSO;
        private List<IConvertToEntity> _monoProviders;

        public EcsWorld World => _gameConfigSO.EcsWorld;

        private int _entity;

        private void Awake()
        {      
            GameBus.ConverEntitiesEvent.AddListener(ConvertEntities);
        }

        public void ConvertEntities()
        {
            _monoProviders = GetComponents<IConvertToEntity>().ToList();
            _entity = World.NewEntity();
            _monoProviders.ForEach(x => { x.Convert(_entity, World); });
        }
    }
}


