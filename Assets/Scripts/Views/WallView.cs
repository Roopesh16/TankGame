using UnityEngine;

namespace TankGame.Views
{
    public class WallView : MonoBehaviour
    {
        [SerializeField] private GunView gunView;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Bullet")
            {
                gunView.canFire = false;
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
