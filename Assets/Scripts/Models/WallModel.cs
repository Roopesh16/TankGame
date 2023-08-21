using System;

namespace TankGame.Models
{
    public enum WallType
    {
        SMALL,
        MID,
        BIG
    }
    
    public class WallModel
    {
        public int smallWallPoint = 5;
        public int midWallPoint = 10;
        public int bigWallPoint = 15;
    }
}
