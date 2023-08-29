using UnityEngine;
using UnityEngine.AI;
using TankGame.Models;
using TankGame.Managers;

namespace TankGame.Views
{
    public class TankView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("References")]
        [SerializeField] private Transform startingPosition;
        [SerializeField] private GunView gunView;
        [SerializeField] private Transform blastPosition;
        [SerializeField] private GameObject blastPrefab;

        [Header("Values")]
        [SerializeField] private float movementDuration = 2f;
        [SerializeField] private float tankVelocity = 3f;
        [SerializeField] private float minimumDistance = 2f;

        #endregion------------------------

        #region ------------ Private Variables ------------
        private bool canMove = false;
        private Vector3 hitPosition;
        private NavMeshAgent tankNavMesh;
        private Animator tankAnim;
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Awake()
        {
            tankNavMesh = GetComponent<NavMeshAgent>();
            tankAnim = GetComponent<Animator>();
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
                    if (gunView.IsWallPresent())
                    {
                        GameManager.instance.SetTankState(TankState.FIRE);
                        gunView.FireBullet();
                    }
                    tankAnim.SetBool("IsMove", false);
                    AudioManager.instance.PlayBGM(AudioBGM.TANK_IDLE, 0.8f);
                    GameManager.instance.SetTankState(TankState.REST);
                }
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart()
        {
            AudioManager.instance.PlayBGM(AudioBGM.TANK_IDLE, 0.8f);
            tankAnim.SetBool("IsMove", false);
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
                AudioManager.instance.PlayBGM(AudioBGM.TANK_MOVE, 0.15f);
                tankAnim.SetBool("IsMove", true);
            }
        }

        public void PlayBlast()
        {
            GameObject blast = Instantiate(blastPrefab);
            blast.transform.position = blastPosition.position;
            blast.GetComponent<ParticleSystem>().Play();
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        #endregion------------------------
    }
}
