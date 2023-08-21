using UnityEngine;
using TankGame.Models;

namespace TankGame.Views
{
    public class WallView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private WallType wallType;
        [SerializeField] private WallModel wallModel;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private int wallScore;
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart()
        {
            SetWallScore();
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Bullet")
            {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }

        private void SetWallScore()
        {
            switch (wallType)
            {
                case WallType.SMALL:
                    wallScore = wallModel.smallWallPoint;
                    break;
                case WallType.MID:
                    wallScore = wallModel.midWallPoint;
                    break;
                case WallType.BIG:
                    wallScore = wallModel.bigWallPoint;
                    break;
            }

            print(wallScore);
        }
        #endregion------------------------
    }
}
