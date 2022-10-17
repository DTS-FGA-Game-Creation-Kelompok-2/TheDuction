using System.Collections;
using TheDuction.Dialogue;
using TheDuction.Event.FinishConditionScripts;
using UnityEngine;

namespace TheDuction.Event.CameraEvent{
    public class CameraFinishedCondition: FinishConditionManager{
        // private CameraMovement _cameraMovement;
        private CameraEventController _cameraEventController;

        private void Awake() {
            // _cameraMovement = CameraMovement.Instance;
            eventController = GetComponent<CameraEventController>();
            _cameraEventController = eventController as CameraEventController;
        }

        public override void SetEndingCondition()
        {
            StartCoroutine(WaitForCamera());
        }

        /// <summary>
        /// Wait until camera's duration is up
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitForCamera(){
            Debug.Log("Wait for camera finished");
            // Wait until player don't move
            // yield return new WaitUntil(() => !cameraEventData.TargetCharacter.IsWalking);

            // Run the camera
            // Move the camera to target object
            // _cameraMovement.SetVirtualCameraPriority(cameraEventData.TargetVirtualCamera,
            //     _cameraMovement.CAMERA_HIGHER_PRIORITY);
            _cameraEventController.CutsceneTimeline.Play();

            // Move the character
            if(_cameraEventController.UseTarget){
                // cameraEventData.TargetCharacter.Move(cameraEventData.TargetPosition.position);
            }

            // Wait for camera duration
            yield return new WaitForSeconds((float) _cameraEventController.CutsceneTimeline.duration + 2f);

            // Camera finish
            Debug.Log("Camera finished");
            // cameraEventData.TargetCharacter.transform.LookAt(cameraEventData.LookAtTarget);
            // _cameraMovement.SetVirtualCameraPriority(cameraEventData.TargetVirtualCamera,
            //     _cameraMovement.LOWER_PRIORITY);
            DialogueManager.Instance.ResumeStoryForEvent();
            OnEndingCondition();
        }
    }
}