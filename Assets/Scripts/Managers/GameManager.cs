using UnityEngine;
using TankGame.Models;
using TankGame.Views;
using UnityEditor;

namespace TankGame.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region ------------ Public Variables ------------
        public static GameManager instance = null;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private GameState gameState = GameState.NONE;
        private TankState tankState = TankState.REST;
        private string currentScene = null;
        private int currentLevel = 0;
        private int unlockedLevel = 1;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
            currentLevel = PlayerPrefs.GetInt("Level");
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

        public TankState GetTankState()
        {
            return this.tankState;
        }

        public void SetTankState(TankState tankState)
        {
            this.tankState = tankState;
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
        }

        public int GetUnlockedLevel()
        {
            return unlockedLevel;
        }
        #endregion------------------------
    }
}
