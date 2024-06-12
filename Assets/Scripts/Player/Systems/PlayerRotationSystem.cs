using Leopotam.Ecs;
using Scripts.Player.Components;
using UnityEngine;

namespace Scripts.Player.Systems
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MoveComponent> _moveFilter = null;
        private readonly EcsFilter<Player.Components.Player> _playerFilter = null;
        
        public void Run()
        {
            foreach (var i in _moveFilter)
            {
                Vector3 direction = _moveFilter.Get1(i).direction;
                if(direction == Vector3.zero)
                    return;
                
                foreach (var j in _playerFilter)
                {
                    ref Components.Player player = ref _playerFilter.Get1(i);
                    float angleY = Mathf.Atan2(direction.x, direction.y) * 180.0f / Mathf.PI;

                    Quaternion rotation = Quaternion.Euler(0.0f, angleY, 0.0f);

                    player.Model.transform.rotation = Quaternion.RotateTowards(player.Model.transform.rotation,
                        rotation, 300 * Time.deltaTime);
                }
            }
        }
    }
}