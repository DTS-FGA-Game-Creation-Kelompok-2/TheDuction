using TheDuction.Interaction;
using TheDuction.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DummyItemDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemDescriptionText;
    [SerializeField] private TextMeshProUGUI _itemNameText;
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

    public void SetItemDetails(string itemName)
    {
        ClueData clueData = Resources.Load<ClueData>("Items Data/" + itemName);

        _itemName = clueData.ClueName;
        _itemDescription = clueData.ClueDescription;
        _itemSprite = clueData.ClueImage;
        
        SetObject();
    }
    
    public void SetObject()
    {
        _itemNameText.text = _itemName;
        _itemDescriptionText.text = _itemDescription;
        _itemImage.sprite = _itemSprite;
    }
    
    
}
