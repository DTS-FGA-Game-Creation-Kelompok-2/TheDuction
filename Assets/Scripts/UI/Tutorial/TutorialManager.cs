using System;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialState _tutorialState;
    [SerializeField] private Button _nextButton;
    private int _currentPage = 0;
    [Header("UI Data")]
    [SerializeField] private Text _tutorialTitleText;
    [SerializeField] private Image _tutorialImage;
    
    [Header("Movement Tutorial Data")]
    [SerializeField] private string _movementTutorialTitle;
    [SerializeField] private Sprite _movementTutorialImage;
    
    [Header("Inventory Tutorial Data")]
    [SerializeField] private string _inventoryTutorialTitle;
    [SerializeField] private Sprite _inventoryTutorialImage;
    
    
    public enum TutorialState
    {
        Controller,
        Inventory,
        End
    }

    private void Start()
    {
        _nextButton.onClick.AddListener(NextPage);
    }

    private void Update()
    {
        TutorialStateChange(_tutorialState);
    }

    private void TutorialStateChange(TutorialState newState)
    {
        switch (newState)
        {
            case TutorialState.Controller:
                _tutorialTitleText.text = _movementTutorialTitle;
                _tutorialImage.sprite = _movementTutorialImage;
                break;
            case TutorialState.Inventory:
                _tutorialTitleText.text = _inventoryTutorialTitle;
                _tutorialImage.sprite = _inventoryTutorialImage;
                break;
            case TutorialState.End:
                _tutorialTitleText.text = "";
                _tutorialImage.sprite = null;
                this.gameObject.SetActive(false);
                break;
        }
    }

    private void InitEndTutorial()
    {
        _tutorialState = TutorialState.End;
    }

    private void NextPage()
    {
        // if(_currentPage == 0)
        // {
        //     _currentPage++;
        //     _tutorialState = TutorialState.Inventory;
        // }
        //
        // else if(_currentPage == 1)
        // {
        //     _currentPage++;
        //     InitEndTutorial();
        // }

        switch (_currentPage)
        {
            case 0:
                _currentPage++;
                _tutorialState = TutorialState.Inventory;
                break;
            case 1:
                InitEndTutorial();
                break;
        }
    }
}
