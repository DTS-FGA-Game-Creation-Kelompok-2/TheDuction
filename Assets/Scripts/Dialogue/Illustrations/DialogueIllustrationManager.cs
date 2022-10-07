using System.Collections.Generic;
using TheDuction.Dialogue.Tags;
using TheDuction.Global;
using TheDuction.Global.Effects;
using UnityEngine;

namespace TheDuction.Dialogue.Illustrations{
    public class DialogueIllustrationManager : 
        SingletonBaseClass<DialogueIllustrationManager>, IDialoguePropertiesManager
    {
        [Header("Dialogue Illustration")]
        [SerializeField] private Transform _illustrationParent;
        [SerializeField] private DialogueIllustrationPrefab _illustrationPrefab;

        private string _fileNames;
        private List<DialogueIllustrationPrefab> _illustrationPool;

        public string FileNames{
            set{
                _fileNames = value;
            }
        }

        private void Awake() {
            _illustrationPool = new List<DialogueIllustrationPrefab>();
        }

        public void Display()
        {
            string[] files = _fileNames.Split(',');
            
            // If there are no portraits or none, hide portrait and return right away
            if (files.Length <= 0 || _fileNames == DialogueTags.BLANK_VALUE)
            {
                Hide();
                return;
            }
            
            Hide(); // Hide previous illustration

            foreach (string filename in files)
            {
                Sprite illustration = Resources.Load<Sprite>($"Illustrations/{filename}");
                DialogueIllustrationPrefab illustrationObject = GetOrCreateDialogueIllustrationObject();

                illustrationObject.gameObject.SetActive(true);
                illustrationObject.IllustrationSprite = illustration;
                illustrationObject.PrefabSetup();
            }
        }

        public void Hide()
        {
            foreach (DialogueIllustrationPrefab illustration in _illustrationPool)
            {
                StartCoroutine(AlphaFadingEffect.FadeOut(illustration.IllustrationImage,
                    afterEffect: () => illustration.gameObject.SetActive(false))
                );
            }
        }

        /// <summary>
        /// Illustration object pooling
        /// </summary>
        /// <returns>Return existing illustration in hierarchy or create a new one</returns>
        private DialogueIllustrationPrefab GetOrCreateDialogueIllustrationObject()
        {
            DialogueIllustrationPrefab dialogueIllustration = _illustrationPool.Find(illustrtation => 
                !illustrtation.gameObject.activeInHierarchy);

            if (dialogueIllustration == null)
            {
                dialogueIllustration = Instantiate(_illustrationPrefab, _illustrationParent).GetComponent<DialogueIllustrationPrefab>();
                // Add new choice object to pool 
                _illustrationPool.Add(dialogueIllustration);
            }
            
            dialogueIllustration.gameObject.SetActive(false);

            return dialogueIllustration;
        }
    }
}