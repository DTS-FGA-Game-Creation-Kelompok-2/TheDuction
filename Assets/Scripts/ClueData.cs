using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class ClueData : ScriptableObject
    {
        public string ClueName;
        public string ClueDescription;
        public Sprite ClueImage;
    }
}

