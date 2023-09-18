using UnityEngine;
using UnityEngine.UI;
using TankGame.Managers;
using System.Collections.Generic;

namespace TankGame.Views
{
    public class MenuView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("UI")]
        [SerializeField] private GameObject titleScreen;
        [SerializeField] private GameObject menuScreen;
        [SerializeField] private Button playButton;
        [SerializeField] private List<Button> levelButtons = new List<Button>();

        #endregion------------------------

        #region ------------ Private Variables ------------
        private int maxLevel = 5;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        private void Awake()
        {
            playButton.onClick.AddListener(PlayButton);
            foreach (Button level in levelButtons)
            {
                level.interactable = false;
            }
            UnlockLevel();
        }

        private void Start()
        {
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

        public void UnlockLevel()
        {
            if (GameManager.instance.GetUnlockedLevel() < maxLevel)
            {
                for (int i = 0; i < GameManager.instance.GetUnlockedLevel(); i++)
                {
                    levelButtons[i].interactable = true;
                }
            }
            else
            {
                print("All Complete");
            }
        }
        #endregion ------------------------
    }
}
