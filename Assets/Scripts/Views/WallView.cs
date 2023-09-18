using UnityEngine;
using TankGame.Models;
using TankGame.Managers;
using TankGame.Controllers;
using Unity.VisualScripting;

namespace TankGame.Views
{
    public class WallView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private WallType wallType;
        [SerializeField] private WallModel wallModel;
        [SerializeField] private WallController wallController;
        [SerializeField] private GameView gameView;
        [SerializeField] private MoveCamController moveCamController;
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
                AudioManager.instance.PlaySFX(AudioSFX.WALL_BREAK, 0.5f);
                gameView.SetScoreText(wallScore);
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
                if (wallType == WallType.SMALL && GameManager.instance.GetLevel() == 49)
                {
                    moveCamController.ShowMineInfo();
                }
                wallController.CheckLastWall();
            }
        }

        private void SetWallScore()
        {
            if (wallType != null)
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
        }
        #endregion------------------------
    }
}
