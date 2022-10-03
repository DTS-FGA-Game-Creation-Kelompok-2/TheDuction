using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Dialogue.Illustrations{
    public class DialogueIllustrationPrefab : MonoBehaviour, IDialoguePropertiesPrefab
    {
        [SerializeField] private Image _illustrationImage;
        private Sprite _illustrationSprite;

        public Image IllustrationImage => _illustrationImage;
        public Sprite IllustrationSprite{
            set{
                _illustrationSprite = value;
            }
        }
        
        public void PrefabSetup()
        {
            _illustrationImage.sprite = _illustrationSprite;
        }
    }
}