using UnityEngine;
using UnityEngine.Audio;

namespace UI.MainMenu
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        public void ChangeAudioVolume(float value) => _audioMixer.SetFloat("Audio", value);
        
        public void ChangeSoundVolume(float value) => _audioMixer.SetFloat("Sound", value);

        public void ChangeMusicVolume(float value) => _audioMixer.SetFloat("Music", value);
    }
}