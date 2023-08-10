using System.Collections;
using TankGame.Managers;
using TankGame.Models;
using UnityEngine;

namespace TankGame.Views
{
    public class TankView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("References")]
        [SerializeField] private Transform startingPosition;
        [SerializeField] private GunView gunView;

        [Header("Values")]
        [SerializeField] private float movementDuration = 2f;
        [SerializeField] private float tankVelocity = 3f;

        #endregion------------------------

        #region ------------ Private Variables ------------
        private bool canMove = false;
        private Vector3 hitPosition;
        private Rigidbody tankRb;
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Awake()
        {
            tankRb = GetComponent<Rigidbody>();
        }
        void Update()
        {

        }

        void FixedUpdate()
        {
            if (canMove)
            {
                Vector3 direction = (hitPosition - transform.position).normalized;
                tankRb.AddForce(direction * tankVelocity, ForceMode.VelocityChange);
                // canMove = false;
                // GameManager.instance.SetTankState(TankState.REST);
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart()
        {
            transform.localPosition = startingPosition.position;
        }

        public void MoveTank(Vector3 hitPosition)
        {
            if (GameManager.instance.GetTankState() == TankState.MOVING)
            {
                canMove = true;
                this.hitPosition = hitPosition;
                this.hitPosition.y = 0;
            }
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        #endregion------------------------
    }
}
