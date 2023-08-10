using System.Collections;
using TankGame.Managers;
using TankGame.Models;
using UnityEngine;

namespace TankGame.Views
{
    public class TankView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private Transform startingPosition;
        [SerializeField] private float movementDuration = 2f;
        [SerializeField] private GunView gunView;
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
                while (transform.position.z <= hitPosition.z)
                {
                    tankRb.velocity = new(0, 0, 10f);
                }

                canMove = false;
                GameManager.instance.SetTankState(TankState.REST);
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart()
        {
            transform.position = startingPosition.position;
        }
        public void MoveTank(Vector3 hitPosition)
        {
            if (GameManager.instance.GetTankState() == TankState.MOVING)
            {
                canMove = true;
                this.hitPosition = hitPosition;
            }
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        #endregion------------------------
    }
}
