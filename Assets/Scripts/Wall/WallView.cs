using TankGame.Audio;
using TankGame.Cameras;
using TankGame.Main;
using TankGame.Managers;
using TankGame.Models;
using UnityEngine;

namespace TankGame.Wall
{
    public class WallView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private WallType wallType;
        [SerializeField] private WallModel wallModel;
        [SerializeField] private WallController wallController;
        [SerializeField] private MoveCamController moveCamController;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private int wallScore;
        private AudioService audioService => GameService.Instance.AudioService;
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
            if (other.tag == GameStrings.BULLET_STRING)
            {
                audioService.PlaySFX(AudioSFX.WALL_BREAK, 0.5f);
                //gameView.SetScoreText(wallScore);
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
                if (wallType == WallType.SMALL && GameManager.Instance.GetLevel() == 49)
                {
                    moveCamController.ShowMineInfo();
                }
                if (wallType == WallType.SMALL && GameManager.Instance.GetLevel() == 52)
                {
                    moveCamController.ShowMineInfo();
                }
                wallController.CheckLastWall();
            }
        }

        private void SetWallScore()
        {
            if (wallType == null)
            {
                return;
            }
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

