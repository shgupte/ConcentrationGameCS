
using System.ComponentModel;

public static class Constants {

    public static class GameConstants {
        public const int kCardHeight = 36;
        public const int kCardWidth = 25;

        //Should be able to get rid of this scaling crap soon with the RenderTarget2D
        
        public const int kCardScale = (int) (DisplayConstants.kDisplayWidth / 400);

        public const int kButtonScale = 3;
    }

    public static class DisplayConstants {
        public const int kDisplayScale = 1;
        public const int kDisplayHeight = 720;
        public const int kDisplayWidth = 1280;
    }
}