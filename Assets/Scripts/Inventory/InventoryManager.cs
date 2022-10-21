using System.Collections.Generic;
using TheDuction.Global;
using TheDuction.Global.SaveLoad;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Inventory
{
    public class InventoryManager : SingletonBaseClass<InventoryManager>
    {
        [SerializeField] private List<ClueData> _items;
        [SerializeField] private InventoryData _itemsPrefab;
        [SerializeField] private Transform _itemsParent;

        private void Awake() {
            _items = new List<ClueData>();
        }

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
            if(!SaveLoadData.Instance) return;
            
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

