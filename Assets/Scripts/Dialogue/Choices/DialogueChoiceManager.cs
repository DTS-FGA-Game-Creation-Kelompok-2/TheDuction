using System.Collections.Generic;
using TheDuction.Global;
using UnityEngine;
using Ink.Runtime;
using TheDuction.Dialogue.Logs;

namespace TheDuction.Dialogue.Choices{
    public class DialogueChoiceManager :
        SingletonBaseClass<DialogueChoiceManager>, IDialoguePropertiesManager
    {
        [SerializeField] private Transform choicesParent;
        [SerializeField] private DialogueChoice choicePrefab;
        [SerializeField] private bool choiceMode;

        private List<DialogueChoice> choicePool;
        private DialogueLogManager dialogueLogManager;
        private DialogueManager dialogueManager;

        public bool ChoiceMode => choiceMode;

        private void Awake() {
            choicePool = new List<DialogueChoice>();
            dialogueLogManager = DialogueLogManager.Instance;
            dialogueManager = DialogueManager.Instance;
        }
        
        public void Display()
        {
            List<Choice> currentChoices = dialogueManager.CurrentStory.currentChoices;

            if (currentChoices.Count == 0) return;

            choiceMode = true;
            dialogueManager.PushDialogueMode(DialogueMode.Pause);
            foreach (Choice choice in currentChoices)
            {
                DialogueChoice choiceObject = GetOrCreateChoiceObject();
                choiceObject.gameObject.SetActive(true);
                // Set choice text
                choiceObject.SetChoiceText(choice.text);
                choiceObject.choiceIndex = choice.index;
            }
        }

        public void Hide()
        {
            foreach (DialogueChoice choiceManager in choicePool)
            {
                choiceManager.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Choice object pooling
        /// </summary>
        /// <returns>Return existing choice object in hierarchy or create a new one</returns>
        private DialogueChoice GetOrCreateChoiceObject()
        {
            DialogueChoice choiceObject = choicePool.Find(choice => !choice.gameObject.activeInHierarchy);

            if (choiceObject == null)
            {
                choiceObject = Instantiate(choicePrefab, choicesParent).GetComponent<DialogueChoice>();
                // Add new choice manager to pool 
                choicePool.Add(choiceObject);
            }
            
            choiceObject.gameObject.SetActive(false);

            return choiceObject;
        }

        /// <summary>
        /// Decide from multiple choice
        /// </summary>
        /// <param name="index">Choice's index</param>
        public void Decide(int index){
            if(dialogueManager.CurrentDialogueTypingState == DialogueTypingState.FinishTyping)
            {
                choiceMode = false;
                dialogueLogManager.AddDialogueLog("Yuri", 
                    dialogueManager.CurrentStory.currentChoices[index].text);
                dialogueManager.CurrentStory.ChooseChoiceIndex(index);
                dialogueManager.ContinueStory();
                dialogueManager.PopDialogueMode(DialogueMode.Pause);
            }
        }
    }
}