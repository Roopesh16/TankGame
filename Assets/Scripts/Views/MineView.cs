using UnityEngine;
using TankGame.Managers;
using TankGame.Views;

public class MineView : MonoBehaviour
{
    #region ------------ Serialized Variables ------------
    #endregion------------------------
    #region ------------ Private Methods ------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tank")
        {
            other.GetComponent<TankView>().PlayBlast();
            other.gameObject.SetActive(false);
            AudioManager.instance.PlaySFX(AudioSFX.MINE_EXPLODE, 0.5f);
            gameObject.SetActive(false);
        }
    } 
    #endregion------------------------
}
