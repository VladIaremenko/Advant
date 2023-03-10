using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._Data
{
    [CreateAssetMenu(fileName = "BuisnessItemDataSO", menuName = "SO/Data/BuisnessItemDataSO", order = 1)]
    public class BuisnessItemDataSO : ScriptableObject
    {
        public string Title;
        public float BasicIncome;
        public float BasicPrice;

        public BuisnessUpgrade Upgrade1;
        public BuisnessUpgrade Upgrade2;
    }

    [Serializable]
    public class BuisnessUpgrade
    {
        public float Price;
        public float IncomeIncrease;
    }
}


