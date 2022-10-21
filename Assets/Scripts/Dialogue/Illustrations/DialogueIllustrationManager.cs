using TheDuction.Dialogue.Tags;
using TheDuction.Global;
using TheDuction.Global.Effects;
using UnityEngine;

namespace TheDuction.Dialogue.Illustrations{
    public class DialogueIllustrationManager : 
        SingletonBaseClass<DialogueIllustrationManager>, IDialoguePropertiesManager
    {
        [Header("Dialogue Illustration")]
        [SerializeField] private DialogueIllustrationPrefab _illustrationObject;
        [SerializeField] private Material blurMaterial;

        private string _fileName;

        public string FileName{
            set{
                _fileName = value;
            }
        }

        public void Display()
        {
            // If there are no portraits or none, hide portrait and return right away
            if (_fileName == DialogueTags.BLANK_VALUE)
            {
                Hide();
                return;
            }
            
            Hide(); // Hide previous illustration
            Sprite illustration = Resources.Load<Sprite>($"Illustrations/{_fileName}");

            _illustrationObject.gameObject.SetActive(true);
            _illustrationObject.IllustrationSprite = illustration;
            _illustrationObject.PrefabSetup();
        }

        public void BlurBackground(){
            _illustrationObject.IllustrationImage.material = blurMaterial;
        }

        private void ResetBlurEffect(){
            _illustrationObject.IllustrationImage.material = null;
        }

        public void Hide()
        {
            StartCoroutine(AlphaFadingEffect.FadeOut(_illustrationObject.IllustrationImage,
                afterEffect: () => _illustrationObject.gameObject.SetActive(false))
            );
            ResetBlurEffect();
        }
    }
}