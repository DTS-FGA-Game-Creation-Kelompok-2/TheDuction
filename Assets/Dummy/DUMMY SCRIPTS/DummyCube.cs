using System.Collections;
using System.Collections.Generic;
using TheDuction.Interaction;
using UnityEngine;

public class DummyCube : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with " + transform.name);
    }
}
