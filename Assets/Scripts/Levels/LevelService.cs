using System;
using System.Threading.Tasks;
using TankGame.Managers;
using TankGame.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TankGame.Levels
{
    [Serializable]
    public class LevelData
    {
        public int currentLevel;
    }

    public class LevelService
    {
        #region ------------ Serialized Variables ------------
        private GameObject loadingCanvas;
        private Image progressBar;
        private int currentLevel = 0;
        private int unlockedLevel = 1;

        #endregion------------------------

        #region ------------ Public Variables ------------
        public static LevelService instance = null;

        #endregion------------------------

        #region ------------ Private Variables ------------
        private float targetFill;

        #endregion------------------------
        void Update()
        {
            progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, targetFill, 3 * Time.deltaTime);
        }

        #region ------------ Public Methods ------------
        public LevelService(GameObject loadingCanvas, Image progressBar)
        {
            this.loadingCanvas = loadingCanvas;
            this.progressBar = progressBar;
            unlockedLevel = PlayerPrefs.GetInt("Level", 1);
        }

        public async void LoadScene(string sceneName)
        {
            targetFill = 0f;
            progressBar.fillAmount = 0f;
            var scene = SceneManager.LoadSceneAsync(sceneName);
            scene.allowSceneActivation = false;

            loadingCanvas.SetActive(true);
            do
            {
                await Task.Delay(100);
                targetFill = scene.progress;
            } while (scene.progress < 0.9f);

            await Task.Delay(1000);

            scene.allowSceneActivation = true;
            loadingCanvas.SetActive(false);
        }



        public void OnLevelComplete()
        {
            UnlockLevel();
            GameManager.Instance.SetGameState(GameState.GAMEOVER);
            eventService.OnLevelComplete.Invoke();
        }

        public void SetLevel(int level)
        {
            currentLevel = level;
        }

        public int GetLevel()
        {
            return currentLevel;
        }

        public void UnlockLevel()
        {
            unlockedLevel++;
            PlayerPrefs.SetInt("Level", unlockedLevel);
            PlayerPrefs.Save();
        }

        public int GetUnlockedLevel()
        {
            return unlockedLevel;
        }


        #endregion------------------------
    }
}
