using System.Collections;
using System.Collections.Generic;
using TheDuction.Global.Effects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TheDuction.Credits{
    public class CreditsView : MonoBehaviour {
        [SerializeField] private string _mainMenuSceneName = "MainMenu";
        [Range(0, 10)]
        [SerializeField] private float _creditDuration = 3f;
        [Range(0, 5)]
        [SerializeField] private float _betweenCreditDuration = 1f;

        [Header("Credit UI")]
        [SerializeField] private Image _creditBackgroundImage;
        [SerializeField] private CanvasGroup _creditCanvasGroup;
        [SerializeField] private Text _titleText, _bodyText;

        private void Start() {
            SetCreditImage();
            StartCoroutine(AnimateCredits(CreditsManager.Instance.CreditList));
        }

        private void SetCreditImage(){
            _creditBackgroundImage.sprite = CreditsManager.Instance.CreditBackgroundSprite;
            _creditBackgroundImage.SetNativeSize();
        }
        
        /// <summary>
        /// Animate credits
        /// </summary>
        /// <returns></returns>
        private IEnumerator AnimateCredits(List<Credit> creditList)
        {
            // Loop through credits
            for (int i = 0; i < creditList.Count; i++)
            {
                Credit credit = creditList[i];

                // Fade in
                StartCoroutine(AlphaFadingEffect.FadeIn(_creditCanvasGroup,
                    beforeEffect: () =>
                    {
                        _titleText.text = credit.Title;
                        _bodyText.text = credit.body;
                    })
                );
                // Wait
                yield return new WaitForSeconds(_creditDuration);

                // Fade out
                StartCoroutine(AlphaFadingEffect.FadeOut(_creditCanvasGroup,
                    afterEffect: () =>
                    {
                        _titleText.text = "";
                        _bodyText.text = "";
                    })
                );

                yield return new WaitForSeconds(_betweenCreditDuration);
            }

            SceneManager.LoadScene(_mainMenuSceneName);
        }
    }
}