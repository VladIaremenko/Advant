using Leopotam.EcsLite;
using Sagra.Assets._Scripts._Data;
using Unity.VisualScripting;
using UnityEngine;

namespace Sagra.Assets._Scripts._General
{
    public class UserInputSystem : IEcsInitSystem
    {
        private BuisnessViewModel _buisnessViewModel;

        public UserInputSystem(BuisnessViewModel buisnessViewModel)
        {
            _buisnessViewModel = buisnessViewModel;
        }

        public void Init(IEcsSystems systems)
        {
            _buisnessViewModel.OnUpgradeItemCliked += HandleUpgeadeItemClick;
        }

        private void HandleUpgeadeItemClick(int id)
        {
            
        }
    }
}


