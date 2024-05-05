using System.Collections.Generic;
using TankGame.Audio;
using TankGame.Main;
using TankGame.Managers;
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
        [SerializeField] private List<Button> levelButtons = new List<Button>();

        private int maxLevel = 5;
        private int totalScore = 0;
        private const string scoreString = "SCORE : ";
        private AudioService audioService => GameService.Instance.AudioService;

        private void Awake()
        {
            playButton.onClick.AddListener(PlayButton);
            infoButton.onClick.AddListener(InfoButton);
            infoBackBtn.onClick.AddListener(InfoBackButton);
            aboutButton.onClick.AddListener(AboutButton);
            aboutBackBtn.onClick.AddListener(AboutBackButton);
            foreach (Button level in levelButtons)
            {
                level.interactable = false;
            }
            UnlockLevel();
        }

        private void Start()
        {
            audioService.PlayBGM(AudioBGM.THEME);
            titleScreen.SetActive(true);
            menuScreen.SetActive(false);
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

        public void UnlockLevel()
        {
            if (GameManager.Instance.GetUnlockedLevel() <= 5)
            {
                for (int i = 0; i < GameManager.Instance.GetUnlockedLevel(); i++)
                {
                    if (levelButtons[i].IsInteractable() == false)
                    {
                        levelButtons[i].interactable = true;
                    }
                }
            }
            else
            {
                UnlockAllLevel();
            }
        }

        public void UnlockAllLevel()
        {
            for (int i = 0; i < maxLevel; i++)
            {
                levelButtons[i].interactable = true;
            }
        }

        public void SetScoreText(int score)
        {
            totalScore += score;
            scoreText.text = scoreString + totalScore;
        }

        public void DisplayMineInfo()
        {
            mineInfo.SetActive(true);
        }

        public void HideMineInfo()
        {
            mineInfo.SetActive(false);
        }

        public void OnGameStart()
        {
            mineInfo.SetActive(false);
        }
        public void OnGameOver()
        {
            goScoreText.text = totalScore.ToString();
            gameOver.SetActive(true);
        }

        public void OnLevelComplete()
        {
            lcScoreText.text = totalScore.ToString();
            levelComplete.SetActive(true);
        }

        public void MenuButton()
        {
            SceneManager.LoadScene(GameStrings.menuSceneString);
        }

        public void ReloadScene()
        {
            if (GameManager.Instance.GetCurrentScene() != null)
            {
                SceneManager.LoadScene(GameManager.Instance.GetCurrentScene());
            }
        }
    }
}