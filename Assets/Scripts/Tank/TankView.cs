using UnityEngine;
using UnityEngine.AI;

namespace TankGame.Tank
{
    public class TankView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("References")]
        [SerializeField] private GunView gunView;
        [SerializeField] private Transform blastPosition;
        [SerializeField] private ParticleSystem blastParticle;

        [SerializeField] private NavMeshAgent tankNavMesh;
        [SerializeField] private Animator tankAnim;

        public NavMeshAgent Agent => tankNavMesh;
        public Animator Animator => tankAnim;
        public Vector3 HitPosition => hitPosition;
        public GunView Gun => gunView;
        public Vector3 Position => transform.position;
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
                tankController.MoveTank();
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void SetController(TankController tankController) => this.tankController = tankController;

        public void SetupTankView()
        {
            tankController.SetAudio(Audio.AudioBGM.TANK_IDLE, 0.8f);
            tankAnim.SetBool("IsMove", false);
        }

        public void SetHitPosition(Vector3 hitPosition)
        {
            this.hitPosition = hitPosition;
            hitPosition.y = 0;
        }

        public void PlayBlast()
        {
            blastParticle.transform.position = blastPosition.position;
            blastParticle.Play();
            Invoke("GameOver", blastParticle.main.duration);
        }

        public void ToggleMove(bool canMove) => this.canMove = canMove;
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void GameOver() => tankController.OnGameOver();
        #endregion------------------------
    }
}