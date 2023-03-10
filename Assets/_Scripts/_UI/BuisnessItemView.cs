using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sagra.Assets._Scripts._UI
{
    public class BuisnessItemView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _currentLevelText;
        [SerializeField] private TextMeshProUGUI _currentIncomeText;
        [SerializeField] private TextMeshProUGUI _levelUpButtonText;
        [SerializeField] private TextMeshProUGUI _upgradeButton1Text;
        [SerializeField] private TextMeshProUGUI _upgradeButton2Text;

        public TextMeshProUGUI TitleText => _titleText;
        public TextMeshProUGUI CurrentLevelText => _currentLevelText;
        public TextMeshProUGUI CurrentIncomeText => _currentIncomeText;
        public TextMeshProUGUI LevelUpButtonText => _levelUpButtonText;
    }
}