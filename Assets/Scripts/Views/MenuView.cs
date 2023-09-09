using TMPro;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections.Generic;

namespace TankGame.Views
{
    public class MenuView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("Scenes")]
        [SerializeField] private SceneAsset menuScene;
        [SerializeField] private List<SceneAsset> levelScenes = new List<SceneAsset>();

        [Header("UI")]
        [SerializeField] private GameObject titleScreen;
        [SerializeField] private GameObject menuScreen;
        [SerializeField] private Button playButton;
        [SerializeField] private List<Button> levelButtons = new List<Button>();

        // [Header("References")]
        // [SerializeField] private 
        #endregion------------------------

        #region ------------ Private Variables ------------
        private int levelCount = -1;
        private int maxLevel = 10;
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

        private void UnlockLevel()
        {
            levelCount++;
            levelButtons[levelCount].interactable = true;
            levelButtons[levelCount].GetComponentInChildren<TextMeshProUGUI>().text = (levelCount + 1).ToString();
        }

        // private void LockLevel()
        // {

        // }
        #endregion ------------------------
    }
}
