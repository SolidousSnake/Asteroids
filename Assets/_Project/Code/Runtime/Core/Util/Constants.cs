
namespace _Project.Code.Runtime.Core.Util
{
    public static class Constants
    {
        public const int EdgeAmount = 4;
        
        public static class Time
        {
            public const int SecondsInMinute = 60;
            public const float PausedValue = 0f;
            public const float ResumedValue = 1f;
        }

        public static class AssetPath
        {
            public const string MenuScene = "MenuScene";
            public const string GameplayScene = "GameplayScene";
            public const string PlayerProgress = "/playerProgress.data";
        }
        
        public static class AssetLabel
        {
            public const string Level = "Level";
            public const string Menu = "Menu";
        }
    }
}
