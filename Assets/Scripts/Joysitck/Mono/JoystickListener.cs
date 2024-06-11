using System;
using Leopotam.Ecs;
using Scripts.Joysitck.Components;
using UnityEngine;
using UnityEngine.EventSystems;
using Voody.UniLeo;

namespace Scripts.Joysitck.Mono
{
    public class JoystickListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            WorldHandler.GetWorld().NewEntity().Get<PointerDownSignal>() = new PointerDownSignal()
            {
                EventDataPosition = eventData.position
            };
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            WorldHandler.GetWorld().NewEntity().Get<PointerUpSignal>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            WorldHandler.GetWorld().NewEntity().Get<DragSignal>() = new DragSignal()
            {
                EventDataPosition = eventData.position
            };
        }
    }
}