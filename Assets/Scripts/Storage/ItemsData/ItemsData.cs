using UnityEngine;

namespace Scripts.Items.ItemsData
{
    [CreateAssetMenu(fileName = "ItemsData", menuName = "Data/ItemsData")]
    public class ItemsData : ScriptableObject
    {
        public Item[] Items;
    }

    [System.Serializable]
    public struct Item
    {
        public GameObject ItemPrefab;
        public string Key;
    }
}