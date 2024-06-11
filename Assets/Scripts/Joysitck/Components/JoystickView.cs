using System;
using UnityEngine;

namespace Scripts.Joysitck.Components
{
    [Serializable]
    public struct JoystickView
    {
        public RectTransform RectTransform;
        public Canvas Canvas;
        public RectTransform Background;
        public RectTransform Handle;
    }
}