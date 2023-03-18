namespace Sagra.Assets._Scripts._Components
{
    public struct UnitStateComponent
    {
        public MovingState MovingState;
        public int CurrentPositionIndex;
        public int NextPositionIndex;
    }

    public enum MovingState
    {
        Idle,
        Moving
    }
}


