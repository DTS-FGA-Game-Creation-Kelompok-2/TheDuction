using System;
using System.Collections;
using System.Collections.Generic;
using TheDuction.Global;
using TheDuction.Interaction;
using UnityEngine;


namespace TheDuction.Global.SaveLoad
{
    public class SaveLoadData : SingletonBaseClass<SaveLoadData>
    {
        private const string SAVE_KEY = "save";
        [SerializeField] private List<ClueData> _inventory = new List<ClueData>();
        [SerializeField] private string _currentEvent;
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

        private void SaveEvent(string eventID)
        {
            _currentEvent = eventID;
            Save();
        }
        
        private void SaveQuest(string questID)
        {
            _currentQuest = questID;
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

