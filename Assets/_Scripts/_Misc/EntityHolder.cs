﻿using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sagra.Assets._Scripts._Misc
{
    public class EntityHolder : MonoBehaviour
    {
        [SerializeField] private List<IConvertToEntity> _monoProviders;

        private EcsWorld _world => WorldHolder.EcsWorld;

        private int _entity;

        private void Awake()
        {
            _monoProviders = GetComponents<IConvertToEntity>().ToList();

            GameBus.ConverEntitiesEvent.AddListener(ConvertEntities);
        }

        private void ConvertEntities()
        {
            _entity = _world.NewEntity();
            _monoProviders.ForEach(x => { x.Convert(_entity, _world); });
        }
    }
}

