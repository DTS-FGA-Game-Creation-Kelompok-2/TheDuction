using System;
using System.Collections;
using System.Collections.Generic;
using TheDuction.Interaction;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ClueData> _items = new List<ClueData>();
        [SerializeField] private InventoryData _itemsPrefab;
        [SerializeField] private Transform _itemsParent;
        [SerializeField] private GameObject _itemDescPanel;

        private void OnEnable()
        {
            ClueInteractable.OnItemAction += AddItem;
        }

        private void OnDisable()
        {
            ClueInteractable.OnItemAction -= AddItem;
        }

        public void AddItem(ClueData item)
        {
            _items.Add(item);
            InventoryData itemObject = Instantiate(_itemsPrefab, _itemsParent);
            itemObject.SetItemDetails(item.ClueName, item.ClueImage, _itemDescPanel);
        }
    }
}

