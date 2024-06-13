using System;
using System.Linq;
using UnityEngine;

namespace Scripts.ContainerToItems.Components
{
    [System.Serializable]
    public struct ItemContainer
    {
        public string Index;
        public Transform[] Transforms;

        public void SetItem(GameObject go)
        {
            Transform transform = Transforms.First(child => child.childCount == 0);
            go.transform.SetParent(transform);
            go.transform.localScale = Vector3.one;
        }

        public bool HasEmptySlots()
        {
            try
            {
                if (Transforms.Count(point => point.childCount == 0) > 0)
                    return true;
                
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GetEmptySlot() => Transforms.First(transform => transform.childCount == 0).name;
    }
}