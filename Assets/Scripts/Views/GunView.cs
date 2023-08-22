using UnityEngine;
using TankGame.Models;
using TankGame.Managers;

namespace TankGame.Views
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
        private int count = 0;
        private GameObject bullet;
        private RaycastHit wallHit;
        #endregion------------------------

        #region ------------ Public Variables ------------
        [HideInInspector] public bool canFire = false;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Update()
        {
            if (GameManager.instance.GetTankState() == TankState.FIRE || canFire == true)
            {
                bullet.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public bool IsWallPresent()
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
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
            AudioManager.instance.PlaySFX(AudioSFX.TANK_SHOT, 0.5f);
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        #endregion------------------------
    }
}
