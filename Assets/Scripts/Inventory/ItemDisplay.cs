using TheDuction.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Inventory{
    public class ItemDisplay : MonoBehaviour
    {
        [SerializeField] private Text _itemNameText;
        [SerializeField] private TextMeshProUGUI _itemDescriptionText;
        [SerializeField] private Image _itemImage;
        
        private string _itemName;
        private string _itemDescription;
        private Sprite _itemSprite;

        private void OnEnable()
        {
            InventoryData.OnButtonClicked += SetItemDetails;
        }

        private void OnDisable()
        {
            InventoryData.OnButtonClicked -= SetItemDetails;
        }

        private void SetItemDetails(ClueData clueData)
        {
            _itemName = clueData.ClueName;
            _itemDescription = clueData.ClueDescription;
            _itemSprite = clueData.ClueImage;
            
            SetObject();
        }
        
        private void SetObject()
        {
            _itemNameText.text = _itemName;
            _itemDescriptionText.text = _itemDescription;
            _itemImage.sprite = _itemSprite;
        }
    }
}