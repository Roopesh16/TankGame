using UnityEngine;
using System.Collections.Generic;
using TankGame.Views;
using System.Security.Cryptography;

namespace TankGame.Controllers
{
    public class WallController : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField]
        private List<WallView> walls = new List<WallView>();
        [SerializeField] private GameController gameController;
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

        public void NextWall()
        {
            currentWall++;
            if (currentWall >= walls.Count)
            {
                gameController.OnGameOver();
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
