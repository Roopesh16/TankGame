using UnityEngine;

namespace TankGame.Views
{
    public class WallView : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Bullet")
            {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
