using Leopotam.Ecs;
using Scripts.Items;
using UnityEngine;

namespace Scripts.ContainerToItems.Mono
{
    public class ContainerTrigger : MonoBehaviour
    {
        [SerializeField] private EntityReference.Mono.EntityReference _entity;

        private void OnTriggerEnter(Collider other)
        {
            _entity.Entity.Get<PlayerEntered>();
        }

        private void OnTriggerExit(Collider other)
        {
            _entity.Entity.Del<PlayerEntered>();
        }
    }
}