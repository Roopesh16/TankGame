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
        [SerializeField] private TextMeshProUGUI goScoreText;
        [SerializeField] private TextMeshProUGUI lcScoreText;
        [Header("References")]
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject mineInfo;
        [SerializeField] private GameObject levelComplete;
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
            scoreText.text = "SCORE : " + totalScore;
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
            goScoreText.text = totalScore.ToString();
            gameOver.SetActive(true);
        }

        public void OnLevelComplete()
        {
            lcScoreText.text = totalScore.ToString();
            levelComplete.SetActive(true);
        }
        #endregion------------------------

        #region ------------ Private Methods ------------


        #endregion------------------------
    }
}
