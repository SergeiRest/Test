using Leopotam.Ecs;
using Scripts.Joysitck.Components;
using Scripts.Player.Components;
using UnityEngine;

namespace Scripts.Player.Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MoveComponent> _moveFilter;
        private readonly EcsFilter<Components.Player> _playerFilter;

        private float speed = 10;

        public void Run()
        {

            foreach (var i in _moveFilter)
            {
                Vector3 direction = _moveFilter.Get1(i).direction.normalized;
                foreach (var j in _playerFilter)
                {
                    ref Components.Player player = ref _playerFilter.Get1(i);

                    Vector3 playerPosition = player.Transform.localPosition;
//                    Debug.Log(position.normalized);

                    Vector3 movePosition = Vector3.Lerp(playerPosition,
                        playerPosition + new Vector3(direction.x, 0, direction.y), speed * Time.deltaTime);

                    player.Transform.localPosition = movePosition;
                }
            }
        }
    }
}