using UnityEngine;

namespace Sagra.Assets._Scripts
{
    public class AppInitializer : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }
}


