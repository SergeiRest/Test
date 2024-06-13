using Leopotam.Ecs;
using Scripts.ContainerToItems.Components;
using Scripts.Items;
using Scripts.Items.Items;
using Scripts.Player.Components;
using UnityEngine;

namespace Scripts.ContainerToItems.Systems
{
    public class SetItemInContainer : IEcsRunSystem
    {
        private readonly EcsFilter<ItemContainer, PlayerEntered> _filter = null;
        private readonly EcsFilter<Item, ItemInStack> _itemFilter = null;
        private readonly EcsFilter<PlayerStack> _stack;
        
        public void Run()
        {
            if(_filter.IsEmpty())
                return;

            foreach (var i in _filter)
            {
                ref ItemContainer container = ref _filter.Get1(i);
                ref var stack = ref _stack.Get1(0);
                string key = stack.GetLast();
                Debug.Log(key);
                
                foreach (var j in _itemFilter)
                {
                    if(!container.HasEmptySlots())
                        return;

                    ref EcsEntity entity = ref _itemFilter.GetEntity(j);
                    ref Item item = ref _itemFilter.Get1(j);
                    ref ItemInStack itemInStack = ref _itemFilter.Get2(j);
                    
                    if(itemInStack.key != key)
                        continue;

                    container.SetItem(item.Transform.gameObject);
                    
                    entity.Del<ItemInStack>();
                    entity.Get<MoveToContainer>();
                }
            }
        }
    }
}