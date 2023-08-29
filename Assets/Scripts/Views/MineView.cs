using UnityEngine;
using TankGame.Managers;
using TankGame.Controllers;
using TankGame.Views;

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
            other.GetComponent<TankView>().PlayBlast();
            other.gameObject.SetActive(false);
            AudioManager.instance.PlaySFX(AudioSFX.MINE_EXPLODE, 0.5f);
            gameController.OnGameOver();
            this.gameObject.SetActive(false);
        }
    }
    #endregion------------------------
}
