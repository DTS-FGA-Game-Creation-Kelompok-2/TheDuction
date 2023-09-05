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

        public delegate void ButtonItemClicked(ClueData clueData);
        public static event ButtonItemClicked OnButtonClicked;

        private void Start()
        {
            _itemButton.onClick.AddListener(OnItemButtonClicked);
        }
        
        public void SetItemDetails(ClueData clueData)
        {
            _clueData = clueData;
            _itemImage.sprite = clueData.ClueImageSmall;
            _itemImage.SetNativeSize();
        }
        
        private void OnItemButtonClicked()
        {
            OnButtonClicked?.Invoke(_clueData);
        }
    }
}

