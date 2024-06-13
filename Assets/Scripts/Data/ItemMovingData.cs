using UnityEngine;

namespace Scripts.Data
{
    [CreateAssetMenu(fileName = "ItemMovingData", menuName = "Data/ItemMoving")]
    public class ItemMovingData : ScriptableObject
    {
        public float MoveSpeed;
        public float RotationSpeed;
    }
}