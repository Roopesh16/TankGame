using TankGame.Audio;
using TankGame.Events;
using TankGame.Main;
using TankGame.Managers;
using TankGame.States;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TankGame.UI
{
    public class UIService : MonoBehaviour
    {
        [Header("Gameplay UI")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI goScoreText;
        [SerializeField] private TextMeshProUGUI lcScoreText;
        [Header("References")]
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject mineInfo;
        [SerializeField] private GameObject levelComplete;
        [Header("UI Screen")]
        [SerializeField] private GameObject titleScreen;
        [SerializeField] private GameObject menuScreen;
        [SerializeField] private GameObject infoScreen;
        [SerializeField] private GameObject aboutScreen;
        [Header("Menu Buttons")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button infoButton;
        [SerializeField] private Button infoBackBtn;
        [SerializeField] private Button aboutButton;
        [SerializeField] private Button aboutBackBtn;

        private int maxLevel = 5;
        private int totalScore = 0;

        private AudioService audioService => GameService.Instance.AudioService;
        private EventService eventService => GameService.Instance.EventService;

        private void Awake()
        {
            playButton.onClick.AddListener(PlayButton);
            infoButton.onClick.AddListener(InfoButton);
            infoBackBtn.onClick.AddListener(InfoBackButton);
            aboutButton.onClick.AddListener(AboutButton);
            aboutBackBtn.onClick.AddListener(AboutBackButton);
            SubscribeToEvents();
        }

        private void Start()
        {
            audioService.PlayBGM(AudioBGM.THEME);
            GameManager.Instance.SetGameState(GameState.MENU);
            titleScreen.SetActive(true);
            menuScreen.SetActive(false);
        }

        private void SubscribeToEvents()
        {
            eventService.OnLevelStart.AddListener(SetMineInfo);
            eventService.OnGameOver.AddListener(SetGameOverText);
            eventService.OnLevelComplete.AddListener(SetLevelCompleteText);
        }

        private void PlayButton()
        {
            titleScreen.SetActive(false);
            menuScreen.SetActive(true);
        }

        private void InfoButton()
        {
            titleScreen.SetActive(false);
            infoScreen.SetActive(true);
        }

        private void InfoBackButton()
        {
            titleScreen.SetActive(true);
            infoScreen.SetActive(false);
        }

        private void AboutButton()
        {
            titleScreen.SetActive(false);
            aboutScreen.SetActive(true);
        }

        private void AboutBackButton()
        {
            titleScreen.SetActive(true);
            aboutScreen.SetActive(false);
        }

        public void SetScoreText(int score)
        {
            totalScore += score;
            scoreText.text = GameStrings.SCORE_STRING + totalScore;
        }

        public void SetMineInfo(bool isActive) => mineInfo.SetActive(isActive);

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