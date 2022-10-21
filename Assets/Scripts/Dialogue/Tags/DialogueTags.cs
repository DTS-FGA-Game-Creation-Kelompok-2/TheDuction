using UnityEngine;

namespace TheDuction.Dialogue.Tags{
    public static class DialogueTags{
        [Header("Tags")]
        public const string BGM_TAG = "bgm";
        public const string DIALOGUE_BOX_TAG = "dialogue-box";
        public const string EFFECT_TAG = "effect";
        public const string ENDING_TAG = "end";
        public const string END_CHAPTER_TAG = "end-chapter";
        public const string EVENT_TAG = "event";
        public const string ILLUST_TAG = "illust";
        public const string PORTRAIT_TAG = "portrait";
        public const string QUEST_TAG = "quest";
        public const string SFX_TAG = "sfx";
        public const string SPEAKER_TAG = "speaker";
        public const string TUTORIAL = "tutorial";

        [Header("Tag Value")]
        public const string BLANK_VALUE = "none";
        [Header("Tag: effect")]
        public const string BLUR_EFFECT = "illust-blur";
        public const string FADE_IN_OUT = "fade-in-out";
        [Header("Tag: dialogue-box")]
        public const string SHOW_DIALOGUE_BOX = "show";
        [Header("Tag: ending")]
        public const string CONFIRM = "true";
    }
}