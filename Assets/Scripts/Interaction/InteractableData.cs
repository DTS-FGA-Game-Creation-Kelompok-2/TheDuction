using UnityEngine;

namespace TheDuction.Interaction{
    [CreateAssetMenu(fileName = "New Interactable", menuName = "Scriptable Objects/Interactable/Interactable")]
    public class InteractableData: ScriptableObject{
        public string InteractableID;
        public string InteractableName;
        [TextArea(3, 5)]
        public string InteractableDescription;
    }
}