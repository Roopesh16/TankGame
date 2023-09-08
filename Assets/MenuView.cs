using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;

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
        #endregion------------------------

        private void Awake()
        {
            titleScreen.SetActive(true);
            menuScreen.SetActive(false);
        }

        public void PlayButton()
        {
            titleScreen.SetActive(false);
            menuScreen.SetActive(true);
        }
    }
}
