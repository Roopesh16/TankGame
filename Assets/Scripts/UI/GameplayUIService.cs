using TankGame.Cameras;
using TankGame.Events;
using TankGame.Main;
using TankGame.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameplayUIService : MonoBehaviour
    {
        [Header("Gameplay UI")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI goScoreText;
        [SerializeField] private TextMeshProUGUI lcScoreText;

        [Header("References")]
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject mineInfo;
        [SerializeField] private Button mineOkBtn;
        [SerializeField] private GameObject levelComplete;

        private int totalScore = 0;
        private MoveCamController moveCamController;

        private EventService eventService => GameService.Instance.EventService;

        private void Awake()
        {
            mineOkBtn.onClick.AddListener(OnMineOKClick);
        }

        private void Start()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            eventService.OnLevelStart.AddListener(SetMineInfo);
            eventService.OnGameOver.AddListener(SetGameOverText);
            eventService.OnLevelComplete.AddListener(SetLevelCompleteText);
        }

        public void SetScoreText(int score)
        {
            totalScore += score;
            scoreText.text = GameStrings.SCORE_STRING + totalScore;
        }

        public void SetGameOverText()
        {
            goScoreText.text = totalScore.ToString();
            gameOver.SetActive(true);
        }

        public void SetLevelCompleteText()
        {
            lcScoreText.text = totalScore.ToString();
            levelComplete.SetActive(true);
        }

        public void SetMineInfo(bool isActive) => mineInfo.SetActive(isActive);

        private void OnMineOKClick() => moveCamController.HideMineInfo();

        public void MenuButton() => SceneManager.LoadScene(GameStrings.MENU_STRING);

        public void ReloadScene()
        {
            if (GameManager.Instance.GetCurrentScene() != null)
            {
                SceneManager.LoadScene(GameManager.Instance.GetCurrentScene());
            }
        }

    }
}