using TankGame.Main;
using TankGame.Managers;
using TankGame.States;
using TankGame.Tank;
using UnityEngine;

namespace TankGame.Inputs
{
    public class InputService
    {
        private TankService tankService => GameService.Instance.TankService;
        private RaycastHit rayHit;
        private float maxHitDistance = 5f;

        public InputService(float maxHitDistance)
        {
            this.maxHitDistance = maxHitDistance;
        }

        public void Update()
        {
            if (GameManager.Instance.GetGameState() == GameState.PLAY)
            {
                if (Input.GetMouseButtonDown(0) && tankService.GetTankState() == TankState.REST)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out rayHit, maxHitDistance))
                    {
                        if (rayHit.collider.tag == GameStrings.BASE_STRING)
                        {
                            tankService.SetTankState(TankState.MOVING);
                            tankService.MoveTank(rayHit.point);
                        }
                    }
                }
            }
        }
    }
}