using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Scripts.Items
{
    public class StorageTrigger : MonoBehaviour
    {
        [SerializeField] private EntityReference.Mono.EntityReference _entityReference;

        private void OnTriggerEnter(Collider other)
        {
            _entityReference.Entity.Get<PlayerEntered>();
        }

        private void OnTriggerExit(Collider other)
        {
            _entityReference.Entity.Del<PlayerEntered>();
        }
    }
}