using System.Collections;
using System.Collections.Generic;
using TheDuction.Interaction;
using UnityEngine;

public class DummyNPC : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with DummyNPC " + transform.name);
    }
}
