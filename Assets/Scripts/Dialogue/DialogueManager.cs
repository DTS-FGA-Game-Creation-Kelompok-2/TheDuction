using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using System.Collections;
using TheDuction.Global.Effects;
using TheDuction.Global;
using TheDuction.Dialogue.Choices;
using TheDuction.Dialogue.Logs;
using TheDuction.Dialogue.Portraits;
using TheDuction.Dialogue.Illustrations;
using TheDuction.Dialogue.Tags;
using TheDuction.Quest;
using TheDuction.Cameras;
using Cinemachine;

namespace TheDuction.Dialogue{
    public class DialogueManager: SingletonBaseClass<DialogueManager>{
        [Header("Dialogue States")]
        // Dialogue states
        [SerializeField] private DialogueState _currentDialogueState = DialogueState.Stop;
        [SerializeField] private DialogueMode _currentDialogueMode = DialogueMode.Normal;
        [SerializeField] private List<DialogueMode> _dialogueModeStackList;
        [SerializeField] private DialogueTypingState _currentDialogueTypingState = DialogueTypingState.FinishTyping;

        [Header("Dialogue Parameters")]
        // Dialogue details
        [SerializeField] private float _typingSpeed = 0.04f;
        [SerializeField] [Range(1f, 5f)] private float _autoModeDelay = 3f;

        [Header("Dialogue View")]
        [SerializeField] private CanvasGroup _dialogueCanvasGroup;
        [SerializeField] private GameObject _dialogueHolder;
        [SerializeField] private GameObject _dialogueTextBox;
        [SerializeField] private TextMeshProUGUI _dialogueText;
        [SerializeField] private Text _speakerName;

        [Header("Camera Manager")] 
        [SerializeField] private CinemachineVirtualCamera _dialogueVcam;

        [Header("Others")]
        [SerializeField] private TextAsset _currentDialogueAsset;
        private Story _currentStory;
        private Coroutine _displayLineCoroutine;
        private Coroutine _autoModeCoroutine;

        [Header("Singleton")]
        private CameraPriority _cameraPriority;
        private DialogueChoiceManager _dialogueChoiceManager;
        private DialogueIllustrationManager _dialogueIllustrationManager;
        private DialogueLogManager _dialogueLogManager;
        private DialoguePortraitManager _dialoguePortraitManager;
        private DialogueTagManager _dialogueTagManager;

        // Properties
        public bool CanAutoModeContinue { get; set; }
        public bool DialogueIsPlaying { get; private set; }
        public TextAsset CurrentDialogueAsset => _currentDialogueAsset;
        public Story CurrentStory => _currentStory;
        public DialogueState CurrentDialogueState => _currentDialogueState;
        public DialogueMode CurrentDialogueMode => _currentDialogueMode;
        public List<DialogueMode> DialogueModeStackList => _dialogueModeStackList;
        public DialogueTypingState CurrentDialogueTypingState => _currentDialogueTypingState;
        
        private void Awake(){
            // Singleton
            _cameraPriority = CameraPriority.Instance;
            _dialogueChoiceManager = DialogueChoiceManager.Instance;
            _dialogueIllustrationManager = DialogueIllustrationManager.Instance;
            _dialogueLogManager = DialogueLogManager.Instance;
            _dialoguePortraitManager = DialoguePortraitManager.Instance;
            _dialogueTagManager = DialogueTagManager.Instance;

            _dialogueModeStackList = new List<DialogueMode>();

            _dialogueCanvasGroup.interactable = true;
            _dialogueCanvasGroup.blocksRaycasts = false;
        }

        private void Start(){
            DialogueIsPlaying = false;
        }

        private void Update(){
            // Return if dialogue isn't playing
            if (!DialogueIsPlaying) return;

            /**
             * Use mouse button up to continue the story, handle dialogue log, and skip sentence
             * Handle dialogue log will trigger first if log button is clicked and will not trigger
                this if
             * Skip sentence will delay the finish typing after mouse button up, so it will not trigger
                this if
            */
            if (_currentDialogueMode == DialogueMode.Normal &&
                _currentDialogueTypingState == DialogueTypingState.FinishTyping &&
                _currentStory.currentChoices.Count == 0 &&
                Input.GetMouseButtonUp(0))
            {
                ContinueStory();
            }
            
            // If mouse button down and is typing, make player can skip dialogue sentence
            if (Input.GetMouseButtonDown(0) &&
                _currentDialogueMode == DialogueMode.Normal &&
                _currentDialogueTypingState == DialogueTypingState.Typing){
                _currentDialogueTypingState = DialogueTypingState.SkipSentence;
            }

            // If auto mode and can continue the auto mode, Start the auto mode
            if(CanAutoModeContinue && _currentDialogueMode == DialogueMode.AutoTyping){
                CanAutoModeContinue = false;
                _autoModeCoroutine = StartCoroutine(DialogueAutoMode());
            }
        }

        /// <summary>
        /// Push dialogue mode to stack list
        /// </summary>
        /// <param name="pushElement"></param>
        public void PushDialogueMode(DialogueMode pushElement){
            // Special case
            // If push element is auto typing and there are choices, ...
            if(pushElement == DialogueMode.AutoTyping && _dialogueChoiceManager.ChoiceMode){
                // Remove pause mode first
                int choiceIndex = _dialogueModeStackList.IndexOf(DialogueMode.Pause);
                _dialogueModeStackList.RemoveAt(choiceIndex);
                // Add auto first, then pause
                _dialogueModeStackList.Add(DialogueMode.AutoTyping);
                _dialogueModeStackList.Add(DialogueMode.Pause);
            } else{
                // Normal push
                _dialogueModeStackList.Add(pushElement);
            }
            // Get latest element in stack list
            _currentDialogueMode = _dialogueModeStackList[_dialogueModeStackList.Count - 1];
        }

        /// <summary>
        /// Pop dialogue mode from stack list
        /// </summary>
        /// <param name="popElement"></param>
        public void PopDialogueMode(DialogueMode popElement){
            // Check if the elements in stack list is greater than 1, ...
            if(_dialogueModeStackList.Count > 1){
                _dialogueModeStackList.Remove(popElement);
                // Get latest element
                _currentDialogueMode = _dialogueModeStackList[_dialogueModeStackList.Count - 1];
            }
        }

        /// <summary>
        /// Set dialogue by using dialogue inky file
        /// </summary>
        /// <param name="dialogueInk">Dialogue JSON file from Inky</param>
        public void SetDialogue(TextAsset dialogueInk)
        {
            _currentDialogueAsset = dialogueInk;
            _currentStory = new Story(dialogueInk.text);
            _currentDialogueState = DialogueState.Running;
            PushDialogueMode(DialogueMode.Normal);

            StartCoroutine(AlphaFadingEffect.FadeIn(_dialogueCanvasGroup,
                beforeEffect: () =>
                {
                    _cameraPriority.SetVirtualCameraPriority(_dialogueVcam, _cameraPriority.DIALOGUE_HIGHER_PRIORITY);

                    ContinueStory();
                }, 
                afterEffect: () => DialogueIsPlaying = true)
            );
        }

        /// <summary>
        /// Dialogue auto mode
        /// 1. Wait until finish typing
        /// 2. Delay in auto mode
        /// 3. Wait until current mode is auto typing
        /// 4. Continue the line
        /// </summary>
        /// <returns></returns>
        private IEnumerator DialogueAutoMode(){
            // Wait typing
            yield return new WaitUntil(() => _currentDialogueTypingState == DialogueTypingState.FinishTyping);
            // Delay
            yield return new WaitForSeconds(_autoModeDelay);
            // Wait auto typing mode
            yield return new WaitUntil(() => _currentDialogueMode == DialogueMode.AutoTyping);
            // Continue
            CanAutoModeContinue = true;
            ContinueStory();
        }

        /// <summary>
        /// Stop auto mode coroutine to prevent multiple calls
        /// </summary>
        public void StopAutoModeCoroutine(){
            if(_autoModeCoroutine != null){
                StopCoroutine(_autoModeCoroutine);
            }
        }
        
        /// <summary>
        /// Continue story dialogue
        /// </summary>
        public void ContinueStory()
        {
            if (_currentStory.canContinue)
            {
                // Set text for the current dialogue line
                if(_displayLineCoroutine != null)
                    StopCoroutine(_displayLineCoroutine);
                
                // Show sentence by each character
                string currentSentence = _currentStory.Continue();
                _displayLineCoroutine = StartCoroutine(DisplaySentence(currentSentence));
                
                // Handle tags in story
                _dialogueTagManager.HandleTags(_currentStory.currentTags);
                // Add dialogue log
                _dialogueLogManager.AddDialogueLog(_speakerName.text, currentSentence);
            }
            else
            {
                FinishDialogue();
            }
        }

        /// <summary>
        /// Pause the story and play other thing
        /// </summary>
        public void PauseStoryForEvent(){
            // Hide dialogue
            StartCoroutine(AlphaFadingEffect.FadeOut(_dialogueCanvasGroup,
                blocksRaycasts: true,
                fadingSpeed: 1f,
                beforeEffect: () => PushDialogueMode(DialogueMode.Pause),
                afterEffect: () => DialogueIsPlaying = false)
            );
        }

        /// <summary>
        /// Resume the story after pausing the story
        /// </summary>
        public void ResumeStoryForEvent(){
            // Show dialogue
            StartCoroutine(AlphaFadingEffect.FadeIn(_dialogueCanvasGroup,
                beforeEffect: () => DialogueIsPlaying = true,
                afterEffect: () => PopDialogueMode(DialogueMode.Pause))
            );
        }

        /// <summary>
        /// Actions when dialogue is finished
        /// </summary>
        private void FinishDialogue()
        {
            _currentDialogueState = DialogueState.Stop;
            StartCoroutine(AlphaFadingEffect.FadeOut(_dialogueCanvasGroup,
                beforeEffect: () =>{
                    _cameraPriority.SetVirtualCameraPriority(_dialogueVcam, _cameraPriority.LOWER_PRIORITY);
                },
                afterEffect: () =>
                {
                    // Auto mode
                    _dialogueModeStackList.RemoveRange(0, _dialogueModeStackList.Count);
                    CanAutoModeContinue = false;
                    // DialogueButtonManager.Instance.AutoModeState(false);
                    StopAutoModeCoroutine();

                    // Player
                    // Make player can move
                    // playerMovement.Movement.ChangeNavMeshQuality(
                    //     UnityEngine.AI.ObstacleAvoidanceType.LowQualityObstacleAvoidance);

                    // Dialogue UI
                    _dialogueLogManager.ResetDialogueLog();
                    _dialogueTextBox.SetActive(true);
                    DialogueIsPlaying = false;
                    _dialogueText.text = "";
                    _speakerName.text = "";
                    _dialogueChoiceManager.Hide();
                    _dialogueIllustrationManager.Hide();
                    _dialoguePortraitManager.Hide();
                })
            );
        }
        
        /// <summary>
        /// Display dialogue sentence letter by letter
        /// </summary>
        /// <param name="sentence">Current dialogue sentence</param>
        /// <returns></returns>
        private IEnumerator DisplaySentence(string sentence)
        {
            _dialogueText.text = ""; // Empty the dialogue text
            // Hide items while typing
            _dialogueChoiceManager.Hide();

            _currentDialogueTypingState = DialogueTypingState.Typing;
            bool isAddingRichTextTag = false;

            foreach (char letter in sentence)
            {
                // If there is right mouse click, finish the sentence right away
                if (_currentDialogueTypingState == DialogueTypingState.SkipSentence)
                {
                    _dialogueText.text = sentence;
                    // Wait until skip mode finish
                    // Skip mode is trigger with mouse down
                    yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                    // When mouse up, then change dialogue state to finish typing
                    _currentDialogueTypingState = DialogueTypingState.FinishTyping;
                    break;
                }

                // If found rich text tag, add it without waiting
                if (letter == '<' || isAddingRichTextTag)
                {
                    isAddingRichTextTag = true;
                    _dialogueText.text += letter;

                    if (letter == '>')
                        isAddingRichTextTag = false;
                } 
                // If not rich text, add letter and wait
                else
                {
                    // Type sentence by letter
                    _dialogueText.text += letter;
                    yield return new WaitForSeconds(_typingSpeed);
                }
            }

            _dialogueChoiceManager.Display();
            _currentDialogueTypingState = DialogueTypingState.FinishTyping;
        }

        /// <summary>
        /// Pause dialogue when opening setting
        /// </summary>
        public void PauseMode(CanvasGroup canvasGroup)
        {
            //Fade in
        }

        /// <summary>
        /// Resume dialogue when closing setting
        /// </summary>
        public void ResumeMode(CanvasGroup canvasGroup)
        {
            //Fade out
        }

        /// <summary>
        /// Show or hide dialogue box
        /// </summary>
        /// <param name="tagValue">tagValue = "show" to show. tagValue="none" to hide</param>
        public void ShowOrHideDialogueBox(string tagValue){
            switch(tagValue){
                case DialogueTags.BLANK_VALUE:
                    _dialogueTextBox.SetActive(false);
                    break;
                
                case DialogueTags.SHOW_DIALOGUE_BOX:
                    _dialogueTextBox.SetActive(true);
                    break;

                default:
                    Debug.LogError($"Tag: {tagValue} is not registered to handle dialogue box");
                    break;
            }
        }

        /// <summary>
        /// Handle speaker name in dialogue
        /// </summary>
        /// <param name="tagValue">Speaker name. "none" to make speaker name doesn't appear</param>
        public void HandleSpeakerTag(string tagValue){
            string speakerName = tagValue == DialogueTags.BLANK_VALUE ? "" : tagValue;
            _speakerName.text = speakerName;
        }
    }
}