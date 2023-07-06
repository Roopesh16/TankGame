using UnityEngine;
using TankGame.Views;
using TankGame.Models;
using TankGame.Managers;
using System.Collections;

namespace TankGame.Controllers
{
    public class TankController : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("References")]
        [SerializeField] private TankView tankView;
        [SerializeField] private GunController gunController;

        [Header("Fields")]
        [SerializeField] private LayerMask baseLayer;
        [SerializeField] private float maxDistance = 5f;
        [SerializeField] private float movementDuration = 2f;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private TankState currentTankState;
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Start()
        {
        }

        void Update()
        {
            if (GameManager.instance.GetGameState() == GameState.PLAY)
            {
                if (Input.GetMouseButtonDown(0) && GameManager.instance.GetTankState() == TankState.REST)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
                    RaycastHit rayHit;

                    if (Physics.Raycast(ray, out rayHit, maxDistance, baseLayer))
                    {
                        GameManager.instance.SetTankState(TankState.MOVING);
                        StartCoroutine(MoveTank(rayHit.point));
                    }
                }
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart()
        {
            GameManager.instance.SetTankState(TankState.REST);
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        private IEnumerator MoveTank(Vector3 hitPosition)
        {
            if (GameManager.instance.GetTankState() == TankState.MOVING)
            {
                Vector3 newPosition = new Vector3(hitPosition.x, 0f, hitPosition.z);
                float time = 0;
                while (time < movementDuration)
                {
                    tankView.transform.position = Vector3.Lerp(tankView.transform.position, newPosition, time / movementDuration);
                    time += Time.deltaTime;
                    yield return null;
                }
                tankView.transform.position = newPosition;
                yield return new WaitForSeconds(1f);
                gunController.CheckForWall();
                GameManager.instance.SetTankState(TankState.REST);
                yield return null;
            }
        }
        #endregion------------------------
    }
}
