using UnityEngine;
using TankGame.Views;
using TankGame.Models;
using TankGame.Managers;

namespace TankGame.Controllers
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
        private TankState currentTankState;
        private RaycastHit rayHit;
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Update()
        {
            if (GameManager.instance.GetGameState() == GameState.PLAY)
            {
                if (Input.GetMouseButtonDown(0) && GameManager.instance.GetTankState() == TankState.REST)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out rayHit, maxDistance))
                    {
                        if (rayHit.collider.tag == GameStrings.baseString)
                        {
                            GameManager.instance.SetTankState(TankState.MOVING);
                            tankView.MoveTank(rayHit.point);
                        }
                    }
                }
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart()
        {
            GameManager.instance.SetTankState(TankState.REST);
            tankView.OnGameStart();
        }
        #endregion------------------------

        #region ------------ Private Methods ------------

        #endregion------------------------
    }
}
