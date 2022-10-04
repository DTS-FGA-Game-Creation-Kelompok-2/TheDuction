using System.Collections.Generic;
using TheDuction.Dialogue.Tags;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Dialogue.Portraits{
    public class DialoguePortraitManager :
        SingletonBaseClass<DialoguePortraitManager>, IDialoguePropertiesManager
    {
        [Header("Dialogue Portrait")]
        [SerializeField] private Transform _portraitsParent;
        [SerializeField] private DialoguePortraitPrefab _portraitPrefab;

        private string _fileNames;
        private List<DialoguePortraitPrefab> _portraitPool;

        public string FileNames{
            set{
                _fileNames = value;
            }
        }
        
        private void Awake() {
            _portraitPool = new List<DialoguePortraitPrefab>();
        }

        public void Display()
        {
            string[] files = _fileNames.Split(',');
            
            // If there are no portraits or none, hide portrait and return right away
            if (files.Length <= 0 || _fileNames == DialogueTags.BLANK_VALUE)
            {
                Hide();
                return;
            }
            
            Hide(); // Hide previous portrait

            foreach (string filename in files)
            {
                Sprite portrait = Resources.Load<Sprite>($"Portraits/{filename}");
                DialoguePortraitPrefab portraitObject = GetOrCreatePortraitObject();

                portraitObject.gameObject.SetActive(true);
                portraitObject.PortraitSprite = portrait;
                portraitObject.PrefabSetup();
            }
        }

        public void Hide()
        {
            foreach (DialoguePortraitPrefab portrait in _portraitPool)
            {
                portrait.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Portrait manager object pooling
        /// </summary>
        /// <returns>Return existing portrait manager in hierarchy or create a new one</returns>
        private DialoguePortraitPrefab GetOrCreatePortraitObject()
        {
            DialoguePortraitPrefab portraitManager = _portraitPool.Find(portrait => !portrait.gameObject.activeInHierarchy);

            if (portraitManager == null)
            {
                portraitManager = Instantiate(_portraitPrefab, _portraitsParent).GetComponent<DialoguePortraitPrefab>();
                // Add new choice manager to pool 
                _portraitPool.Add(portraitManager);
            }
            
            portraitManager.gameObject.SetActive(false);

            return portraitManager;
        }
    }
}