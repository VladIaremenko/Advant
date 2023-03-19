using Leopotam.EcsLite;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sagra.Assets._Scripts._Misc
{
    public class EntityHolder : MonoBehaviour
    {
        private List<IConvertToEntity> _monoProviders;

        private EcsWorld _world => WorldHolder.EcsWorld;

        private int _entity;

        private void Awake()
        {      
            GameBus.ConverEntitiesEvent.AddListener(ConvertEntities);
        }

        public void ConvertEntities()
        {
            _monoProviders = GetComponents<IConvertToEntity>().ToList();
            _entity = _world.NewEntity();
            _monoProviders.ForEach(x => { x.Convert(_entity, _world); });
        }
    }
}


