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
        public int CurrentLevel;
        public float Upgrade1Multiplier;
        public float Upgrade2Multiplier;
        public int Id;

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
}


