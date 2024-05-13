using TankGame.Audio;
using TankGame.Main;
using TankGame.Managers;
using TankGame.States;
using UnityEngine;
using UnityEngine.UI;

namespace TankGame.UI
{
    public class MenuUIService : MonoBehaviour
    {
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

        private int totalScore = 0;

        private AudioService audioService => GameService.Instance.AudioService;

        private void Awake()
        {
            playButton.onClick.AddListener(PlayButton);
            infoButton.onClick.AddListener(InfoButton);
            infoBackBtn.onClick.AddListener(InfoBackButton);
            aboutButton.onClick.AddListener(AboutButton);
            aboutBackBtn.onClick.AddListener(AboutBackButton);

        }

        private void Start()
        {
            audioService.PlayBGM(AudioBGM.THEME);
            GameManager.Instance.SetGameState(GameState.MENU);
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
    }
}