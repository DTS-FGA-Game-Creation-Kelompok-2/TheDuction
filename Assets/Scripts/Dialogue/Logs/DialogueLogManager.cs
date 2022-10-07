using System.Collections.Generic;
using TheDuction.Global;
using TheDuction.Global.Effects;
using UnityEngine;

namespace TheDuction.Dialogue.Logs{
    public class DialogueLogManager : 
        SingletonBaseClass<DialogueLogManager>, IDialoguePropertiesManager {
        [SerializeField] private CanvasGroup _dialogueLogCanvasGroup;
        [SerializeField] private DialogueLogPrefab _dialogueLogPrefab;
        [SerializeField] private Transform _dialogueLogParent;

        private const int MAX_POOL = 10;
        [SerializeField] private List<DialogueLogPrefab> _dialogueLogPool;
        private DialogueManager _dialogueManager;

        private void Awake() {
            _dialogueLogPool = new List<DialogueLogPrefab>();
            _dialogueManager = DialogueManager.Instance;
        }
        
        public void Display(){
            StartCoroutine(AlphaFadingEffect.FadeIn(_dialogueLogCanvasGroup,
                beforeEffect: () => _dialogueManager.PushDialogueMode(DialogueMode.ViewLog))
            );
        }

        public void Hide(){ 
            StartCoroutine(AlphaFadingEffect.FadeOut(_dialogueLogCanvasGroup,
                afterEffect: () => _dialogueManager.PopDialogueMode(DialogueMode.ViewLog))
            );
        }

        // TODO: Buat dialogue log
        /// <summary>
        /// Add dialogue log
        /// </summary>
        public void AddDialogueLog(string speakerNameValue, string dialogueTextValue){
            DialogueLogPrefab dialogueLogObject = GetOrCreateDialogueLog();
            dialogueLogObject.gameObject.SetActive(true);
            dialogueLogObject.SetupLog(speakerNameValue, dialogueTextValue);
            dialogueLogObject.PrefabSetup();
        }

        /// <summary>
        /// Reset dialogue log to empty
        /// </summary>
        public void ResetDialogueLog(){
            // Remove all logs 
            for (int i = _dialogueLogPool.Count; i >= MAX_POOL; i--)
            {
                DialogueLogPrefab dialogueLog = _dialogueLogPool[i];

                _dialogueLogPool.Remove(dialogueLog);
                Destroy(dialogueLog.gameObject);
            }

            foreach(DialogueLogPrefab dialogueLog in _dialogueLogPool){
                if(!dialogueLog.gameObject.activeInHierarchy) continue;

                dialogueLog.SetupLog("", "");
                dialogueLog.ResetPrefab();
                dialogueLog.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Dialogue Log object pooling
        /// </summary>
        /// <returns>Return existing dialogue log in hierarchy or create a new one</returns>
        private DialogueLogPrefab GetOrCreateDialogueLog(){
            DialogueLogPrefab dialogueLog = _dialogueLogPool.Find(log => 
                !log.gameObject.activeInHierarchy);

            if (dialogueLog == null)
            {
                dialogueLog = Instantiate(_dialogueLogPrefab, _dialogueLogParent).GetComponent<DialogueLogPrefab>();
                // Add new choice manager to pool 
                _dialogueLogPool.Add(dialogueLog);
            }
            
            dialogueLog.gameObject.SetActive(false);

            return dialogueLog;
        }
    }
}