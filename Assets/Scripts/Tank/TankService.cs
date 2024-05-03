namespace TankGame.Tank
{
    public class TankService
    {
        private TankState tankState = TankState.REST;

        public TankState GetTankState()
        {
            return this.tankState;
        }

        public void SetTankState(TankState tankState)
        {
            this.tankState = tankState;
        }
    }
}