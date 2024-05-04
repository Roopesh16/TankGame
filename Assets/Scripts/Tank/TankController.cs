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
        private TankService tankService => GameService.Instance.TankService;

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
        #endregion------------------------
    }
}