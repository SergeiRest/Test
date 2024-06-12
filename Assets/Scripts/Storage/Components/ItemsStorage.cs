using System.Linq;
using UnityEngine;

namespace Scripts.Items
{
    [System.Serializable]
    public struct ItemsStorage
    {
        public string Index;
        public string key;
        public Transform[] Transforms;

        public void SetItem(GameObject go)
        {
            Transform transform = Transforms.First(child => child.childCount == 0);
            go.transform.SetParent(transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
        }

        public string GetEmptySlot() => Transforms.First(transform => transform.childCount == 0).name;
    }
}