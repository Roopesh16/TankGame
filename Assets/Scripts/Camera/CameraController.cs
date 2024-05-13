using TankGame.Main;
using TankGame.Tank;
using UnityEngine;

namespace TankGame.Cameras
{
    public class CameraController : MonoBehaviour
    {
        #region ------------ Serialized Variables ------------
        [SerializeField] private Transform tank;
        [SerializeField] private float smoothing;

        #endregion------------------------
        #region ------------ Private Variables ------------
        private Vector3 offset;
        private TankService tankService => GameService.Instance.TankService;

        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Start()
        {
            offset = transform.position - tank.position;
        }

        void LateUpdate()
        {
            if (tankService.GetTankState() == TankState.MOVING)
            {
                Vector3 targetPosition = tank.position + offset;
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
            }
        }
        #endregion------------------------

    }
}
