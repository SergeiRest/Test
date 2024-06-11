using Leopotam.Ecs;
using UnityEngine;

namespace Scripts.Items
{
    public class FillTimer : IEcsRunSystem
    {
        private readonly EcsFilter<ItemsStorage, FillingComponent> _filter = null;
        private readonly EcsWorld _world = null;
        
        public void Run()
        {
            if(_filter.IsEmpty())
                return;

            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                ref FillingComponent fillingComponent = ref _filter.Get2(i);
                fillingComponent.CurrentTime += Time.deltaTime;

                if (fillingComponent.CurrentTime >= fillingComponent.MaxTime)
                {
                    Debug.Log("TimerEnd");
                    fillingComponent.CurrentTime = 0;
                    entity.Get<AddItemComponent>();
                }
            }
        }
    }
}