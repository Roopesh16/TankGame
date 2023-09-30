using UnityEngine;
using UnityEngine.UI;
using TankGame.Managers;
using System.Collections.Generic;

namespace TankGame.Views
{
    public class MenuView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("UI Screen")]
        [SerializeField] private GameObject titleScreen;
        [SerializeField] private GameObject menuScreen;
        [SerializeField] private GameObject infoScreen;
        [SerializeField] private GameObject aboutScreen;
        [Header("UI Button")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button infoButton;
        [SerializeField] private Button infoBackBtn;
        [SerializeField] private Button aboutButton;
        [SerializeField] private Button aboutBackBtn;
        [SerializeField] private List<Button> levelButtons = new List<Button>();

        #endregion------------------------

        #region ------------ Private Variables ------------
        private int maxLevel = 5;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
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
            // UnlockAllLevel();
        }

        private void Start()
        {
            AudioManager.instance.PlayBGM(AudioBGM.THEME);
            titleScreen.SetActive(true);
            menuScreen.SetActive(false);
        }
        #endregion ------------------------

        #region ------------ Private Methods ------------
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
            for (int i = 0; i < GameManager.instance.GetUnlockedLevel(); i++)
            {
                if (levelButtons[i].IsInteractable() == false)
                {
                    levelButtons[i].interactable = true;
                }
            }
        }

        // public void UnlockAllLevel()
        // {
        //     for (int i = 0; i < maxLevel; i++)
        //     {
        //         levelButtons[i].interactable = true;
        //     }
        // }
        #endregion ------------------------
    }
}
