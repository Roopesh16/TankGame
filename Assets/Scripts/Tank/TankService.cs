using UnityEngine;

namespace TankGame.Tank
{
    public class TankService
    {
        private TankState tankState;
        private TankController tankController;

        public TankService(TankView tankView)
        {
            tankState = TankState.REST;
            tankController = new TankController(tankView);
        }

        public TankState GetTankState()
        {
            return this.tankState;
        }

        public void SetTankState(TankState tankState)
        {
            this.tankState = tankState;
        }

        public void MoveTank(Vector3 hitPosition) => tankController.MoveTank(hitPosition);
    }
}