using TankGame.Main;
using TankGame.Managers;
using TankGame.Models;
using UnityEngine;

namespace TankGame.Tank
{
    public class TankController : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("References")]
        [SerializeField] private TankView tankView;

        [Header("Fields")]
        [SerializeField] private float maxDistance = 5f;

        #endregion------------------------

        #region ------------ Private Variables ------------
        private TankService tankService => GameService.Instance.TankService;
        private RaycastHit rayHit;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Update()
        {
            if (GameManager.instance.GetGameState() == GameState.PLAY)
            {
                if (Input.GetMouseButtonDown(0) && tankService.GetTankState() == TankState.REST)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out rayHit, maxDistance))
                    {
                        if (rayHit.collider.tag == GameStrings.baseString)
                        {
                            tankService.SetTankState(TankState.MOVING);
                            tankView.MoveTank(rayHit.point);
                        }
                    }
                }
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public TankController(TankView tankView)
        {
            this.tankView = tankView;
            tankModel = new TankModel();
            tankModel.SetController(this);
            tankView.SetController(this);
        }

        public void OnGameStart()
        {
            tankService.SetTankState(TankState.REST);
            tankView.OnGameStart();
        }
        #endregion------------------------
    }
}
