using System.Collections;
using TankGame.Managers;
using TankGame.Models;
using UnityEngine.AI;
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
        private NavMeshAgent tankNavMesh;
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Awake()
        {
            tankNavMesh = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            if (canMove)
            {
                tankNavMesh.SetDestination(hitPosition);

                if (Vector3.Distance(hitPosition, transform.position) <= minimumDistance)
                {
                    
                    tankNavMesh.isStopped = true;
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
                tankNavMesh.isStopped = false;
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
