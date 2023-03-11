using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._Data
{
    [CreateAssetMenu(fileName = "BuisnessViewModel", menuName = "SO/Data/BuisnessViewModel", order = 1)]
    public class BuisnessViewModel : ScriptableObject
    {
        public event Action<int> OnLevelUpItemClick = new(x => { });
        public event Action<int, int> OnUpgradeUpItemClick = new((x,y) => { });

        public void HandleLevelUpItemClick(int id)
        {
            OnLevelUpItemClick(id);
        }

        public void HandleUpgradeItemClick(int itemId, int upgradeId)
        {
            OnUpgradeUpItemClick.Invoke(itemId, upgradeId);
        }
    }
}


