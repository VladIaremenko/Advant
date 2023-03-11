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

        [Header("Buttons")]
        [SerializeField] private Button _levelUpButton;
        [SerializeField] private Button _upgrade1Button;
        [SerializeField] private Button _upgrade2Button;

        private void Awake()
        {
            _levelUpButton.onClick.AddListener(HandleUpgradeButtonClick);
            _upgrade1Button.onClick.AddListener(HandleUpgrade1Clicked);
            _upgrade2Button.onClick.AddListener(HandleUpgrade2Clicked);
        }

        private void HandleUpgrade1Clicked()
        {
            _buisnessViewModel.HandleUpgradeItemClick(ID, 0);
        }

        private void HandleUpgrade2Clicked()
        {
            _buisnessViewModel.HandleUpgradeItemClick(ID, 1);
        }

        private void HandleUpgradeButtonClick()
        {
            _buisnessViewModel.HandleLevelUpItemClick(ID);
        }
    }
}