using TankGame.Audio;
using TankGame.Main;
using TankGame.Managers;
using TankGame.UI;
using UnityEngine;

namespace TankGame.Tank
{
    public class TankController
    {
        #region ------------ Serialize Variables ------------
        private TankView tankView;
        private TankModel tankModel;
        private GunView gunView;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private TankService tankService => GameService.Instance.TankService;
        private AudioService audioService => GameService.Instance.AudioService;
        private UIService uIService => GameService.Instance.UIService;

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
        public TankController(TankView tankView, GunView gunView)
        {
            this.gunView = gunView;
            InstantiateView(tankView);
            InstantiateModel();
        }

        public void SetTankState(TankState tankState) => tankService.SetTankState(tankState);

        public void SetTankPosition(Vector3 hitPosition)
        {
            tankView.Agent.isStopped = false;
            tankView.ToggleMove(true);
            tankView.SetHitPosition(hitPosition);
            tankView.Animator.SetBool("IsMove", true);
            SetAudio(AudioBGM.TANK_MOVE, 0.15f);
        }

        public void MoveTank()
        {
            tankView.Agent.SetDestination(tankView.HitPosition);

            if (Vector3.Distance(tankView.HitPosition, tankView.transform.position) <= tankModel.MinimumDistance)
            {
                tankView.Agent.isStopped = true;
                tankView.ToggleMove(false);

                if (gunView.IsWallPresent())
                {
                    SetTankState(TankState.FIRE);
                    gunView.FireBullet();
                }

                tankView.Animator.SetBool("IsMove", false);
                SetAudio(AudioBGM.TANK_IDLE, 0.8f);
                SetTankState(TankState.REST);
            }

            tankView.transform.RotateAround(tankView.transform.position, tankView.transform.up, tankView.RotationSpeed * Time.deltaTime);
        }

        public void OnGameOver() => GameManager.Instance.OnGameOver();

        public void SetAudio(AudioBGM audioBGM, float volume = 0.5f) => audioService.PlayBGM(audioBGM, volume);
        #endregion------------------------
    }
}