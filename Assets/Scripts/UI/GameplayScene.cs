using TheDuction.Dialogue;
using TheDuction.Global.Effects;
using UnityEngine;
using UnityEngine.UI;


namespace TheDuction.UI
{
    public class GameplayScene : MonoBehaviour
    {
        [Header("Dialogue")]
        [SerializeField] private Button _viewButton;
        [SerializeField] private Button _viewLogButton, _autoButton, _hideLogButton;
        [SerializeField] private Image _autoButtonImage;
        [SerializeField] private Sprite _autoModeOn, _autoModeOff;
        [SerializeField] private CanvasGroup _dialogueElementsCanvasGroup, _dialogueLogCanvasGroup;
        private bool _isAuto;
        private DialogueManager _dialogueManager;
        
        [Header("Inventory")]
        [SerializeField] private Button _inventoryButton;
        [SerializeField] private Button _closeInventoryButton;
        [SerializeField] private RectTransform _inventoryHolderTransform;
        [SerializeField] private Image _blurInventoryBackground;
        [SerializeField] private CanvasGroup _itemDisplay;
        private bool _isInventoryOpen;

        [Header("Pause")]
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private CanvasGroup _pausePanel;
        private bool _openPausePanel;

        private void Awake() {
            _dialogueManager = DialogueManager.Instance;
        }

        private void Start()
        {
            // Inventory
            _inventoryButton.onClick.AddListener(OpenInventory);
            _closeInventoryButton.onClick.AddListener(CloseInventory);

            // Pause
            _pauseButton.onClick.AddListener(OpenPausePanel);
            _resumeButton.onClick.AddListener(OpenPausePanel);

            // Dialogue
            _viewButton.onClick.AddListener(HideDialogue);
            _autoButton.onClick.AddListener(AutoModeButton);
            _viewLogButton.onClick.AddListener(ShowDialogueLog);
            _hideLogButton.onClick.AddListener(HideDialogueLog);
        }

        private void Update() {
            // If there is left-click and current mode is hide mode, show the dialogue again
            if(Input.GetMouseButtonDown(0) && _dialogueManager.CurrentDialogueMode == DialogueMode.HideMode){
                ShowDialogue();
            }
        }

        #region Dialogue

        /// <summary>
        /// Hide the dialogue elements to show the portraits only
        /// </summary>
        private void HideDialogue(){
            StartCoroutine(AlphaFadingEffect.FadeOut(_dialogueElementsCanvasGroup,
                beforeEffect: () => {
                    _dialogueManager.PushDialogueMode(DialogueMode.HideMode);
                    _pauseButton.gameObject.SetActive(false);
                })
            );
        }
        
        /// <summary>
        /// Show the dialogue elements after hiding it
        /// </summary>
        private void ShowDialogue(){
            StartCoroutine(AlphaFadingEffect.FadeIn(_dialogueElementsCanvasGroup,
                afterEffect: () => {
                    _dialogueManager.PopDialogueMode(DialogueMode.HideMode);
                    _pauseButton.gameObject.SetActive(true);
                })
            );
        }

        private void ShowDialogueLog(){
            StartCoroutine(AlphaFadingEffect.FadeIn(_dialogueLogCanvasGroup));
        }

        private void HideDialogueLog(){
            StartCoroutine(AlphaFadingEffect.FadeOut(_dialogueLogCanvasGroup));
        }

        /// <summary>
        /// Auto mode button handler
        /// </summary>
        private void AutoModeButton(){
            _isAuto = !_isAuto;
            AutoModeState(_isAuto);
        }

        /// <summary>
        /// Auto mode state actions
        /// </summary>
        /// <param name="isAuto"></param>
        private void AutoModeState(bool isAuto){
            _isAuto = isAuto;

            // If is in auto mode, ...
            if(isAuto){
                _dialogueManager.CanAutoModeContinue = true;
                _dialogueManager.PushDialogueMode(DialogueMode.AutoTyping);
                // Change the sprite of auto button image
                _autoButtonImage.sprite = _autoModeOn;
            } else{
                _dialogueManager.CanAutoModeContinue = false;
                _dialogueManager.PopDialogueMode(DialogueMode.AutoTyping);
                // Stop the coroutine to prevent multiple calls
                _dialogueManager.StopAutoModeCoroutine();
                // Change the sprite of auto button image
                _autoButtonImage.sprite = _autoModeOff;
            }
        }

        #endregion

        #region Inventory

        private void OpenInventory()
        {
            _isInventoryOpen = !_isInventoryOpen;
            Vector2 inventoryHolderPos = _inventoryHolderTransform.anchoredPosition;
            _inventoryHolderTransform.anchoredPosition = new Vector2(
                -1 * inventoryHolderPos.x, inventoryHolderPos.y
            );

            _blurInventoryBackground.enabled = _isInventoryOpen;
        }

        public void CloseInventory(){
            StartCoroutine(AlphaFadingEffect.FadeOut(_itemDisplay));
        }

        #endregion

        #region Pause

        private void OpenPausePanel(){
            _openPausePanel = !_openPausePanel;
            
            if(_openPausePanel)
                StartCoroutine(AlphaFadingEffect.FadeIn(_pausePanel));
            else
                StartCoroutine(AlphaFadingEffect.FadeOut(_pausePanel));
        }
        
        #endregion
    }
}

