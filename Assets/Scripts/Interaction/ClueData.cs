using UnityEngine;

namespace TheDuction.Interaction
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class ClueData : ScriptableObject
    {
        public string ClueID;
        public string ClueName;
        public string ClueDescription;
        public Sprite ClueImage;
    }
}

