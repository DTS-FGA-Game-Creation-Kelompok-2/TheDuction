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
        [SerializeField] private GameObject _itemsPrefab;
        [SerializeField] private Transform _itemsParent;

        private void OnEnable()
        {
            DummyItem.OnItemAction += AddItem;
        }

        private void OnDisable()
        {
            DummyItem.OnItemAction -= AddItem;
        }

        public void AddItem(string item)
        {
            _items.Add(item);
            GameObject itemObject = Instantiate(_itemsPrefab, _itemsParent);
            ClueData clueData = Resources.Load<ClueData>("Items Data/" + item);
            itemObject.GetComponent<Image>().sprite = clueData.ClueImage;
        }
    }
}

