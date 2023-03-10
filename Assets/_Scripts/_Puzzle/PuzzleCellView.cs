using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Scripts._Puzzle
{
    public class PuzzleCellView : MonoBehaviour
    {
        [SerializeField] private PuzzleViewModel _puzzleViewModel;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Transform _content;
        [SerializeField] private Button _viewButton;
        [SerializeField] private Vector2Int _position;

        [Header("Icons")]
        [SerializeField] private Animator _animator;
        [SerializeField] private Image _image;

        private CellState _currentState = CellState.None;

        public Vector2Int Position => _position;
        public Transform Content => _content;

        private void Awake()
        {
            _viewButton.onClick.AddListener(HandleButtonClick);
        }

        private void HandleButtonClick()
        {
            _puzzleViewModel.HandleSelectItem(_position);
        }

        public void SetPosition(Vector2Int position)
        {
            _position = position;
        }

        public void SeText(string text)
        {
            _buttonText.text = text;
        }

        public void SetIcon(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void HandleSelection()
        {
            SetState(CellState.Selected);
        }

        public void HandleDefaultMode()
        {
            SetState(CellState.Default);
        }

        public void HandleDeath()
        {

        }

        private void SetState(CellState state)
        {
            if(state == _currentState)
            {
                return;
            }

            _currentState = state;

            switch(state)
            {
                case CellState.Default:
                    _animator.Play("None");
                    break;
                case CellState.Selected:
                    _animator.Play("Selection");
                    break;
                case CellState.Dead:
                    _animator.Play("None");
                    break;
            }
        }

        public enum CellState
        {
            None,
            Default,
            Selected,
            Dead
        }
    }
}


