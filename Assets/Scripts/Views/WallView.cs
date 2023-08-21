using UnityEngine;
using TankGame.Models;
using TankGame.Controllers;

namespace TankGame.Views
{
    public class WallView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private WallType wallType;
        [SerializeField] private WallModel wallModel;
        [SerializeField] private WallController wallController;
        [SerializeField] private GameView gameView;
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
            if (other.tag == GameStrings.bulletString)
            {
                gameView.SetScoreText(wallScore);
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
                wallController.NextWall();
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
        }
        #endregion------------------------
    }
}
