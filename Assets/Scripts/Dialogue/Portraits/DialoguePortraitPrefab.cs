using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Dialogue.Portraits{
    public class DialoguePortraitPrefab : MonoBehaviour, IDialoguePropertiesPrefab
    {
        [SerializeField] private Image _portraitImage;

        private Sprite _portraitSprite;

        public Sprite PortraitSprite{
            set{
                _portraitSprite = value;
            }
        }

        public void PrefabSetup()
        {
            _portraitImage.sprite = _portraitSprite;
        }
    }
}