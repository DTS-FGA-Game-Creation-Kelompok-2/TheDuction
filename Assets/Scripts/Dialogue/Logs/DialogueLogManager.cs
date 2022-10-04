using TheDuction.Global;
using TheDuction.Global.Effects;
using UnityEngine;

namespace TheDuction.Dialogue.Logs{
    public class DialogueLogManager : 
        SingletonBaseClass<DialogueLogManager>, IDialoguePropertiesManager {
        [SerializeField] private CanvasGroup _dialogueLogCanvasGroup;
        [SerializeField] private DialogueLogPrefab _dialogueLogPrefab;
        [SerializeField] private Transform _dialogueLogParent;

        private DialogueManager _dialogueManager;

        private void Awake() {
            _dialogueManager = DialogueManager.Instance;
        }

        /// <summary>
        /// Add dialogue log
        /// </summary>
        public void AddDialogueLog(string speakerNameValue, string dialogueTextValue){
            DialogueLogPrefab dialogueLogObject = Instantiate(_dialogueLogPrefab, _dialogueLogParent);
            dialogueLogObject.SetupLog(speakerNameValue, dialogueTextValue);
            dialogueLogObject.PrefabSetup();
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
    }
}