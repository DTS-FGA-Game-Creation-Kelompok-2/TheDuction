using UnityEngine;

namespace TheDuction.Interaction
{
    [CreateAssetMenu(fileName = "New Clue", menuName = "Scriptable Objects/Interactable/Clue")]
    public class ClueData : InteractableData
    {
        public bool KeepObjectAfterInteracting;
        public Sprite ClueImageSmall;
        public Sprite ClueImageLarge;
    }
}

