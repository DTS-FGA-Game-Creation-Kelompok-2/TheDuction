using System.Collections;
using TheDuction.Dialogue;
using TheDuction.Event.FinishConditionScripts;
using UnityEngine;

namespace TheDuction.Event.MovementEvent{
    public class MovementFinishedCondition: FinishConditionManager{
        private MovementEventController _movementEventController;

        private void Awake() {
            eventController = GetComponent <MovementEventController>();
            _movementEventController = eventController as MovementEventController;
        }
        public override void SetEndingCondition()
        {
            base.SetEndingCondition();
            StartCoroutine(WaitForNPC());
        }

        private IEnumerator WaitForNPC(){
            Debug.Log("Wait for NPC to reach target");
            yield return new WaitUntil(() => {
                Transform targetCharacterTransform = _movementEventController.TargetCharacter.transform;
                Transform targetTransform = _movementEventController.TargetTransform;

                bool isPosition = targetCharacterTransform.position == targetTransform.position;
                bool isRotation = targetCharacterTransform.rotation == targetTransform.rotation;

                return isPosition && isRotation;
            });
            yield return new WaitForSeconds(2f);

            Debug.Log("NPC reached the target");
            DialogueManager.Instance.ResumeStoryForEvent();
            OnEndingCondition();
        }
    }
}