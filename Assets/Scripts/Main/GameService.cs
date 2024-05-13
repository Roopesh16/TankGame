using Assets.Scripts.UI;
using System.Collections.Generic;
using TankGame.Audio;
using TankGame.Events;
using TankGame.Inputs;
using TankGame.Levels;
using TankGame.Tank;
using TankGame.UI;
using TankGame.Utility;
using TankGame.Wall;
using UnityEngine;
using UnityEngine.UI;

namespace TankGame.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [Header("Input Service")]
        [SerializeField] private float maxHitDistance = 5f;

        [Header("Tank Service")]
        [SerializeField] private TankView tankPrefab;

        [Header("Menu UI Service")]
        [SerializeField] private MenuUIService menuUIService;

        [Header("Gameplay UI Service")]
        [SerializeField] private GameplayUIService gameplayUIService;

        [Header("Level Service")]
        [SerializeField] private GameObject loadingCanvas;
        [SerializeField] private Image progressBar;
        [SerializeField] private List<LevelBtnView> levelButtons = new();

        [Header("Wall Service")]
        [SerializeField] private List<WallData> levelWallList = new();

        [Header("Audio Service")]
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource bgmSource;
        [SerializeField] private List<AudioClip> sfxList = new();
        [SerializeField] private List<AudioClip> bgmList = new();

        public AudioService AudioService { get; private set; }
        public TankService TankService { get; private set; }
        public LevelService LevelService { get; private set; }
        public WallService WallService { get; private set; }
        public InputService InputService { get; private set; }
        public EventService EventService { get; private set; }

        public MenuUIService MenuUIService => menuUIService;
        public GameplayUIService GameplayUIService => gameplayUIService;

        protected void Awake()
        {
            base.Awake();
            CreateServices();
        }

        private void Update()
        {
            InputService?.Update();
            LevelService?.Update();
        }

        private void CreateServices()
        {
            EventService = new EventService();
            InputService = new InputService(maxHitDistance);
            AudioService = new AudioService(sfxSource, bgmSource, sfxList, bgmList);
            LevelService = new LevelService(loadingCanvas, progressBar, levelButtons);
            WallService = new WallService(levelWallList);
            TankService = new TankService(tankPrefab);
        }
    }
}
