using Assets.Scripts.UI;
using System.Collections.Generic;
using TankGame.Audio;
using TankGame.Cameras;
using TankGame.Levels;
using TankGame.Main;
using UnityEngine;

namespace TankGame.Wall
{
    public class WallController
    {
        private WallModel wallModel;
        private List<WallView> walls = new List<WallView>();
        private int currentWall = 0;
        private int currentMaxWalls = 0;
        private const int LEVEL_ONE = 1;
        private const int LEVEL_FOUR = 4;

        private MoveCamController moveCamController;
        private LevelService levelService => GameService.Instance.LevelService;
        private AudioService audioService => GameService.Instance.AudioService;
        private GameplayUIService gameplayUIService => GameService.Instance.GameplayUIService;

        public WallController()
        {
            wallModel = new();
            wallModel.SetController(this);
        }

        public void SetWallController(List<WallView> walls)
        {
            this.walls = walls;
            currentWall = 0;
            currentMaxWalls = walls.Count;
            InitiateAllWalls();
        }

        public void UpdateWallCount()
        {
            if (currentWall >= walls.Count)
            {
                levelService.OnLevelComplete();
            }
            else
                currentWall++;
        }

        public void DisableWall(WallView wallView, GameObject other)
        {
            if (other.tag == GameStrings.BULLET_STRING)
            {
                audioService.PlaySFX(AudioSFX.WALL_BREAK, 0.5f);
                gameplayUIService.SetScoreText(wallView.WallPoint);
                wallView.gameObject.SetActive(false);
                other.SetActive(false);
                if (wallView.WallType == WallType.SMALL && levelService.GetLevel() == LEVEL_ONE)
                {
                    moveCamController.ShowMineInfo();
                }
                if (wallView.WallType == WallType.SMALL && levelService.GetLevel() == LEVEL_FOUR)
                {
                    moveCamController.ShowMineInfo();
                }
                UpdateWallCount();
            }
        }

        public int GetWallPoint(WallType wallType) => wallModel.GetWallPoint(wallType);

        private void InitiateAllWalls()
        {
            foreach (WallView wall in walls)
            {
                wall.SetWallController(this);
                wall.SetWallPoint();
            }
        }
    }
}
