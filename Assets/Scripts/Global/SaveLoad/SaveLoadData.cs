using System.Collections.Generic;
using TheDuction.Event;
using TheDuction.Event.BranchEvent;
using TheDuction.Interaction;
using TheDuction.Quest;
using UnityEngine;


namespace TheDuction.Global.SaveLoad
{
    public class SaveLoadData : SingletonBaseClass<SaveLoadData>
    {
        private const string SAVE_KEY = "save";
        [SerializeField] private List<ClueData> _inventory = new List<ClueData>();
        [SerializeField] private List<string> _currentEvents;
        [SerializeField] private string _currentBranch;
        [SerializeField] private string _currentQuest;
        
        public List<ClueData> Inventory => _inventory;

        private void OnEnable()
        {
            ClueInteractable.OnItemInteracted += SaveInventory;
        }
        
        private void OnDisable()
        {
            ClueInteractable.OnItemInteracted -= SaveInventory;
        }

        private void Awake()
        {
            Load();
        }

        private void SaveInventory(ClueData clueData)
        {
            _inventory.Add(clueData);
            Save();
        }

        public void SaveQuest(QuestModel quest){
            _currentQuest = quest.QuestId;
            Save();
        }

        public void SaveEvent(EventData eventData){
            _currentEvents.Add(eventData.EventId);
            Save();
        }

        public void ResetEvent(){
            _currentEvents.RemoveRange(0, _currentEvents.Count - 1);
            Save();
        }

        public void SaveBranch(BranchEventData branch){
            _currentBranch = branch.ID;
            Save();
        }
        
        private void Save()
        {
            string saveString = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(SAVE_KEY, saveString);
        }
        
        private void Load()
        {
            if(PlayerPrefs.HasKey(SAVE_KEY))
            {
                string saveString = PlayerPrefs.GetString(SAVE_KEY);
                JsonUtility.FromJsonOverwrite(saveString, this);
            }
            else
            {
                Save();
            }
        }
    }
}

