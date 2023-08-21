using UnityEngine;
using TMPro;
using TankGame.Managers;

namespace TankGame.Views
{
    public class GameView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private GameObject gameOver;
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

        public void OnGameOver()
        {
            gameOver.SetActive(true);
            GameManager.instance.SetGameState(Models.GameState.GAMEOVER);
        }
        #endregion------------------------

        #region ------------ Private Methods ------------


        #endregion------------------------
    }
}
