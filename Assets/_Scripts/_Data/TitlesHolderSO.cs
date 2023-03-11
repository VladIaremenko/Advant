using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sagra.Assets._Scripts._Data
{
    [CreateAssetMenu(fileName = "BuisnessTitlesAndUpgrades", menuName = "SO/Data/BuisnessTitlesAndUpgrades", order = 1)]
    public class TitlesHolderSO : ScriptableObject
    {
        public List<TitlesItem> Titles;
    }

    [Serializable]
    public class TitlesItem
    {
        public string BuisnessTitle;
        public string Upgrade1Title;
        public string Upgrade2Title;
    }
}


