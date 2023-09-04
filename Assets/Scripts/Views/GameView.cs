using TMPro;
using UnityEngine;

namespace TankGame.Views
{
    public class GameView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject mineInfo;
        #endregion------------------------

        #region ------------ Private Variables ------------
        private int totalScore = 0;
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        #endregion------------------------

        #region ------------ Public Methods ------------

        public void SetScoreText(int score)
        {
            totalScore += score;
            scoreText.text = "Score : " + totalScore;
        }

        public void DisplayMineInfo()
        {
            mineInfo.SetActive(true);
        }

        public void HideMineInfo()
        {
            mineInfo.SetActive(false);
        }

        public void OnGameStart()
        {
            mineInfo.SetActive(false);
        }
        public void OnGameOver()
        {
            gameOver.SetActive(true);
        }
        #endregion------------------------

        #region ------------ Private Methods ------------


        #endregion------------------------
    }
}
