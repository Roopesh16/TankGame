using UnityEngine;
using TankGame.Managers;
using UnityEngine.SceneManagement;

namespace TankGame.Views
{
    public class GameOverView : MonoBehaviour
    {
        public void MenuButton()
        {
            SceneManager.LoadScene(GameStrings.menuSceneString);
        }

        public void ReloadScene()
        {
            if (GameManager.instance.GetCurrentScene() != null)
            {
                SceneManager.LoadScene(GameManager.instance.GetCurrentScene());
            }
        }
    }
}
