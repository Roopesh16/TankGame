using TankGame.Managers;
using TankGame.Tank;
using UnityEngine;

public class MineView : MonoBehaviour
{
    #region ------------ Private Methods ------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameStrings.tankString)
        {
            other.GetComponent<TankView>().PlayBlast();
            other.gameObject.SetActive(false);
            AudioManager.instance.PlaySFX(AudioSFX.MINE_EXPLODE, 0.5f);
            gameObject.SetActive(false);
        }
    }
    #endregion------------------------
}
