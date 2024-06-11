using Leopotam.Ecs;
using Scripts.Joysitck.Components;
using Scripts.Player.Components;
using UnityEngine;

namespace Scripts.Player.Systems
{
    public class UpdateDirectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MoveComponent> _filter = null;

        private readonly EcsFilter<UpdateAfterDrag> _dragSignal = null;
        private readonly EcsFilter<PointerUpSignal> _pointerUpSignal = null;
        
        public void Run()
        {
            if (!_dragSignal.IsEmpty())
            {
                UpdateDirection(_dragSignal.Get1(0).Position);
            }

            if (!_pointerUpSignal.IsEmpty())
            {
                UpdateDirection(Vector3.zero);
            }
        }

        private void UpdateDirection(Vector3 direction)
        {
            foreach (var i in _filter)
            {
                ref MoveComponent moveComponent = ref _filter.Get1(i);
                moveComponent.direction = direction;
            }
        }
    }
}