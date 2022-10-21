using System;
using TheDuction.Audios;

namespace TheDuction.BackgroundMusics{
    public enum ListBackgroundMusic{
        DefaultBGM,
        PrologBGM,
        MainMenuBGM,
    }
    
    [Serializable]
    public class BackgroundMusic: Sound {
        public ListBackgroundMusic listBackgroundMusic;
    }
}