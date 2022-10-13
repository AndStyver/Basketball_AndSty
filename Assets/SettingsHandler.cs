using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsHandler : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;

    bool musicMuted = false;
    bool soundMuted = false;

    MenuHandler menuHandler;

    [SerializeField] AudioMixerGroup audMixer;

    private void Awake()
    {
        menuHandler = GetComponent<MenuHandler>();

        musicMuted = false;
        soundMuted = false;

        musicSlider.value = GetMusicVol();
        musicSlider.value = GetSoundVol();
    }

    float GetMusicVol()
    {
        float value;
        bool result = audMixer.audioMixer.GetFloat("MusicVol", out value);
        if (result) { return value; }
        else { return 0f; }
    }

    float GetSoundVol()
    {
        float value;
        bool result = audMixer.audioMixer.GetFloat("SoundVol", out value);
        if (result) { return value; }
        else { return 0f; }
    }


    public void VolumeMusic()
    {
        menuHandler.PlaySound();
        if (!musicMuted)
            audMixer.audioMixer.SetFloat("MusicVol", musicSlider.value);
    }

    public void MuteMusic()
    {
        menuHandler.PlaySound();
        musicMuted = !musicMuted;

        if (musicMuted) { audMixer.audioMixer.SetFloat("MusicVol", -80); }
        else if (!musicMuted) { VolumeMusic(); }
    }

    public void VolumeSound()
    {
        menuHandler.PlaySound();
        if (!soundMuted)
            audMixer.audioMixer.SetFloat("SoundVol", soundSlider.value);
    }

    public void MuteSound()
    {
        menuHandler.PlaySound();
        soundMuted = !soundMuted;

        if (soundMuted) { audMixer.audioMixer.SetFloat("SoundVol", -80); }
        else if (!soundMuted) { VolumeSound(); }
    }
}
