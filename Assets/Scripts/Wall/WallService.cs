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
        private List<WallData> levelWallList = new();


        public WallService(List<WallData> levelWallList)
        {
            wallController = new();
            this.levelWallList = levelWallList;
        }

        public void SetWallData(int level)
        {
            foreach (WallData wallData in levelWallList)
            {
                if (level == wallData.levelNumber)
                {
                    wallController.SetWallController(wallData.walls);
                    currentLevel = wallData.levelNumber;
                    return;
                }
            }
        }
    }
}