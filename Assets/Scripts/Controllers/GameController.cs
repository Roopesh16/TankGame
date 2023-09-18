using UnityEngine;
using TankGame.Views;
using TankGame.Models;
using TankGame.Managers;

namespace TankGame.Controllers
{
    public class GameController : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private TankController tankController;
        [SerializeField] private WallController wallController;
        [SerializeField] private GameView gameView;
        #endregion------------------------

        #region ------------ Private Variables ------------
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Start()
        {
            OnGameStart();
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameOver()
        {
            GameManager.instance.SetGameState(GameState.GAMEOVER);
            AudioManager.instance.SetBGMMute();
            gameView.OnGameOver();
        }

        #endregion------------------------

        #region ------------ Private Methods ------------
        private void OnGameStart()
        {
            GameManager.instance.SetGameState(GameState.PLAY);
            gameView.OnGameStart();
            tankController.OnGameStart();
            wallController.OnGameStart();
        }
        #endregion------------------------
    }
}
