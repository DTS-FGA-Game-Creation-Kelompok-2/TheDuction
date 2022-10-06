using System.Collections.Generic;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Quest{
    public class QuestManager: SingletonBaseClass<QuestManager>{
        [SerializeField] private List<QuestController> _questControllers;
        [SerializeField] private QuestView _questPrefab;
        [SerializeField] private Transform _questParent;

        /// <summary>
        /// Get quest model by quest ID
        /// </summary>
        /// <param name="questId">Quest ID</param>
        /// <returns>Returns quest model by quest ID and null if there are no quest models found</returns>
        private QuestController GetQuestController(string questId){
            foreach (QuestController questModel in _questControllers)
            {
                if(questModel.QuestObject.QuestId == questId){
                    return questModel;
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
            QuestController questController = GetQuestController(tagValue);

            if(questController == null) return;

            QuestView quest = CreateQuest();
            quest.QuestController = questController;
            quest.gameObject.SetActive(true);
        }

        /// <summary>
        /// Create quest
        /// </summary>
        /// <returns>Return a new quest</returns>
        private QuestView CreateQuest(){
            QuestView quest = Instantiate(_questPrefab, _questParent).GetComponent<QuestView>();
            quest.gameObject.SetActive(false);

            return quest;
        }
    }
}