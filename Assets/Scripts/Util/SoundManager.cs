using PFS.Data.StaticData.staticSettingsData;
using PFS.Enum.bgmEnum;
using PFS.Enum.efxEnum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace PFS.Util.soundManager
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        [SerializeField] private List<AudioClip> _bgmClipContainer;
        [SerializeField] private List<AudioClip> _efxClipContainer;
        [SerializeField] private AudioSource _bgmAudio;
        [SerializeField] private List<AudioSource> _efxAudio;
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
            SetEFX(StaticSettingsData.isOnEFX);
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

        public void SetEFX(bool isOn)
        {
            if (isOn)
            {
                _audioMixer.SetFloat("EFX", 0.0f);
            }
            else
            {
                _audioMixer.SetFloat("EFX", -80.0f);
            }
        }

        public void PlayBGM(BGMEnum name)
        {
            _bgmAudio.clip = _bgmClipContainer[(int)name];
            _bgmAudio.Play();
        }

        public void PlayEFX(EFXEnum name)
        {
            foreach(var efx in _efxAudio)
            {
                if (efx.isPlaying)
                {
                    continue;
                }
                else
                {
                    efx.clip = _efxClipContainer[(int)name];
                    efx.Play();
                    break;
                }
            }
        }
    }

}
