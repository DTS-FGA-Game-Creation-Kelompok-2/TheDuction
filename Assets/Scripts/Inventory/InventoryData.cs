using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Inventory
{
    public class InventoryData : MonoBehaviour
    {
        [SerializeField] private string _itemName;
        [SerializeField] private Image _itemImage;
        [SerializeField] private Button _itemButton;
        [SerializeField] private GameObject _itemPanel;
        
        public delegate void ButtonItemClicked(string itemName);
        public static event ButtonItemClicked OnButtonClicked;

        private void Start()
        {
            _itemButton.onClick.AddListener(OnItemButtonClicked);
        }
        
        public void SetItemDetails(string itemName, Sprite itemImage, GameObject itemPanel)
        {
            _itemName = itemName;
            _itemImage.sprite = itemImage;
            _itemPanel = itemPanel;
        }
        
        private void OnItemButtonClicked()
        {
            OpenItemPanel();
            OnButtonClicked?.Invoke(_itemName);
        }
        
        public void OpenItemPanel()
        {
            bool isActive = _itemPanel.activeSelf;
            _itemPanel.SetActive(!isActive);
        }
    }
}

