using UnityEngine;
using TankGame.Views;
using System.Collections.Generic;

namespace TankGame.Controllers
{
    public class WallController : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField]
        private List<WallView> walls = new List<WallView>();
        [SerializeField] private GameController gameController;
        [SerializeField] private CameraController cameraController;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private int currentWall = 0;
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart()
        {
            InitiateAllWalls();
        }

        public void CheckLastWall()
        {
            if (walls[walls.Count - 1].isActiveAndEnabled == false)
            {
                gameController.OnLevelComplete();
            }
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void InitiateAllWalls()
        {
            foreach (WallView wall in walls)
            {
                wall.OnGameStart();
            }
        }
        #endregion------------------------
    }
}
