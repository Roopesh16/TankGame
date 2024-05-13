using TankGame.Audio;
using TankGame.Levels;
using TankGame.Main;
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
        private int wallPoint;
        private AudioService audioService => GameService.Instance.AudioService;
        private MenuUIService uIService => GameService.Instance.MenuUIService;
        private LevelService levelService => GameService.Instance.LevelService;

        public int WallPoint => wallPoint;
        public WallType WallType => wallType;
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void SetWallController(WallController wallController) => this.wallController = wallController;

        public void SetWallPoint() => wallPoint = wallController.GetWallPoint(wallType);
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void OnTriggerEnter(Collider other)
        {
            wallController.DisableWall(this, other.gameObject);
        }
        #endregion------------------------
    }
}

