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
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _credittButton;
        [SerializeField] private Button _closeSettingButton;
        [SerializeField] private CanvasGroup _settingCanvasGroup;
        
        private bool _isSetting = false;
        
        private void Start()
        {
            SetupButton();
        }

        private void SetupButton()
        {
            _exitButton.onClick.AddListener(ExitGame);
            _startButton.onClick.AddListener(StartGame);
            _credittButton.onClick.AddListener(CreditGame);
            _settingButton.onClick.AddListener(SettingGame);
            _closeSettingButton.onClick.AddListener(SettingGame);
        }
        
        private void StartGame()
        {
            SceneManager.LoadScene("Gameplay");
        }
        
        private void SettingGame()
        {
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
            SceneManager.LoadScene("Credits");
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}


