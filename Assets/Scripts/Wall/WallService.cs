using System.Collections.Generic;

namespace TankGame.Wall
{
    public struct WallData
    {
        public int levelNumber;
        public List<WallView> walls;
    }

    public class WallService
    {
        private WallController wallController;
        private int currentLevel;

        public void SetWallData(WallData wallData)
        {
            wallController.SetWallController(wallData.walls);
            currentLevel = wallData.levelNumber;
        }
    }
}