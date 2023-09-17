using TMPro;
using UnityEngine;
using TankGame.Managers;
namespace TankGame.Views
{
    public class GameView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI finalScoreText;
        [Header("References")]
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
            finalScoreText.text = totalScore.ToString();
            gameOver.SetActive(true);
        }
        #endregion------------------------

        #region ------------ Private Methods ------------


        #endregion------------------------
    }
}
