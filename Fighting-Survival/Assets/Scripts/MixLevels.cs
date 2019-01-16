using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameSetting Setting;

    public void SetSfxLvl(float sfxLvl)
    {
        Setting.SetSoundFxLevel(sfxLvl);
        audioMixer.SetFloat("SoundFx", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        Setting.SetMusicLevel(musicLvl);
        audioMixer.SetFloat("Music", musicLvl);
    }
}
