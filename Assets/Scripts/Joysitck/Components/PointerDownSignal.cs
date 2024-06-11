using UnityEngine;

namespace Scripts.Joysitck.Components
{
    public struct PointerDownSignal
    {
        public Vector2 EventDataPosition;
    }

    public struct PointerUpSignal
    {

    }

    public struct DragSignal
    {
        public Vector2 EventDataPosition;
    }

    public struct UpdateAfterDrag
    {
        public Vector2 Position;
    }
}