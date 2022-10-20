using System;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialState _tutorialState;
    
    public enum TutorialState
    {
        Move,
        Interact,
        Inventory,
        End
    }

    private void Update()
    {
        TutorialStateChange(_tutorialState);
    }

    private void TutorialStateChange(TutorialState newState)
    {
        switch (newState)
        {
            case TutorialState.Move:
                Debug.Log("Move tutorial");
                break;
            case TutorialState.Interact:
                Debug.Log("Interact tutorial");
                break;
            case TutorialState.Inventory:
                Debug.Log("Inventory tutorial");
                break;
            case TutorialState.End:
                Debug.Log("End tutorial");
                break;
        }
    }

    private void InitMoveTutorial()
    {
        TutorialStateChange(TutorialState.Move);
    }
    
    private void InitInteractTutorial()
    {
        TutorialStateChange(TutorialState.Interact);
    }
    
    private void InitInventoryTutorial()
    {
        TutorialStateChange(TutorialState.Inventory);
    }
    
    private void InitEndTutorial()
    {
        TutorialStateChange(TutorialState.End);
    }
}
