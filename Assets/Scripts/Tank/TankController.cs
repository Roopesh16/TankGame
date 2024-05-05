using TankGame.Audio;
using TankGame.Controllers;
using TankGame.Main;
using UnityEngine;

namespace TankGame.Tank
{
    public class TankController
    {
        #region ------------ Serialize Variables ------------
        private TankView tankView;
        private TankModel tankModel;

        #endregion------------------------

        #region ------------ Private Variables ------------
        private GameController gameController;
        private TankService tankService => GameService.Instance.TankService;
        private AudioService audioService => GameService.Instance.AudioService;

        #endregion------------------------

        #region ------------ Private Methods ------------
        private void InstantiateView(TankView tankView)
        {
            this.tankView = tankView;
            tankView.SetController(this);
            tankView.SetupTankView();
        }

        private void InstantiateModel()
        {
            tankModel = new TankModel();
            tankModel.SetController(this);
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public TankController(TankView tankView)
        {
            InstantiateView(tankView);
            InstantiateModel();
        }

        public float GetMinDistance() => tankModel.MinimumDistance;

        public void SetTankState(TankState tankState) => tankService.SetTankState(tankState);

        public void MoveTank(Vector3 hitPosition) => tankView.MoveTank(hitPosition);

        public void OnGameOver()
        {
            audioService.SetBGMMute();
            gameController.OnGameOver();
        }

        public void SetAudio(AudioBGM audioBGM, float volume = 0.5f) => audioService.PlayBGM(audioBGM, volume);
        #endregion------------------------
    }
}