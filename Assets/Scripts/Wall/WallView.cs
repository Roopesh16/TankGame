using TankGame.Audio;
using TankGame.Cameras;
using TankGame.Levels;
using TankGame.Main;
using TankGame.Models;
using TankGame.UI;
using UnityEngine;

namespace TankGame.Wall
{
    public class WallView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private WallType wallType;
        
        #endregion------------------------

        #region ------------ Private Variables ------------
        private WallController wallController;
        private int wallScore;
        private AudioService audioService => GameService.Instance.AudioService;
        private UIService uIService => GameService.Instance.UIService;
        private LevelService levelService => GameService.Instance.LevelService;

        public int WallScore => wallScore;
        public WallType WallType => wallType;
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart() => SetWallScore();

        public void SetWallController(WallController wallController) => this.wallController = wallController;
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void OnTriggerEnter(Collider other)
        {
            wallController.DisableWall(other.gameObject);
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

