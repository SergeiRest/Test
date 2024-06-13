using System.Linq;
using Leopotam.Ecs;

namespace Scripts.Items
{
    public class StorageSlotsChecker : IEcsRunSystem
    {
        private readonly EcsFilter<ItemsStorage>.Exclude<FillingComponent> _filter = null;
        
        public void Run()
        {
            if(_filter.IsEmpty())
                return;
            
            foreach (var i in _filter)
            {
                ref var component = ref _filter.Get1(i);
                ref EcsEntity entity = ref _filter.GetEntity(i);

                if (component.Transforms.Count(point => point.childCount == 0) > 0)
                {
                    entity.Get<FillingComponent>() = new FillingComponent()
                    {
                        MaxTime = 1,
                        CurrentTime = 0
                    };
                }
            }
        }
    }
}