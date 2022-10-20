using TheDuction.Global.Effects;
using UnityEngine;
using UnityEngine.UI;


namespace TheDuction.UI
{
    public class GameplayScene : MonoBehaviour
    {
        [Header("Inventory")]
        [SerializeField] private Button _inventoryButton;
        [SerializeField] private Button _closeInventoryButton;
        [SerializeField] private RectTransform _inventoryHolderTransform;
        [SerializeField] private Image _blurInventoryBackground;
        private bool _isInventoryOpen;

        [Header("Pause")]
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private CanvasGroup _pausePanel;
        private bool _openPausePanel;

        private void Start()
        {
            _inventoryButton.onClick.AddListener(OpenInventory);
            _pauseButton.onClick.AddListener(OpenPausePanel);
            _resumeButton.onClick.AddListener(OpenPausePanel);
        }

        private void OpenInventory()
        {
            _isInventoryOpen = !_isInventoryOpen;
            Vector2 inventoryHolderPos = _inventoryHolderTransform.anchoredPosition;
            _inventoryHolderTransform.anchoredPosition = new Vector2(
                -1 * inventoryHolderPos.x, inventoryHolderPos.y
            );

            _blurInventoryBackground.enabled = _isInventoryOpen;
        }

        private void OpenPausePanel(){
            _openPausePanel = !_openPausePanel;
            
            if(_openPausePanel)
                StartCoroutine(AlphaFadingEffect.FadeIn(_pausePanel));
            else
                StartCoroutine(AlphaFadingEffect.FadeOut(_pausePanel));
        }
    }
}

