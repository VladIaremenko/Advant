using Sagra.Assets._Scripts._Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sagra.Assets._Scripts._UI
{
    public class BuisnessItemView : MonoBehaviour
    {
        public TextMeshProUGUI TitleText => _titleText;
        public TextMeshProUGUI CurrentLevelText => _currentLevelText;
        public TextMeshProUGUI CurrentIncomeText => _currentIncomeText;
        public TextMeshProUGUI LevelUpButtonText => _levelUpButtonText;
        public int ID { get; set; }

        [SerializeField] private BuisnessViewModel _buisnessViewModel;

        [Header("UI")]
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private TextMeshProUGUI _currentIncomeText;
        [SerializeField] private TextMeshProUGUI _levelUpButtonText;
        [SerializeField] private TextMeshProUGUI _upgradeButton1Text;
        [SerializeField] private TextMeshProUGUI _upgradeButton2Text;
        [SerializeField] private Button _upgradeButton;

        private void Awake()
        {
            _upgradeButton.onClick.AddListener(HandleUpgradeButtonClick);
        }

        private void HandleUpgradeButtonClick()
        {
            _buisnessViewModel.HandleUpgradeItemClicked(ID);
        }
    }
}