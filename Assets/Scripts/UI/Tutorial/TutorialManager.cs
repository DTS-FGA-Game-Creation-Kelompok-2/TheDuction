using System;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialState _tutorialState;
    [SerializeField] private Text _tutorialTitleText;
    [SerializeField] private Text _tutorialDescriptionText;
    [SerializeField] private Image _tutorialImage;
    
    
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
                _tutorialTitleText.text = "Move";
                _tutorialDescriptionText.text = "Use WASD to move";
                // _tutorialImage.sprite = Resources.Load<Sprite>("Sprites/Move");
                break;
            case TutorialState.Interact:
                _tutorialTitleText.text = "Interact";
                _tutorialDescriptionText.text = "Press E to interact";
                // _tutorialImage.sprite = Resources.Load<Sprite>("Sprites/Interact");
                break;
            case TutorialState.Inventory:
                _tutorialTitleText.text = "Inventory";
                _tutorialDescriptionText.text = "Press I to open inventory";
                // _tutorialImage.sprite = Resources.Load<Sprite>("Sprites/Inventory");
                break;
            case TutorialState.End:
                _tutorialTitleText.text = "";
                _tutorialDescriptionText.text = "";
                // _tutorialImage.sprite = Resources.Load<Sprite>("Sprites/End");
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
