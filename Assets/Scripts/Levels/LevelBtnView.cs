using TankGame.Main;
using TankGame.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TankGame.Levels
{
    public class LevelBtnView : MonoBehaviour
    {
        [SerializeField] private Button levelButton;
        private LevelService levelService => GameService.Instance.LevelService;

        public void ToggleInteraction(bool isInteractable) => levelButton.interactable = isInteractable;

        public void LoadScene(string sceneName)
        {
            levelService.SetLevel(sceneName[sceneName.Length - 1]);
            GameManager.Instance.SetCurrentScene(sceneName);
            levelService.LoadScene(sceneName);
        }
    }
}