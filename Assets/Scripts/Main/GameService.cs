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
        private float maxHitDistance = 5f;

        [Header("Tank Service")]
        private TankView tankPrefab;

        [Header("UI Service")]
        [SerializeField] private UIService uiService;

        [Header("Level Service")]
        [SerializeField] private GameObject loadingCanvas;
        [SerializeField] private Image progressBar;

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

        public UIService UIService => uiService;

        protected void Awake()
        {
            base.Awake();
            CreateServices();
        }

        private void Update()
        {
            InputService?.Update();
        }

        private void CreateServices()
        {
            EventService = new EventService();
            InputService = new InputService(maxHitDistance);
            TankService = new TankService(tankPrefab);
            AudioService = new AudioService(sfxSource, bgmSource, sfxList, bgmList);
            LevelService = new LevelService(loadingCanvas, progressBar);
            WallService = new WallService();
        }
    }
}
