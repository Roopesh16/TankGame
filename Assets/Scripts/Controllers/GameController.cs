using TankGame.Managers;
using TankGame.Models;
using TankGame.Views;
using UnityEngine;

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

        void Update()
        {

        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameOver()
        {
            gameView.OnGameOver();
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void OnGameStart()
        {
            GameManager.instance.SetGameState(GameState.PLAY);
            tankController.OnGameStart();
            wallController.OnGameStart();
        }
        #endregion------------------------
    }
}
