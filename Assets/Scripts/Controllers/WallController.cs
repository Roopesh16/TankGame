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
        #endregion------------------------

        #region ------------ Private Variables ------------
        private int currentWall = -1;
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart()
        {
            DisableAllWalls();
        }

        public void NextWall()
        {
            currentWall++;
            if (currentWall < walls.Count)
            {
                walls[currentWall].gameObject.SetActive(true);
            }
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void DisableAllWalls()
        {
            foreach (WallView wall in walls)
            {
                wall.gameObject.SetActive(false);
            }
            NextWall();
        }
        #endregion------------------------
    }
}
