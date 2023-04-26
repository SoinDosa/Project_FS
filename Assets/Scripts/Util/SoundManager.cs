using PFS.Data.StaticData.staticSettingsData;
using PFS.Enum.bgmEnum;
using PFS.Enum.sfxEnum;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace PFS.Util.soundManager
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        [SerializeField] private List<AudioClip> _bgmClipContainer;
        [SerializeField] private List<AudioClip> _sfxClipContainer;
        [SerializeField] private AudioSource _bgmAudio;
        [SerializeField] private List<AudioSource> _sfxAudio;
        [SerializeField] private AudioMixer _audioMixer;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            SetBGM(StaticSettingsData.isOnBGM);
            SetSFX(StaticSettingsData.isOnSFX);
        }

        public void SetBGM(bool isOn)
        {
            if (isOn)
            {
                _audioMixer.SetFloat("BGM", 0.0f);
            }
            else
            {
                _audioMixer.SetFloat("BGM", -80.0f);
            }
        }

        public void SetSFX(bool isOn)
        {
            if (isOn)
            {
                _audioMixer.SetFloat("SFX", 0.0f);
            }
            else
            {
                _audioMixer.SetFloat("SFX", -80.0f);
            }
        }

        public void PlayBGM(BGMEnum name)
        {
            _bgmAudio.clip = _bgmClipContainer[(int)name];
            _bgmAudio.Play();
        }

        public void PlaySFX(SFXEnum name)
        {
            foreach(var sfx in _sfxAudio)
            {
                if (sfx.isPlaying)
                {
                    continue;
                }
                else
                {
                    sfx.clip = _sfxClipContainer[(int)name];
                    sfx.Play();
                    break;
                }
            }
        }
    }

}
