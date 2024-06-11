using System.Linq;
using Leopotam.Ecs;
using UnityEngine;

namespace Scripts.Items
{
    public class AddItemSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ItemsStorage, FillingComponent, AddItemComponent> _filter = null;
        
        private ItemsData.ItemsData _itemsData;
        
        public void Run()
        {
            if(_filter.IsEmpty())
                return;

            foreach (var i in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(i);
                
                ref ItemsStorage itemsStorage = ref _filter.Get1(i);

                string key = itemsStorage.key;
                var prefab = _itemsData.Items.First(item => item.Key == key).ItemPrefab;
                
                var obj = Object.Instantiate(prefab);
                itemsStorage.SetItem(obj);
                
                entity.Del<AddItemComponent>();

                if (itemsStorage.Transforms.Count(point => point.childCount == 0) == 0)
                {
                    entity.Del<FillingComponent>();
                }
            }
        }
    }
}