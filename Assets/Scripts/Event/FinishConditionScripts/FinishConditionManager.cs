using UnityEngine;

namespace TheDuction.Event.FinishConditionScripts{
    public class FinishConditionManager : MonoBehaviour {
        protected EventController eventController;

        public virtual void SetEndingCondition(){}

        public virtual void OnEndingCondition(){
            eventController.IsFinished = true;
        }
    }
}