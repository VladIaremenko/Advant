using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._UI;
using Sagra.Assets._Scripts._UserData;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sagra.Assets._Scripts._General
{
    public class AppInitializer : MonoBehaviour
    {
        [SerializeField] private BuisnessViewModel _buisnessViewModel;
        [SerializeField] private BuisnessDataItemsHolder _buisnessDataItemsHolder;
        [SerializeField] private StorageSO _storageSO;
        [SerializeField] private TextMeshProUGUI _balanceText;
        [SerializeField] private List<BuisnessItemView> _itemsViews;

        private EcsSystems _systems;
        private EcsWorld _ecsWorld;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        void Start()
        {
            _storageSO.Init();

            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);

            _systems
                .Add(new UserInputSystem(_buisnessViewModel, _storageSO, _buisnessDataItemsHolder))
                .Add(new InitViewsSystem(_itemsViews, _balanceText))
                .Add(new InitBuisnessDataSystem(_storageSO, _buisnessDataItemsHolder))
                .Add(new InitBalanceDataSystem(_storageSO))
                .Add(new UpdateIncomeTimerSystem(_storageSO))
                .Add(new UpdateBuisnessViewsSystem())
                .Add(new UpdateBalanceViewSystem())
                .Add(new UpdateIncomeViewSystem())
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            _systems?.Destroy();
            _systems?.GetWorld()?.Destroy();
            _systems = null;
        }

        public void Reload()
        {
            SceneManager.LoadScene(0);
        }

        public void Reset()
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        }
    }
}


