using System;
using System.Collections.Generic;
using System.Linq;
using TheDuction.Audios.SoundEffects;
using TheDuction.BackgroundMusics;
using TheDuction.Dialogue.Illustrations;
using TheDuction.Dialogue.Portraits;
using TheDuction.Event;
using TheDuction.Event.CameraEvent;
using TheDuction.Event.DialogueEvent;
using TheDuction.Event.MovementEvent;
using TheDuction.Global;
using TheDuction.Global.Effects;
using TheDuction.Quest;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TheDuction.Dialogue.Tags{
    public class DialogueTagManager: SingletonBaseClass<DialogueTagManager>{
        [SerializeField] private string _creditsSceneName = "Credits";
        [SerializeField] private TextMeshProUGUI _dayText;
        [SerializeField] private Image _blackScreen;

        private DialogueManager _dialogueManager;
        private DialogueIllustrationManager _dialogueIllustrationManager;
        private DialoguePortraitManager _dialoguePortraitManager;

        private void Awake(){
            _dialogueManager = DialogueManager.Instance;
            _dialogueIllustrationManager = DialogueIllustrationManager.Instance;
            _dialoguePortraitManager = DialoguePortraitManager.Instance;
        }

        public void HandleTags(List<string> dialogueTags){
            foreach (string dialogueTag in dialogueTags)
            {
                // Parse the tag
                string[] splitTag = dialogueTag.Split(':');

                if (splitTag.Length != 2)
                {
                    Debug.LogError("Tag could not be parsed: " + tag);
                }

                string tagKey = splitTag[0].Trim();
                string tagValue = splitTag[1].Trim();
                
                // Handle tag
                switch (tagKey)
                {
                    case DialogueTags.BGM_TAG:
                        BackgroundMusicManager.Instance.Play(tagValue);
                        break;
                    
                    case DialogueTags.DIALOGUE_BOX_TAG:
                        _dialogueManager.ShowOrHideDialogueBox(tagValue);
                        break;

                    case DialogueTags.END_CHAPTER_TAG:
                        HandleEndChapterTag(tagValue);
                        break;
                    
                    case DialogueTags.ENDING_TAG:
                        HandleEndingTag(tagValue);
                        break;
                    
                    case DialogueTags.EVENT_TAG:
                        SetEventData(tagValue);
                        break;

                    case DialogueTags.ILLUST_TAG:
                        _dialogueManager.ShowOrHideDialogueBox(DialogueTags.BLANK_VALUE);
                        _dialogueIllustrationManager.FileName = tagValue;
                        _dialogueIllustrationManager.Display();
                        break;

                    case DialogueTags.PORTRAIT_TAG:
                        _dialoguePortraitManager.FileName = tagValue;
                        _dialoguePortraitManager.Display();
                        break;

                    case DialogueTags.QUEST_TAG:
                        QuestManager.Instance.HandleQuestTag(tagValue);
                        break;

                    case DialogueTags.SFX_TAG:
                        SoundEffectManager.Instance.Play(tagValue);
                        break;
                    
                    case DialogueTags.SPEAKER_TAG:
                        _dialogueManager.HandleSpeakerTag(tagValue);
                        break;
                    
                    default:
                        Debug.LogError("Tag is not in the list: " + tag);
                        break;
                }
            }
        }

        private void HandleEndChapterTag(string tagValue)
        {
            StartCoroutine(AlphaFadingEffect.FadeIn(_blackScreen, afterEffect: () => {
                _dayText.text = tagValue;
                StartCoroutine(AlphaFadingEffect.FadeOut(_blackScreen));
            }));
        }

        /// <summary>
        /// Handle ending tag
        /// </summary>
        /// <param name="tagValue"></param>
        private void HandleEndingTag(string tagValue){
            // Handle ending tag
            if (tagValue != DialogueTags.CONFIRM_ENDING) return;

            StartCoroutine(AlphaFadingEffect.FadeIn(_blackScreen,
                fadingSpeed: 0.02f,
                afterEffect: () => SceneManager.LoadScene(_creditsSceneName)
            ));
        }

        /// <summary>
        /// Find event data in list
        /// </summary>
        /// <param name="eventDataName">Event data name</param>
        private void SetEventData(string tagValue){
            List<EventData> eventDatas = EventContainer.Instance.EventDatas;
            if(eventDatas.Count == 0) return;

            string[] eventIds = tagValue.Split(',');
            
            foreach(string eventId in eventIds){
                // Find event data in list
                foreach (EventData eventData in eventDatas.Where(
                    eventData => eventData.EventId == eventId))
                {
                    // Set event data
                    switch(eventData){
                        case DialogueEventData _:
                            Debug.Log("Set dialogue event");
                            DialogueEventManager.Instance.SetEventData(eventData);
                            break;
                        case CameraEventData _:
                            Debug.Log("Set camera event");
                            DialogueManager.Instance.PauseStoryForEvent();
                            CameraEventManager.Instance.SetEventData(eventData);
                            break;
                        case MovementEventData _:
                            DialogueManager.Instance.PauseStoryForEvent();
                            MovementEventManager.Instance.SetEventData(eventData);
                            break;
                        default:
                            Debug.LogError($"Event: {tagValue} can't be set. Check the event data class");
                            break;
                    }
                    
                    // eventData.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}