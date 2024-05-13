using UnityEngine;

namespace TankGame.Tank
{
    public class TankService
    {
        private TankState tankState;
        private TankController tankController;

        public TankService(TankView tankView, GunView gunView)
        {
            tankState = TankState.REST;
            tankController = new TankController(tankView, gunView);
        }

        public TankState GetTankState() => tankState;

        public void SetTankState(TankState tankState) => this.tankState = tankState;

        public void MoveTank(Vector3 hitPosition) => tankController.SetTankPosition(hitPosition);
    }
}