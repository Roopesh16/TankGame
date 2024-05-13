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
        [SerializeField] private string sceneName;

        private void Awake()
        {
            levelButton.onClick.AddListener(LoadScene);
        }

        private LevelService levelService => GameService.Instance.LevelService;

        public void ToggleInteraction(bool isInteractable) => levelButton.interactable = isInteractable;

        public void LoadScene()
        {
            levelService.SetLevel(levelNumber);
            GameManager.Instance.SetCurrentScene(sceneName);
            GameManager.Instance.OnLevelStart();
            levelService.LoadScene(sceneName);
        }
    }
}