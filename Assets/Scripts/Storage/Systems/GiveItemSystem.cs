using System;
using System.Linq;
using Leopotam.Ecs;
using Scripts.Items.Items;
using Scripts.Player.Components;
using UnityEngine;

namespace Scripts.Items
{
    public class GiveItemSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemsStorage, PlayerEntered> _filter = null;
        private readonly EcsFilter<Item, ItemInStorage> _itemsFilter;
        private readonly EcsFilter<PlayerStack> _playerStack;
        
        public void Run()
        {
            if(_filter.IsEmpty())
                return;

            foreach (var i in _filter)
            {
                ref ItemsStorage storage = ref _filter.Get1(i);
                try
                {
                    string slotKey = storage.Transforms.Last(point => point.childCount > 0).name;

                    foreach (var item in _itemsFilter)
                    {
                        ref var storageComponent = ref _itemsFilter.Get2(item);
                        if (storageComponent.StorageIndex != storage.Index || storageComponent.SlotIndex != slotKey)
                            continue;

                        ref PlayerStack stack = ref _playerStack.Get1(0);
                        
                        if(!stack.HasEmptyPoints())
                            return;
                        
                        ref EcsEntity itemEntity = ref _itemsFilter.GetEntity(item);
                        ref var itemComponent = ref _itemsFilter.Get1(item);
                        //itemComponent.Transform.SetParent(null);
                        stack.SetItem(itemComponent.Transform);
                        
                        itemEntity.Del<ItemInStorage>();
                        itemEntity.Get<MoveToStack>();
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("All slots is empty");
                }
            }
        }
    }
}