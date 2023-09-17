using UnityEngine;
using TankGame.Models;

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
        #endregion------------------------
    }
}
