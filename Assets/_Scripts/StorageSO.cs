using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Sagra.Assets._Scripts
{
    [CreateAssetMenu(fileName = "StorageSO", menuName = "SO/General/StorageSO", order = 1)]
    public class StorageSO : ScriptableObject
    {
        private static readonly string BuisnessStateKey = "BuisnessStateKey";

        public void Init()
        {

        }
    }
}
