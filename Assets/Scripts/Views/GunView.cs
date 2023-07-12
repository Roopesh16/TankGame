using UnityEngine;
using TankGame.Models;
using TankGame.Managers;
using System.Collections;

namespace TankGame.Views
{
    public class GunView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("References")]
        [SerializeField] private Transform gun;
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private GameObject bulletPrefab;

        [Header("Values")]
        [SerializeField] private float maxWallDistance = 10f;
        [SerializeField] private LayerMask wallLayer;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private int count = 0;
        private GameObject bullet;
        #endregion------------------------

        #region ------------ Public Variables ------------
        [HideInInspector] public bool canFire = false;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Start()
        {

        }

        void Update()
        {
            if (GameManager.instance.GetTankState() == TankState.FIRE || canFire == true)
            {
                bullet.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
            }
        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void CheckForWall()
        {
            Ray ray = new Ray(gun.position, Vector3.forward);
            RaycastHit wallHit;
            if (Physics.Raycast(ray, out wallHit, maxWallDistance, wallLayer))
            {
                canFire = true;
                GameManager.instance.SetTankState(TankState.FIRE);
                bullet = Instantiate(bulletPrefab);
                bullet.transform.position = shootingPoint.position;
            }
            // else
            // {
            //     print("No walls");
            //     return;
            // }
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        #endregion------------------------
    }
}
