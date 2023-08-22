using TankGame.Controllers;
using UnityEngine;

public class MineView : MonoBehaviour
{
    #region ------------ Serialized Variables ------------
    [SerializeField] private GameController gameController;
    #endregion------------------------
    #region ------------ Private Methods ------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tank")
        {
            other.gameObject.SetActive(false);
            gameController.OnGameOver();
        }
    }
    #endregion------------------------
}
