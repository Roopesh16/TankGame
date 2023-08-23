using UnityEngine;
using System.Collections.Generic;

namespace TankGame.Managers
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
    }

    public class AudioManager : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField]
        private List<AudioClip> sfxList = new List<AudioClip>();
        [SerializeField]
        private List<AudioClip> bgmList = new List<AudioClip>();
        #endregion------------------------

        #region ------------ Private Variables ------------
        private bool isSfxMute = false;
        private AudioSource sfxSource;
        private AudioSource bgmSource;
        #endregion------------------------

        #region ------------ Public Variables ------------
        public static AudioManager instance = null;
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.loop = false;
            sfxSource.playOnAwake = false;
            bgmSource = gameObject.AddComponent<AudioSource>();
            bgmSource.loop = true;
            bgmSource.playOnAwake = true;

        }
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
            if (bgmSource.mute == false)
            {
                bgmSource.mute = true;
            }
            else
            {
                bgmSource.mute = true;
            }
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        #endregion------------------------
    }
}
