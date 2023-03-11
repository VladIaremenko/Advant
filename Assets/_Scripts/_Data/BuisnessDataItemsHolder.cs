using System.Collections.Generic;
using UnityEngine;

namespace Sagra.Assets._Scripts._Data
{
    [CreateAssetMenu(fileName = "BuisnessDataItemsHolder", menuName = "SO/Data/BuisnessDataItemsHolder", order = 1)]
    public class BuisnessDataItemsHolder : ScriptableObject
    {
        public TitlesHolderSO TitlesHolderSO;
        public List<BuisnessItemData> BuisnessItems;
    }
}


