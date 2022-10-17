using System;
using TheDuction.Audios;

namespace TheDuction.BackgroundMusics{
    public enum ListBackgroundMusic{
        MainMenuBGM,
    }
    
    [Serializable]
    public class BackgroundMusic: Sound {
        public ListBackgroundMusic listBackgroundMusic;
    }
}