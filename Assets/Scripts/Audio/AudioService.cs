using System.Collections.Generic;
using TankGame.Events;
using TankGame.Main;
using UnityEngine;

namespace TankGame.Audio
{
    public enum AudioSFX
    {
        TANK_SHOT,
        WALL_BREAK,
        MINE_EXPLODE
    }

    public enum AudioBGM
    {
        TANK_IDLE,
        TANK_MOVE,
        THEME
    }

    public class AudioService
    {
        #region ------------ Private Variables ------------
        private bool isSfxMute = false;
        private AudioSource sfxSource;
        private AudioSource bgmSource;
        private List<AudioClip> sfxList = new List<AudioClip>();
        private List<AudioClip> bgmList = new List<AudioClip>();
        private EventService eventService => GameService.Instance.EventService;
        #endregion------------------------


        #region ------------ Monobehavior Methods ------------
        public AudioService(AudioSource sfxSource, AudioSource bgmSource, List<AudioClip> sfxList,
                            List<AudioClip> bgmList)
        {
            this.sfxSource = sfxSource;
            this.bgmSource = bgmSource;
            this.sfxList = sfxList;
            this.bgmList = bgmList;
            Init();
        }

        private void Init()
        {
            sfxSource.loop = false;
            sfxSource.playOnAwake = false;
            bgmSource.loop = true;
            bgmSource.playOnAwake = true;
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        private void SubscribeToEvents() => eventService.OnGameOver.AddListener(SetBGMMute);
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void PlaySFX(AudioSFX sfxClip, float volume = 1f)
        {
            int sfxPosition = (int)sfxClip;
            if (sfxList[sfxPosition] == null) return;

            sfxSource.volume = volume;
            sfxSource.PlayOneShot(sfxList[sfxPosition]);
        }

        public void PlayBGM(AudioBGM bgmClip, float volume = 1f)
        {
            int bgmPosition = (int)bgmClip;
            if (bgmList[bgmPosition] == null) return;

            bgmSource.clip = bgmList[bgmPosition];
            bgmSource.volume = volume;
            bgmSource.Play();
        }

        public void SetBGMMute()
        {
            PlayBGM(AudioBGM.TANK_IDLE, 0f);
            PlayBGM(AudioBGM.TANK_MOVE, 0f);
        }
        #endregion------------------------
    }
}
