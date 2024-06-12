using Leopotam.Ecs;
using Scripts.EntityReference.Components;

namespace Scripts.EntityReference.Systems
{
    public class EntityReferenceInitializerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EntityReferenceInitializer> _filter;
        public void Run()
        {
            if(_filter.IsEmpty())
                return;

            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref EntityReferenceInitializer entityReference = ref _filter.Get1(i);

                entityReference.EntityReference.Entity = entity;
                entity.Del<EntityReferenceInitializer>();
            }
        }
    }
}