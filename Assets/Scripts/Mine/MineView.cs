using TankGame.Audio;
using TankGame.Main;
using TankGame.Tank;
using UnityEngine;

public class MineView : MonoBehaviour
{
    private AudioService audioService => GameService.Instance.AudioService;
    #region ------------ Private Methods ------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameStrings.TANK_STRING)
        {
            other.GetComponent<TankView>().PlayBlast();
            other.gameObject.SetActive(false);
            audioService.PlaySFX(AudioSFX.MINE_EXPLODE, 0.5f);
            gameObject.SetActive(false);
        }
    }
    #endregion------------------------
}
