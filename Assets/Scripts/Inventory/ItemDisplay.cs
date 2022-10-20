using TheDuction.Global.Effects;
using TheDuction.Interaction;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Inventory{
    public class ItemDisplay : MonoBehaviour
    {
        [SerializeField] private Text _itemNameText;
        [SerializeField] private Text _itemDescriptionText;
        [SerializeField] private Image _itemImage;
        [SerializeField] private CanvasGroup _itemDisplay;

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
            _itemName = clueData.InteractableName;
            _itemDescription = clueData.InteractableDescription;
            _itemSprite = clueData.ClueImage;
            
            SetObject();
        }
        
        private void SetObject()
        {
            StartCoroutine(AlphaFadingEffect.FadeIn(_itemDisplay));
            _itemNameText.text = _itemName;
            _itemDescriptionText.text = _itemDescription;
            _itemImage.sprite = _itemSprite;
        }

        public void ClosePanel(){
            StartCoroutine(AlphaFadingEffect.FadeOut(_itemDisplay));
        }
    }
}