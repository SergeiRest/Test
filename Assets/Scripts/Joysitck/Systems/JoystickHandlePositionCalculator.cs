using Leopotam.Ecs;
using Scripts.Joysitck.Components;
using UnityEngine;

namespace Scripts.Joysitck.Systems
{
    public class JoystickHandlePositionCalculator : IEcsRunSystem
    {
        private readonly EcsFilter<JoystickView> _filter = null;
        private readonly EcsFilter<DragSignal> _signal;
        private readonly EcsWorld _world = null;

        private float _deadZone = 0;
        private float _handleRange = 1;
        private Vector2 _input = Vector2.zero;
        private Camera _camera;

        public void Run()
        {
            if(_signal.IsEmpty())
                return;

            Vector2 eventData = _signal.Get1(0).EventDataPosition;

            foreach (var i in _filter)
            {
                ref JoystickView view = ref _filter.Get1(i);
                
                Vector2 position = RectTransformUtility.WorldToScreenPoint(_camera, view.Background.position);
                Vector2 radius = view.Background.sizeDelta / 2;
                _input = (eventData - position) / (radius * view.Canvas.scaleFactor);
                HandleInput(_input.magnitude, _input.normalized, radius, _camera);
                _world.NewEntity().Get<UpdateAfterDrag>() = new UpdateAfterDrag()
                {
                    Position = _input * radius * _handleRange
                };
                //handle.anchoredPosition = _input * radius * handleRange;
            }
        }
        
        private void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            if (magnitude > _deadZone)
            {
                if (magnitude > 1)
                    _input = normalised;
            }
            else
                _input = Vector2.zero;
        }
    }
}