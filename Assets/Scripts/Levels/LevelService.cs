using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TankGame.Levels
{
    public class LevelService
    {
        #region ------------ Serialized Variables ------------
        private GameObject loadingCanvas;
        private Image progressBar;

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
        #endregion------------------------
    }
}
