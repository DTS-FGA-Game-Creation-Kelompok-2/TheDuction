using TheDuction.Interaction;
using UnityEngine;

public class DummyItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string _itemName;
    
    public delegate void ItemAction(string itemName);
    public static event ItemAction OnItemAction;

    public void Interact()
    {
        OnItemAction?.Invoke(_itemName);
        gameObject.SetActive(false);
    }
}
