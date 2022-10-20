using System.Collections.Generic;
using TheDuction.Global;
using TheDuction.Global.SaveLoad;
using UnityEngine;

namespace TheDuction.Quest{
    public class QuestManager: SingletonBaseClass<QuestManager>{
        [Header("Quest Model")]
        [SerializeField] private List<QuestModel> _questsContainer;

        [Header("Quest Controller")]
        [SerializeField] private QuestController _questControllerPrefab;
        [SerializeField] private Transform _questControllerParent;
        private List<QuestController> _questControllerPool;

        [Header("Quest View")]
        [SerializeField] private QuestView _questViewPrefab;
        [SerializeField] private Transform _questViewParent;
        private List<QuestView> _questViewPool;

        private void Awake() {
            _questControllerPool = new List<QuestController>();
            _questViewPool = new List<QuestView>();
        }

        /// <summary>
        /// Handle quest tag
        /// </summary>
        /// <param name="questId">Quest ID</param>
        public void HandleQuestTag(string questId){
            QuestModel questModel = GetQuestModel(questId);
            if(questModel == null) return;

            QuestController questController = GetOrCreateQuestController();
            SaveLoadData.Instance.SaveQuest(questModel);
            questController.QuestObject = questModel;
            questController.gameObject.SetActive(true);

            QuestView questView = GetOrCreateQuestViewObject();
            questView.QuestController = questController;
            questView.gameObject.SetActive(false);
            questView.SetupQuest();
        }

        public QuestController GetQuestController(QuestModel questModel){
            foreach(QuestController questController in _questControllerPool){
                if(!questController.gameObject.activeInHierarchy) continue;

                if(questController.QuestObject == questModel){
                    return questController;
                }
            }

            Debug.LogError($"Quest Controller with Quest ID: {questModel.QuestId} not found");
            return null;
        }

        /// <summary>
        /// Update quest's name
        /// </summary>
        /// <param name="questController">Quest controller</param>
        public void UpdateQuestNameText(QuestController questController){
            QuestView questView = GetQuestView(questController);
            if(questView == null) return;

            string questName = $"{questController.QuestObject.QuestName} ({questController.CurrentDefinitionOfDone}/{questController.QuestObject.DefinitionOfDone})";
            questView.UpdateQuestNameText(questName);
        }

        /// <summary>
        /// Quest controller object pooling
        /// </summary>
        /// <returns></returns>
        private QuestController GetOrCreateQuestController(){
            QuestController questController = _questControllerPool.Find(qc => !qc.gameObject.activeInHierarchy);

            if(questController == null){
                questController = Instantiate(_questControllerPrefab, _questControllerParent);
                _questControllerPool.Add(questController);
            }

            return questController;
        }

        /// <summary>
        /// Get quest model in quest container by quest ID
        /// </summary>
        /// <param name="questId">Quest ID</param>
        /// <returns>Return quest model if found in quest container or null if not found</returns>
        private QuestModel GetQuestModel(string questId){
            foreach (QuestModel questModel in _questsContainer)
            {
                if(questModel.QuestId == questId){
                    return questModel;
                }
            }

            Debug.LogError($"Quest model with ID: {questId} not found");
            return null;
        }

        /// <summary>
        /// Get quest view by quest controller
        /// </summary>
        /// <param name="questController">Quest controller</param>
        /// <returns>Returns quest view if found in pool or null if not found</returns>
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
        /// Quest view object pooling
        /// </summary>
        /// <returns></returns>
        private QuestView GetOrCreateQuestViewObject()
        {
            QuestView questView = _questViewPool.Find(questView => !questView.gameObject.activeInHierarchy);

            if (questView == null)
            {
                questView = Instantiate(_questViewPrefab, _questViewParent).GetComponent<QuestView>();
                // Add new choice manager to pool 
                _questViewPool.Add(questView);
            }

            return questView;
        }
    }
}