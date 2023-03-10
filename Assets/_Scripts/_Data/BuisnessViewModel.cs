using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._Data
{
    [CreateAssetMenu(fileName = "BuisnessViewModel", menuName = "SO/Data/BuisnessViewModel", order = 1)]
    public class BuisnessViewModel : ScriptableObject
    {
        public event Action<int> OnUpgradeItemCliked = new(x => { });

        public void HandleUpgradeItemClicked(int id)
        {
            OnUpgradeItemCliked(id);
        }
    }
}


