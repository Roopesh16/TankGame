using TankGame.Models;
using TankGame.Utility;
using UnityEngine;

namespace TankGame.Managers
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        #region ------------ Private Variables ------------
        private GameState gameState = GameState.NONE;
        private string currentScene = null;
        private int currentLevel = 0;
        private int unlockedLevel = 1;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        protected override void Awake()
        {
            base.Awake();
            unlockedLevel = PlayerPrefs.GetInt("Level", 1);
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public GameState GetGameState()
        {
            return this.gameState;
        }

        public void SetGameState(GameState gameState)
        {
            this.gameState = gameState;
        }

        public void SetCurrentScene(string sceneName)
        {
            currentScene = sceneName;
        }

        public string GetCurrentScene()
        {
            return currentScene;
        }

        public void SetLevel(int level)
        {
            currentLevel = level;
        }

        public int GetLevel()
        {
            return currentLevel;
        }

        public void UnlockLevel()
        {
            unlockedLevel++;
            PlayerPrefs.SetInt("Level", unlockedLevel);
            PlayerPrefs.Save();
        }

        public int GetUnlockedLevel()
        {
            return unlockedLevel;
        }
        #endregion------------------------
    }
}
