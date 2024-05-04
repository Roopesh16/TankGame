using TankGame.Controllers;
using TankGame.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace TankGame.Tank
{
    public class TankView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("References")]
        [SerializeField] private Transform startingPosition;
        [SerializeField] private GunView gunView;
        [SerializeField] private Transform blastPosition;
        [SerializeField] private ParticleSystem blastParticle;
        [SerializeField] private GameController gameController;

        [SerializeField] private NavMeshAgent tankNavMesh;
        [SerializeField] private Animator tankAnim;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private bool canMove = false;
        private Vector3 hitPosition;
        private TankController tankController;

        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Update()
        {
            if (canMove)
            {
                tankNavMesh.SetDestination(hitPosition);

                if (Vector3.Distance(hitPosition, transform.position) <= tankController.GetMinDistance())
                {
                    tankNavMesh.isStopped = true;
                    canMove = false;
                    if (gunView.IsWallPresent())
                    {
                        tankController.SetTankState(TankState.FIRE);
                        gunView.FireBullet();
                    }
                    tankAnim.SetBool("IsMove", false);
                    AudioManager.instance.PlayBGM(AudioBGM.TANK_IDLE, 0.8f);
                    tankController.SetTankState(TankState.REST);
                }
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void SetController(TankController tankController) => this.tankController = tankController;

        public void SetupTankView()
        {
            AudioManager.instance.PlayBGM(AudioBGM.TANK_IDLE, 0.8f);
            tankAnim.SetBool("IsMove", false);
            transform.localPosition = startingPosition.position;
        }

        public void MoveTank(Vector3 hitPosition)
        {
            tankNavMesh.isStopped = false;
            canMove = true;
            this.hitPosition = hitPosition;
            this.hitPosition.y = 0;
            AudioManager.instance.PlayBGM(AudioBGM.TANK_MOVE, 0.15f);
            tankAnim.SetBool("IsMove", true);
        }

        public void PlayBlast()
        {
            blastParticle.transform.position = blastPosition.position;
            blastParticle.Play();
            Invoke("GameOver", blastParticle.main.duration);
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void GameOver()
        {
            AudioManager.instance.SetBGMMute();
            gameController.OnGameOver();
        }
        #endregion------------------------
    }
}