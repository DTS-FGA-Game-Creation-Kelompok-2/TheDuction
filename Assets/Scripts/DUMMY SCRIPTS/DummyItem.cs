using TheDuction.Interaction;
using UnityEngine;

public class DummyItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string _itemName;
    
    public delegate void ItemAction(string itemName);
    public static event ItemAction OnItemAction;

    // private void OnMouseDown()
    // {
    //     OnItemAction?.Invoke(_itemName);
    //     gameObject.SetActive(false);
    // }

    public void Interact()
    {
        Debug.Log(_itemName + " was interacted");
        OnItemAction?.Invoke(_itemName);
        gameObject.SetActive(false);
    }
}
