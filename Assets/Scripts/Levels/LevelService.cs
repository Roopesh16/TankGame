using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TankGame.Events;
using TankGame.Main;
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
        #region ------------ Private Variables ------------
        private GameObject loadingCanvas;
        private Image progressBar;
        private int currentLevel = 0;
        private int unlockedLevel = 1;
        private float targetFill;
        private bool isFull = true;

        private const int LOADING_DELAY = 100;
        private const float MAX_PROGRESS = 0.9f;
        private const int LOAD_SCENE_DELAY = 1000;
        private const int FILL_RATE = 3;
        private const int MAX_LEVELS = 5;
        private List<LevelBtnView> levelButtons = new();

        private EventService eventService => GameService.Instance.EventService;

        #endregion------------------------

        public void Update()
        {
            if (!isFull)
            {
                progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, targetFill, FILL_RATE * Time.deltaTime);
            }
        }

        #region ------------ Public Methods ------------
        public LevelService(GameObject loadingCanvas, Image progressBar, List<LevelBtnView> levelButtons)
        {
            this.loadingCanvas = loadingCanvas;
            this.progressBar = progressBar;
            this.levelButtons = levelButtons;
            unlockedLevel = PlayerPrefs.GetInt(GameStrings.LEVEL_STRING);
            SetUnlockedButtons();
        }

        private void SetUnlockedButtons()
        {
            for (int i = 0; i < unlockedLevel; i++)
                levelButtons[i].ToggleInteraction(true);
        }

        public async void LoadScene(string sceneName)
        {
            targetFill = 0f;
            progressBar.fillAmount = 0f;
            var scene = SceneManager.LoadSceneAsync(sceneName);
            scene.allowSceneActivation = false;
            isFull = false;
            loadingCanvas.SetActive(true);
            do
            {
                await Task.Delay(LOADING_DELAY);
                targetFill = scene.progress;
            } while (scene.progress < MAX_PROGRESS);

            await Task.Delay(LOAD_SCENE_DELAY);

            isFull = true;
            scene.allowSceneActivation = true;
            loadingCanvas.SetActive(false);
        }

        public void OnLevelComplete()
        {
            UnlockLevel();
            GameManager.Instance.SetGameState(GameState.GAMEOVER);
            eventService.OnLevelComplete.Invoke();
        }

        public void SetLevel(int level) => currentLevel = level;

        public int GetLevel() => currentLevel;

        public void UnlockLevel()
        {
            if (unlockedLevel < MAX_LEVELS)
            {
                unlockedLevel++;
                PlayerPrefs.SetInt(GameStrings.LEVEL_STRING, unlockedLevel);
                PlayerPrefs.Save();
            }
            else
                unlockedLevel = MAX_LEVELS;
        }

        public int GetUnlockedLevel() => unlockedLevel;

        #endregion------------------------
    }
}
