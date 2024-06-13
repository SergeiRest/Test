using Leopotam.Ecs;
using Scripts.Player.Components;
using UnityEngine;

namespace Scripts.Player.Systems
{
    public class PlayerMoveAnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Components.Player, PlayerAnimator> _filter = null;
        private readonly EcsFilter<MoveComponent> _moveFilter;
        
        private readonly int Run1 = Animator.StringToHash("Run");

        public void Run()
        {
            if(_filter.IsEmpty())
                return;

            foreach (var i in _filter)
            {
                ref PlayerAnimator playerAnimator = ref _filter.Get2(i);

                foreach (var j in _moveFilter)
                {
                    if (_moveFilter.Get1(j).direction.normalized == Vector3.zero)
                    {
                        playerAnimator.Animator.SetBool("Run", false);
                    }
                    else
                    {
                        playerAnimator.Animator.SetBool("Run", true);
                    }
                }
            }
        }
    }
}