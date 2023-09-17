using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace TankGame.Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region ------------ Serialized Variables ------------
        [SerializeField] private GameObject loadingCanvas;
        [SerializeField] private Image progressBar;
        #endregion------------------------
        #region ------------ Public Variables ------------
        public static LevelManager instance = null;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private float targetFill;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        #endregion------------------------

        // Update is called once per frame
        void Update()
        {
            progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, targetFill, 3 * Time.deltaTime);
        }
        #region ------------ Private Methods ------------
        #endregion------------------------

        #region ------------ Public Methods ------------
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
