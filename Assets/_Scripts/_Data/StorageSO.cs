using Newtonsoft.Json;
using Sagra.Assets._Scripts._Misc;
using System.Collections.Generic;
using UnityEngine;

namespace Sagra.Assets._Scripts._UserData
{
    [CreateAssetMenu(fileName = "StorageSO", menuName = "SO/Data/StorageSO", order = 1)]
    public class StorageSO : ScriptableObject
    {
        private static readonly string UserDataContainerKey = "UserDataContainerKey";

        public void Init()
        {
            var json = PlayerPrefs.GetString(UserDataContainerKey, string.Empty);

            if (string.IsNullOrEmpty(json))
            {
                _levelStateData = new UserDataContainer(new List<BuisnessState>());

                _levelStateData.BuisnesStates.Add(new BuisnessState(1, 0));
                _levelStateData.BuisnesStates.Add(new BuisnessState(0, 0));
                _levelStateData.BuisnesStates.Add(new BuisnessState(0, 0));
                _levelStateData.BuisnesStates.Add(new BuisnessState(0, 0));
                _levelStateData.BuisnesStates.Add(new BuisnessState(0, 0));
            }
            else
            {
                _levelStateData = JsonConvert.DeserializeObject<UserDataContainer>(json);
            }
        }

        private UserDataContainer _levelStateData;

        public UserDataContainer UserDataContainer
        {
            get { return _levelStateData; }
            set
            {
                PlayerPrefs.SetString(UserDataContainerKey, JsonConvert.SerializeObject(value));
                _levelStateData = value;
            }
        }
    }
}
