using TankGame.Main;
using TankGame.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TankGame.Levels
{
    public class LevelBtnView : MonoBehaviour
    {
        [SerializeField] private Button levelButton;
        [SerializeField] private int levelNumber;
        private LevelService levelService => GameService.Instance.LevelService;

        public void ToggleInteraction(bool isInteractable) => levelButton.interactable = isInteractable;

        public void LoadScene(string sceneName)
        {
            levelService.SetLevel(levelNumber);
            GameManager.Instance.SetCurrentScene(sceneName);
            levelService.LoadScene(sceneName);
        }
    }
}