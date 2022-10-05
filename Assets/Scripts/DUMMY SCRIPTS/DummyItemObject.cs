using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyItemObject : MonoBehaviour
{
    [SerializeField] private string _itemName;
    [SerializeField] private string _itemDescription;
    [SerializeField] private Sprite _itemSprite;
    
    public void SetObject(string name, string description, Sprite sprite)
    {
        _itemName = name;
        _itemDescription = description;
        _itemSprite = sprite;
    }
}
