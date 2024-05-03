namespace TankGame.Tank
{
    public class TankModel
    {
        private TankController tankController;

        public float MaxDistance { get; private set; } = 5f;
        public float MovementDuration { get; private set; } = 2f;
        public float TankVelocity { get; private set; } = 3f;
        public float MinimumDistance { get; private set; } = 2f;

        public void SetController(TankController tankController) => this.tankController = tankController;
    }
}
