using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<string> _items = new List<string>();
        [SerializeField] private InventoryData _itemsPrefab;
        [SerializeField] private Transform _itemsParent;
        [SerializeField] private GameObject _itemDescPanel;

        private void OnEnable()
        {
            DummyItemObject.OnItemAction += AddItem;
        }

        private void OnDisable()
        {
            DummyItemObject.OnItemAction -= AddItem;
        }

        public void AddItem(string item)
        {
            _items.Add(item);
            InventoryData itemObject = Instantiate(_itemsPrefab, _itemsParent);
            ClueData clueData = Resources.Load<ClueData>("Items Data/" + item);
            itemObject.SetItemDetails(item, clueData.ClueImage, _itemDescPanel);
        }
    }
}

