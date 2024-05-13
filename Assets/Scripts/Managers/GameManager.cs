using TankGame.Events;
using TankGame.Main;
using TankGame.States;
using TankGame.Utility;

namespace TankGame.Managers
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        #region ------------ Private Variables ------------
        private GameState gameState = GameState.NONE;
        private string currentScene = null;
        private EventService eventService => GameService.Instance.EventService;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        protected override void Awake() => base.Awake();
        #endregion------------------------

        #region ------------ Public Methods ------------
        public GameState GetGameState() => gameState;

        public void SetGameState(GameState gameState) => this.gameState = gameState;

        public void SetCurrentScene(string sceneName) => currentScene = sceneName;

        public string GetCurrentScene() => currentScene;

        public void OnGameOver()
        {
            SetGameState(GameState.GAMEOVER);
            eventService.OnGameOver.Invoke();
        }
        public void OnLevelStart()
        {
            SetGameState(GameState.PLAY);
            eventService.OnLevelStart.Invoke(true);
        }
        #endregion------------------------
    }
}
