using UnityEngine;
using TankGame.Managers;

namespace TankGame.Views
{
    public class LevelBtnView : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            GameManager.instance.SetCurrentScene(sceneName);
            LevelManager.instance.LoadScene(sceneName);
        }
    }
}
