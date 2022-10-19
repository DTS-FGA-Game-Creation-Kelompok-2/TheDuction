using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public enum TutorialState
    {
        Move,
        Interact,
        Inventory,
        End
    }
    
    private void TutorialStateChange(TutorialState newState)
    {
        switch (newState)
        {
            case TutorialState.Move:
                break;
            case TutorialState.Interact:
                break;
            case TutorialState.Inventory:
                break;
            case TutorialState.End:
                break;
        }
    }
}
