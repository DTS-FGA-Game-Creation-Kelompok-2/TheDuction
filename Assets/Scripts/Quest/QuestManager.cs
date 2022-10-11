using System.Collections.Generic;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Quest{
    public class QuestManager: SingletonBaseClass<QuestManager>{
        [SerializeField] private List<QuestController> _questControllerContainer;
        [SerializeField] private QuestView _questPrefab;
        [SerializeField] private Transform _questParent;

        private List<QuestView> _questViewPool;

        private void Awake() {
            _questViewPool = new List<QuestView>();
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

        private QuestView GetQuestView(QuestController questController){
            foreach(QuestView questView in _questViewPool){
                if(!questView.gameObject.activeInHierarchy) continue;

                if(questView.QuestController == questController){
                    return questView;
                }
            }

            Debug.LogError($"Quest view with quest ID: {questController.QuestObject.QuestId} not found");
            return null;
        }

        /// <summary>
        /// Handle quest tag
        /// </summary>
        /// <param name="questId">Quest ID</param>
        public void HandleQuestTag(string questId){
            QuestController questController = GetQuestController(questId);
            if(questController == null) return;

            QuestView questView = GetOrCreateQuestViewObject();

            questView.QuestController = questController;
            questView.gameObject.SetActive(false);
            questView.SetupQuest();
        }

        public void UpdateQuestNameText(QuestController questController){
            string questName = $"{questController.QuestObject.QuestName} ({questController.CurrentDefinitionOfDone}/{questController.QuestObject.DefinitionOfDone})";

            QuestView questView = GetQuestView(questController);
            if(questView == null) return;

            questView.UpdateQuestNameText(questName);
        }

        /// <summary>
        /// Quest view object pooling
        /// </summary>
        /// <returns></returns>
        private QuestView GetOrCreateQuestViewObject()
        {
            QuestView questView = _questViewPool.Find(questView => !questView.gameObject.activeInHierarchy);

            if (questView == null)
            {
                questView = Instantiate(_questPrefab, _questParent).GetComponent<QuestView>();
                // Add new choice manager to pool 
                _questViewPool.Add(questView);
            }

            return questView;
        }
    }
}