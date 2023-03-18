using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Sagra.Assets._Scripts._General;
using Sagra.Assets._Scripts._UI;
using Sagra.Assets._Scripts._UserData;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sagra.Assets._Scripts._Fly
{
    public class AppInitializer : MonoBehaviour
    {
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
            _ecsWorld = new EcsWorld();
            _systems = new EcsSystems(_ecsWorld);

            _systems
                .Add(new UserInputSystem())
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


