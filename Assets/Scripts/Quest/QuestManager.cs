using System.Collections.Generic;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Quest{
    public class QuestManager: SingletonBaseClass<QuestManager>{
        [SerializeField] private List<QuestController> _questControllerContainer;
        [SerializeField] private QuestView _questPrefab;
        [SerializeField] private Transform _questParent;

        private List<QuestView> _questViewsToBeActivated;

        private void Awake() {
            _questViewsToBeActivated = new List<QuestView>();
        }

        /// <summary>
        /// Get quest model by quest ID
        /// </summary>
        /// <param name="questId">Quest ID</param>
        /// <returns>Returns quest model by quest ID and null if there are no quest models found</returns>
        private QuestController GetQuestController(string questId){
            foreach (QuestController questController in _questControllerContainer)
            {
                if(questController.QuestObject.QuestId == questId){
                    return questController;
                }
            }

            Debug.LogError($"Quest with ID: {questId} not found");
            return null;
        }

        /// <summary>
        /// Handle quest tag
        /// </summary>
        /// <param name="tagValue">Quest ID</param>
        public void HandleQuestTag(string tagValue){
            string[] questIds = tagValue.Split(',');

            if(questIds.Length <= 0) return;

            foreach(string questId in questIds){
                QuestController questController = GetQuestController(questId);

                if(questController == null) return;

                QuestView quest = Instantiate(_questPrefab, _questParent).GetComponent<QuestView>();
                quest.QuestController = questController;
                quest.gameObject.SetActive(false);
                quest.SetupQuest();
                _questViewsToBeActivated.Add(quest);
            }
        }

        public void ActivateAllQuestViews(){
            if(_questViewsToBeActivated.Count == 0) return;

            foreach(QuestView questView in _questViewsToBeActivated){
                questView.gameObject.SetActive(true);
            }

            // Remove from list after activating it
            _questViewsToBeActivated.RemoveAll(questView => questView.gameObject.activeInHierarchy);
        }
    }
}