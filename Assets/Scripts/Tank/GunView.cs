using TankGame.Audio;
using TankGame.Main;
using TankGame.Managers;
using UnityEngine;

namespace TankGame.Tank
{
    public class GunView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("References")]
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private GameObject bulletPrefab;

        [Header("Values")]
        [SerializeField] private float maxWallDistance = 10f;
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private float bulletSpeed = 10f;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private GameObject bullet;
        private RaycastHit wallHit;
        private TankService tankService => GameService.Instance.TankService;
        private AudioService audioService => GameService.Instance.AudioService;
        #endregion------------------------

        #region ------------ Public Variables ------------
        [HideInInspector] public bool canFire = false;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Update()
        {
            if (tankService.GetTankState() == TankState.FIRE || canFire == true)
            {
                bullet.transform.Translate(transform.right * bulletSpeed * Time.deltaTime);
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public bool IsWallPresent()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out wallHit, maxWallDistance, wallLayer))
            {
                return true;
            }
            return false;
        }
        public void FireBullet()
        {
            canFire = true;
            bullet = Instantiate(bulletPrefab);
            bullet.transform.position = shootingPoint.position;
            audioService.PlaySFX(AudioSFX.TANK_SHOT, 0.5f);
        }
        #endregion------------------------
    }
}
