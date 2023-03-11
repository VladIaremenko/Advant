using Sagra.Assets._Scripts._UI;
using TMPro;
using UnityEngine;

namespace Sagra.Assets._Scripts._Data
{
    public struct BuisnessStateStruct
    {
        public string Title;
        public float BasicIncome;
        public float BasicPrice;
        public float IncomeDelay;
        public float CurrentIncomeProgress;
        public int CurrentLevel;
        public int Id;
        public UpgradeData Upgrade1Data;
        public UpgradeData Upgrade2Data;

        public BuisnessItemView View;
    }

    public struct BalanceStateStruct
    {
        public TextMeshProUGUI BalanceText;
        public float BalanceAmount;
    }

    public struct ViewsToUpdate
    {

    }

    public struct UpgradeData
    {
        public string Title;
        public float Price;
        public float IncomeMultiplier;
        public bool IsBought;
    }
}


