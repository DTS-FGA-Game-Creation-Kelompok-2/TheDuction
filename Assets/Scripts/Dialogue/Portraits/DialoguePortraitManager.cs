using TheDuction.Dialogue.Tags;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Dialogue.Portraits{
    public class DialoguePortraitManager :
        SingletonBaseClass<DialoguePortraitManager>, IDialoguePropertiesManager
    {
        [Header("Dialogue Portrait")]
        [SerializeField] private DialoguePortraitPrefab _portraitObject;

        private string _fileName;

        public string FileName{
            set{
                _fileName = value;
            }
        }

        public void Display()
        {
            // If file name is none, hide portrait and return right away
            if (_fileName == DialogueTags.BLANK_VALUE)
            {
                Hide();
                return;
            }
            
            Hide(); // Hide previous portrait
            Sprite portrait = Resources.Load<Sprite>($"Portraits/{_fileName}");

            _portraitObject.gameObject.SetActive(true);
            _portraitObject.PortraitSprite = portrait;
            _portraitObject.PrefabSetup();
        }

        public void Hide()
        {
            _portraitObject.gameObject.SetActive(false);
        }
    }
}