using System;
using System.Collections.Generic;
using TheDuction.Global.SaveLoad;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ClueData> _items = new List<ClueData>();
        [SerializeField] private InventoryData _itemsPrefab;
        [SerializeField] private Transform _itemsParent;

        private void OnEnable()
        {
            ClueInteractable.OnItemInteracted += AddItem;
        }

        private void OnDisable()
        {
            ClueInteractable.OnItemInteracted -= AddItem;
        }

        private void Start()
        {
            LoadItem();
        }

        private void LoadItem()
        {
            _items = SaveLoadData.Instance.Inventory;
            for (int i = 0; i < _items.Count; i++)
            {
                InventoryData itemObject = Instantiate(_itemsPrefab, _itemsParent);
                itemObject.SetItemDetails(_items[i]);
            }
        }

        public void AddItem(ClueData item)
        {
            _items.Add(item);
            InventoryData itemObject = Instantiate(_itemsPrefab, _itemsParent);
            itemObject.SetItemDetails(item);
        }
    }
}

