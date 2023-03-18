namespace Sagra.Assets._Scripts._Components
{
    public struct UnitStateComponent
    {
        public MovingState MovingState;
        public int PositionIndex;
    }

    public enum MovingState
    {
        Idle,
        Moving
    }
}


