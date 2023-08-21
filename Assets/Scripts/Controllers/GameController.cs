using TankGame.Managers;
using TankGame.Models;
using UnityEngine;

namespace TankGame.Controllers
{
    public class GameController : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private TankController tankController;
        [SerializeField] private WallController wallController;
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
