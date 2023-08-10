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
        [SerializeField] private float minimumDistance = 2f;

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
                if (Vector3.Distance(hitPosition, transform.position) >= minimumDistance)
                {
                    tankRb.AddForce(direction * tankVelocity, ForceMode.VelocityChange);
                }
                else
                {
                    transform.position = hitPosition;
                    tankRb.velocity = Vector3.zero;
                    canMove = false;
                    GameManager.instance.SetTankState(TankState.REST);
                }
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
