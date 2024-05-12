using TankGame.Main;
using TankGame.Managers;
using UnityEngine;

namespace TankGame.Levels
{
    public class LevelBtnView : MonoBehaviour
    {
        private LevelService levelService => GameService.Instance.LevelService;

        public void LoadScene(string sceneName)
        {
            levelService.SetLevel(sceneName[sceneName.Length - 1]);
            GameManager.Instance.SetCurrentScene(sceneName);
            levelService.LoadScene(sceneName);
        }
    }
}
