using UnityEngine;

namespace Sagra.Assets._Scripts._Components
{
    public struct UnitStateComponent
    {
        public MovingState MovingState;
        public PositionState PositionState;
    }

    public enum MovingState
    {
        Idle,
        Moving
    }

    public enum PositionState
    {
        Left,
        Center,
        Right
    }
}


