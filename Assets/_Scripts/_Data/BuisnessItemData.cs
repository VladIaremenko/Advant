using System;
using UnityEngine;

namespace Sagra.Assets._Scripts._Data
{
    [Serializable]
    public class BuisnessItemData
    {
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


