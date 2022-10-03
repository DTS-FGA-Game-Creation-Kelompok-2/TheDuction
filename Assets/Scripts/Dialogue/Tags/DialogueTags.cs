using UnityEngine;

namespace TheDuction.Dialogue.Tags{
    public static class DialogueTags{
        [Header("Tags")]
        public const string BGM_TAG = "bgm";
        public const string DIALOGUE_BOX_TAG = "dialogue-box";
        public const string ENDING_TAG = "end";
        public const string EVENT_TAG = "event";
        public const string ILLUST_TAG = "illust";
        public const string PORTRAIT_TAG = "portrait";
        public const string QUEST_TAG = "quest";
        public const string SFX_TAG = "sfx";
        public const string SPEAKER_TAG = "speaker";

        [Header("Tag Value")]
        public const string BLANK_VALUE = "none";
        [Header("Tag: dialogue-box")]
        public const string SHOW_DIALOGUE_BOX = "show";
        [Header("Tag: ending")]
        public const string CONFIRM_ENDING = "true";
    }
}