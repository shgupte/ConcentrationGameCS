
using System.ComponentModel;

public static class Constants {

    public static class GameConstants {
        public const int kCardHeight = 36;
        public const int kCardWidth = 25;

        //Should be able to get rid of this scaling crap soon with the RenderTarget2D
        
        public const int kCardScale = 1;

        public const int kButtonScale = 1;
    }

    public static class DisplayConstants {

        //The ones labeled display are actually used for rendering
        public const int kDisplayHeight = 360;
        public const int kDisplayWidth = 640;

        public const int kWindowWidth = 1280;
        public const int kWindowHeight = 720;
        
    }
}