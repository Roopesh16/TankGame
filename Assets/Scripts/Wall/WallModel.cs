using UnityEngine;
namespace TankGame.Models
{
    public enum WallType
    {
        SMALL,
        MID,
        BIG
    }

    public class WallModel : MonoBehaviour
    {
        [HideInInspector] public int smallWallPoint = 5;
        [HideInInspector] public int midWallPoint = 10;
        [HideInInspector] public int bigWallPoint = 15;
    }
}
