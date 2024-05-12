
using System.ComponentModel;

public static class Constants {

    public static class GameConstants {
        public const int kCardHeight = 36;
        public const int kCardWidth = 25;
        public const int kCardScale = (int) (DisplayConstants.kDisplayWidth / 400);
    }

    public static class DisplayConstants {
        public const int kDisplayScale = 1;
        public const int kDisplayHeight = 720;
        public const int kDisplayWidth = 1280;
    }
}