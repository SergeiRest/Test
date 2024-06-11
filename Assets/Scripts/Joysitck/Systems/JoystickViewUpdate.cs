using Leopotam.Ecs;
using Scripts.Joysitck.Components;
using UnityEngine;

namespace Scripts.Joysitck.Systems
{
    public class JoystickViewUpdate : IEcsRunSystem
    {
        private readonly EcsFilter<JoystickView> _filter = null;
        
        private readonly EcsFilter<PointerDownSignal> _pointerDownSignal = null;
        private readonly EcsFilter<PointerUpSignal> _pointerUpSignal = null;
        private readonly EcsFilter<UpdateAfterDrag> _dragUpdateSignal = null;

        private Camera _camera;

        public void Run()
        {
            if (!_pointerDownSignal.IsEmpty())
            {
                foreach (var i in _pointerDownSignal)
                {
                    Vector2 eventData = _pointerDownSignal.Get1(i).EventDataPosition;
                    foreach (var j in _filter)
                    {
                        ref JoystickView view = ref _filter.Get1(j);
                        view.Background.anchoredPosition = ScreenPointToAnchoredPosition(view, eventData);
                        view.Background.gameObject.SetActive(true);
                    }
                }
            }

            if (!_pointerUpSignal.IsEmpty())
            {
                foreach (var i in _filter)
                {
                    ref JoystickView view = ref _filter.Get1(i);
                    view.Background.gameObject.SetActive(false);
                    view.Handle.anchoredPosition = Vector2.zero;
                }
            }

            if (!_dragUpdateSignal.IsEmpty())
            {
                foreach (var i in _filter)
                {
                    Vector2 position = _dragUpdateSignal.Get1(0).Position;
                    ref JoystickView view = ref _filter.Get1(i);
                    view.Handle.anchoredPosition = position;
                }
            }
            
        }
        
        protected Vector2 ScreenPointToAnchoredPosition(JoystickView view, Vector2 screenPosition)
        {
            Vector2 localPoint = Vector2.zero;
            RectTransform rect = view.RectTransform;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPosition, _camera, out localPoint))
            {
                Vector2 pivotOffset = rect.pivot * rect.sizeDelta;
                return localPoint - (view.Background.anchorMax * rect.sizeDelta) + pivotOffset;
            }
            return Vector2.zero;
        }
    }
}