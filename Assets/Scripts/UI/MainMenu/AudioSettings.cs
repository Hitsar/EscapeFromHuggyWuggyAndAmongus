using UnityEngine;
using UnityEngine.Audio;

namespace UI.MainMenu
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _sound;
        [SerializeField] private AudioMixerGroup _music;

        public void ChangeSoundVolume(float value) => _sound.audioMixer.SetFloat("Sound", value);
        
        public void ChangeMusicVolume(float value) => _music.audioMixer.SetFloat("Music", value);
    }
}