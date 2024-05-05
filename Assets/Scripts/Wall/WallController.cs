using System.Collections.Generic;
using TankGame.Controllers;

namespace TankGame.Wall
{
    public class WallController
    {
        #region ------------ Serialize Variables ------------
        private List<WallView> walls = new List<WallView>();
        private GameController gameController;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private int currentWall = 0;
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void SetWallController(List<WallView> walls)
        {
            this.walls = walls;
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
