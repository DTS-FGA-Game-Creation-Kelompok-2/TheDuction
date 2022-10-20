using System.Collections;
using System.Collections.Generic;
using TheDuction.Global.Effects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TheDuction.UI
{
    public class MainMenuScene : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _credittButton;
        [SerializeField] private CanvasGroup _settingCanvasGroup;
        
        [Header("Warning Pop Up Settings")]
        [SerializeField] private Button _warningPopUpYesButton;
        [SerializeField] private Button _warningPopUpNoButton;
        [SerializeField] private CanvasGroup _warningCanvasGroup;
        
        private const string SAVE_KEY = "save";
        private bool _isSetting = false;
        private bool _canProgress = false;
        
        private void Start()
        {
            SetupButton();
        }

        private void SetupButton()
        {
            _startButton.onClick.AddListener(StartGame);
            _resumeButton.onClick.AddListener(ResumeGame);
            _credittButton.onClick.AddListener(CreditGame);
            _settingButton.onClick.AddListener(SettingGame);
            _warningPopUpNoButton.onClick.AddListener(AbortWarning);
            _warningPopUpYesButton.onClick.AddListener(ConfirmWarning);
            
            if(PlayerPrefs.HasKey(SAVE_KEY))
            {
                _resumeButton.interactable = true;
                _canProgress = true;
            }
            else
            {
                _resumeButton.interactable = false;
                _canProgress = false;
            }
        }
        
        private void StartGame()
        {
            Debug.Log("Start Game");
            if (_canProgress)
            {
                StartCoroutine(AlphaFadingEffect.FadeIn(_warningCanvasGroup));
            }
            else
            {
                SceneManager.LoadScene("Gameplay");
            }
        }
        
        private void ResumeGame()
        {
            Debug.Log("Resume Game");
            SceneManager.LoadScene("Gameplay");
        }
        
        private void SettingGame()
        {
            Debug.Log("Setting Game");

            _isSetting = !_isSetting;
            if (_isSetting)
            {
                StartCoroutine(AlphaFadingEffect.FadeIn(_settingCanvasGroup));
            }
            else
            {
                StartCoroutine(AlphaFadingEffect.FadeOut(_settingCanvasGroup));
            }
        }
        
        private void CreditGame()
        {
            Debug.Log("Credit Game");
            SceneManager.LoadScene("Credits");
        }

        private void ConfirmWarning()
        {
            PlayerPrefs.DeleteKey(SAVE_KEY);
            SceneManager.LoadScene("Gameplay");
        }

        private void AbortWarning()
        {
            StartCoroutine(AlphaFadingEffect.FadeOut(_warningCanvasGroup));
        }
    }
}


