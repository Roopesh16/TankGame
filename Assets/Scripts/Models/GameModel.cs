using System;

namespace TankGame.Models
{
    public enum GameState
    {
        NONE,
        MENU,
        PLAY,
        PAUSE,
        GAMEOVER
    }

    [Serializable]
    public class LevelData
    {
        public int currentLevel;
    }

    public class GameModel
    {
        public TankModel tankModel;
    }
}

