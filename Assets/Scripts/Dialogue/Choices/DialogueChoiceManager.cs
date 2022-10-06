using System.Collections.Generic;
using TheDuction.Global;
using UnityEngine;
using Ink.Runtime;
using TheDuction.Dialogue.Logs;

namespace TheDuction.Dialogue.Choices{
    public class DialogueChoiceManager :
        SingletonBaseClass<DialogueChoiceManager>, IDialoguePropertiesManager
    {
        [SerializeField] private Transform _choicesParent;
        [SerializeField] private DialogueChoicePrefab _choicePrefab;
        [SerializeField] private bool _choiceMode;

        private List<DialogueChoicePrefab> _choicePool;
        private DialogueLogManager _dialogueLogManager;
        private DialogueManager _dialogueManager;

        public bool ChoiceMode => _choiceMode;

        private void Awake() {
            _choicePool = new List<DialogueChoicePrefab>();
            _dialogueLogManager = DialogueLogManager.Instance;
            _dialogueManager = DialogueManager.Instance;
        }
        
        public void Display()
        {
            List<Choice> currentChoices = _dialogueManager.CurrentStory.currentChoices;

            if (currentChoices.Count == 0) return;

            _choiceMode = true;
            _dialogueManager.PushDialogueMode(DialogueMode.Pause);
            foreach (Choice choice in currentChoices)
            {
                DialogueChoicePrefab choiceObject = GetOrCreateChoiceObject();
                choiceObject.gameObject.SetActive(true);
                // Set choice text
                choiceObject.SetChoiceText(choice.text);
                choiceObject.choiceIndex = choice.index;
                choiceObject.PrefabSetup();
            }
        }

        public void Hide()
        {
            foreach (DialogueChoicePrefab choiceManager in _choicePool)
            {
                choiceManager.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Choice object pooling
        /// </summary>
        /// <returns>Return existing choice object in hierarchy or create a new one</returns>
        private DialogueChoicePrefab GetOrCreateChoiceObject()
        {
            DialogueChoicePrefab choiceObject = _choicePool.Find(choice => !choice.gameObject.activeInHierarchy);

            if (choiceObject == null)
            {
                choiceObject = Instantiate(_choicePrefab, _choicesParent).GetComponent<DialogueChoicePrefab>();
                // Add new choice manager to pool 
                _choicePool.Add(choiceObject);
            }
            
            choiceObject.gameObject.SetActive(false);

            return choiceObject;
        }

        /// <summary>
        /// Decide from multiple choice
        /// </summary>
        /// <param name="index">Choice's index</param>
        public void Decide(int index){
            if(_dialogueManager.CurrentDialogueTypingState == DialogueTypingState.FinishTyping)
            {
                _choiceMode = false;
                _dialogueLogManager.AddDialogueLog("Saya", 
                    _dialogueManager.CurrentStory.currentChoices[index].text);
                _dialogueManager.CurrentStory.ChooseChoiceIndex(index);
                _dialogueManager.ContinueStory();
                _dialogueManager.PopDialogueMode(DialogueMode.Pause);
            }
        }
    }
}