using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDuction.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<string> _items = new List<string>();
        
        public void AddItem(string item)
        {
            _items.Add(item);
        }
    }
}

