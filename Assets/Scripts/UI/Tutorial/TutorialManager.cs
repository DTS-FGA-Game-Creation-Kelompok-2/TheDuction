using System.Collections;
using TheDuction.Dialogue;
using TheDuction.Global;
using TheDuction.Global.Effects;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : SingletonBaseClass<TutorialManager>
{
    [SerializeField] private CanvasGroup _tutorialCanvas;
    [SerializeField] private TutorialState _tutorialState;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Sprite _closeSprite;
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

    public IEnumerator TriggerTutorial(){
        yield return new WaitUntil(() => DialogueManager.Instance.CurrentDialogueState == DialogueState.Stop);
        TutorialStateChange(_tutorialState);
        Debug.Log("trigger");
        StartCoroutine(AlphaFadingEffect.FadeIn(_tutorialCanvas));
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
                _nextButton.GetComponent<Image>().sprite = _closeSprite;
                break;
            case TutorialState.End:
                _tutorialTitleText.text = "";
                _tutorialImage.sprite = null;
                gameObject.SetActive(false);
                break;
        }
    }

    private void NextPage()
    {
        switch (_currentPage)
        {
            case 0:
                _currentPage++;
                _tutorialState = TutorialState.Inventory;
                TutorialStateChange(_tutorialState);
                break;
            case 1:
                _tutorialState = TutorialState.End;
                TutorialStateChange(_tutorialState);
                break;
        }
    }
}
