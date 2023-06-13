using UnityEngine;
using UnityEngine.Audio;

namespace UI.MainMenu
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;

        public void ChangeAudioVolume(float value) => _audioMixer.SetFloat("Audio", value);

        public void MuteAudio() => _audioMixer.SetFloat("Audio", -80);
        public void PlayAudio() =>  _audioMixer.SetFloat("Audio", 0);
    }
}