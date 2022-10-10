using UnityEngine;
using UnityEngine.UI;


namespace TheDuction.UI
{
    public class GameplayScene : MonoBehaviour
    {
        [SerializeField] private Button _inventoryButton;
        [SerializeField] private Button _closeInventoryButton;
        [SerializeField] private GameObject _inventoryPanel;
        
        private void Start()
        {
            _inventoryButton.onClick.AddListener(OpenInventory);
            _closeInventoryButton.onClick.AddListener(OpenInventory);
        }

        private void OpenInventory()
        {
            bool isActive = _inventoryPanel.activeSelf;
            _inventoryPanel.SetActive(!isActive);
        }
    }
}

