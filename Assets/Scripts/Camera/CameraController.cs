using UnityEngine;
using TankGame.Managers;
using TankGame.Models;
using System.Collections;

namespace TankGame.Controllers
{
    public class CameraController : MonoBehaviour
    {
        #region ------------ Serialized Variables ------------
        [SerializeField] private Transform tank;
        [SerializeField] private float smoothing;

        #endregion------------------------
        #region ------------ Private Variables ------------
        private Vector3 offset;

        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Start()
        {
            offset = transform.position - tank.position;
        }
        void LateUpdate()
        {
            if (GameManager.instance.GetTankState() == TankState.MOVING)
            {
                Vector3 targetPosition = tank.position + offset;
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
            }
        }
        #endregion------------------------


    }
}
