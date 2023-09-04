using UnityEngine;
using TankGame.Managers;
using System.Collections.Generic;
using System.Collections;

namespace TankGame.Controllers
{
    public class CameraController : MonoBehaviour
    {
        #region ------------ Serialized Variables ------------
        [SerializeField] private Transform tank;
        [SerializeField] private float smoothing;
        [SerializeField] private Transform finalCamPosition;
        [SerializeField] private float movementTime = 2f;
        #endregion------------------------
        #region ------------ Private Variables ------------
        private Vector3 offset;
        private Vector3 currentCamPosition;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Start()
        {
            offset = transform.position - tank.position;
        }
        void LateUpdate()
        {
            if (GameManager.instance.GetTankState() == TankGame.Models.TankState.MOVING)
            {
                Vector3 targetPosition = tank.position + offset;
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public IEnumerator MoveCamera()
        {
            float time = 0f;
            currentCamPosition = transform.position;
            while (time <= movementTime)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(currentCamPosition, finalCamPosition.position, time);
                yield return null;
            }
            transform.position = finalCamPosition.position;
        }
        public IEnumerator ResetCamera()
        {
            float time = 0f;
            while (time <= movementTime)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(finalCamPosition.position, currentCamPosition, time);
                yield return null;
            }
            transform.position = currentCamPosition;
        }
        #endregion------------------------
    }
}
