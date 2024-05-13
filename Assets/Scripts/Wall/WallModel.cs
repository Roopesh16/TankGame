namespace TankGame.Wall
{
    public class WallModel
    {
        private int smallWallPoint = 5;
        private int midWallPoint = 10;
        private int bigWallPoint = 15;

        private WallController wallController;

        public void SetController(WallController wallController) => this.wallController = wallController;

        public int GetWallPoint(WallType wallType)
        {
            switch (wallType)
            {
                case WallType.SMALL: return smallWallPoint;
                case WallType.MID: return midWallPoint;
                case WallType.BIG: return bigWallPoint;
            }

            return 0;
        }
    }
}
