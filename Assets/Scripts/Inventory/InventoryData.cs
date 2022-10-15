using TheDuction.Interaction;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Inventory
{
    public class InventoryData : MonoBehaviour
    {
        [SerializeField] private ClueData _clueData;
        [SerializeField] private Image _itemImage;
        [SerializeField] private Button _itemButton;
        [SerializeField] private GameObject _itemPanel;
        
        public delegate void ButtonItemClicked(ClueData clueData);
        public static event ButtonItemClicked OnButtonClicked;

        private void Start()
        {
            _itemButton.onClick.AddListener(OnItemButtonClicked);
        }
        
        public void SetItemDetails(ClueData clueData, GameObject itemPanel)
        {
            _clueData = clueData;
            _itemImage.sprite = clueData.ClueImage;
            _itemPanel = itemPanel;
        }
        
        private void OnItemButtonClicked()
        {
            OpenItemPanel();
            OnButtonClicked?.Invoke(_clueData);
        }
        
        public void OpenItemPanel()
        {
            bool isActive = _itemPanel.activeSelf;
            _itemPanel.SetActive(!isActive);
        }
    }
}

