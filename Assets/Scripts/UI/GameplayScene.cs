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

        private void Start()
        {
            _inventoryButton.onClick.AddListener(OpenInventory);
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
    }
}

