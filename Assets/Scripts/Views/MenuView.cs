using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        private void Awake()
        {
            playButton.onClick.AddListener(PlayButton);
            for (int i = 0; i < levelButtons.Count; i++)
            {
                levelButtons[i].onClick.AddListener(LoadScene);
            }
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

        private void LoadScene()
        {
            SceneManager.LoadScene(levelScenes[0].name);
        }
        #endregion ------------------------
    }
}
