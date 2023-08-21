using UnityEngine;
using System.Collections.Generic;
using TankGame.Views;

namespace TankGame.Controllers
{
    public class WallController : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField]
        private List<WallView> walls = new List<WallView>();
        #endregion------------------------

        #region ------------ Private Variables ------------
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
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void DisableAllWalls()
        {
            foreach (WallView wall in walls)
            {
                wall.gameObject.SetActive(false);
            }
            #endregion------------------------
        }

    }
}
