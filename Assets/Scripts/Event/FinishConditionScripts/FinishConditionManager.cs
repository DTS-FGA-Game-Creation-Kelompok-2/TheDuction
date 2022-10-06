using UnityEngine;

namespace TheDuction.Event.FinishConditionScripts{
    public class FinishConditionManager : MonoBehaviour {
        protected EventData eventData;

        public virtual void SetEndingCondition(){}

        public virtual void OnEndingCondition(){
            eventData.isFinished = true;
        }
    }
}