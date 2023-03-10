using UnityEngine;

namespace Sagra.Assets._Scripts._Misc
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeArea : MonoBehaviour
    {
        private RectTransform _safeAreaRect;
        private Canvas _canvas;
        private Rect _lastSafeArea;

        void Start()
        {
            _safeAreaRect = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            OnRectTransformDimensionsChange();
        }

        private void OnRectTransformDimensionsChange()
        {

            if (GetSafeArea() != _lastSafeArea && _canvas != null)
            {
                _lastSafeArea = GetSafeArea();
                UpdateSizeToSafeArea();
            }
        }

        private void UpdateSizeToSafeArea()
        {

            var safeArea = GetSafeArea();
            var inverseSize = new Vector2(1f, 1f) / _canvas.pixelRect.size;
            var newAnchorMin = Vector2.Scale(safeArea.position, inverseSize);
            var newAnchorMax = Vector2.Scale(safeArea.position + safeArea.size, inverseSize);

            _safeAreaRect.anchorMin = newAnchorMin;
            _safeAreaRect.anchorMax = newAnchorMax;

            _safeAreaRect.offsetMin = Vector2.zero;
            _safeAreaRect.offsetMax = Vector2.zero;
        }

        private Rect GetSafeArea()
        {
            return Screen.safeArea;
        }
    }
}


