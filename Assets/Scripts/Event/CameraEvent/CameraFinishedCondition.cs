using System.Collections;
using TheDuction.Cameras;
using TheDuction.Dialogue;
using TheDuction.Event.FinishConditionScripts;
using UnityEngine;

namespace TheDuction.Event.CameraEvent{
    public class CameraFinishedCondition: FinishConditionManager{
        private CameraPriority _cameraPriority;
        private CameraEventController _cameraEventController;

        private void Awake() {
            _cameraPriority = CameraPriority.Instance;
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
            yield return new WaitUntil(() => !_cameraEventController.TargetCharacter.IsWalking);

            // Run the camera
            // Move the camera to target object
            _cameraPriority.SetVirtualCameraPriority(_cameraEventController.TargetVirtualCamera,
                _cameraPriority.CAMERA_HIGHER_PRIORITY);
            _cameraEventController.CutsceneTimeline.Play();

            // Move the character
            if(_cameraEventController.UseTarget){
                _cameraEventController.TargetCharacter.Move(_cameraEventController.TargetPosition.position);
            }

            // Wait for camera duration
            yield return new WaitForSeconds((float) _cameraEventController.CutsceneTimeline.duration + 2f);

            // Camera finish
            Debug.Log("Camera finished");
            _cameraEventController.TargetCharacter.transform.LookAt(_cameraEventController.LookAtTarget);
            _cameraPriority.SetVirtualCameraPriority(_cameraEventController.TargetVirtualCamera,
                _cameraPriority.LOWER_PRIORITY);
            DialogueManager.Instance.ResumeStoryForEvent();
            OnEndingCondition();
        }
    }
}