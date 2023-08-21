using UnityEngine;

namespace TankGame.Views
{
    public class WallView : MonoBehaviour
    {

        #region ------------ Serialize Variables ------------
        #endregion------------------------

        #region ------------ Private Variables ------------
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        #endregion------------------------

        #region ------------ Public Methods ------------
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Bullet")
            {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
        #endregion------------------------
    }
}
