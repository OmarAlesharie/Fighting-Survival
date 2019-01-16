using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameSetting Setting;

    public Toggle EasyToggle;
    public Toggle NormalToggle;
    public Toggle HardToggle;

    public Slider MusicSlider;
    public Slider SoundFxSlider;

    public AudioMixer audioMixer;

    public GameObject LoadingUIs;
    public Slider LoadingProgress;
    public Text ProgressText;

    private void Start()
    {
        SetOptionsUI();
        Time.timeScale = 1.0f;
        InitMusicLevel();
    }

    void InitMusicLevel()
    {
        audioMixer.SetFloat("Music", Setting.GetMusicLevel());
        audioMixer.SetFloat("SoundFx", Setting.GetSoundFxLevel());
    }

    public void LoadGameLevelAsync(int LevelIndex)
    {
        StartCoroutine(LoadAsynchronously(LevelIndex));
    }

    IEnumerator LoadAsynchronously(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        LoadingUIs.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingProgress.value = progress;
            ProgressText.text = progress * 100.0f + "%";
            yield return null;
        }
    }

    public void SetSfxLvl(float sfxLvl)
    {
        audioMixer.SetFloat("SoundFx", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        audioMixer.SetFloat("Music", musicLvl);
    }

    public void SaveAudioSetting()
    {
        Setting.SetMusicLevel(MusicSlider.value);
        Setting.SetSoundFxLevel(SoundFxSlider.value);
    }

    public void EasySelected()
    {
        Setting.Set_DifficultyLevel(GameSetting.DifficultyLevel.Easy);
    }

    public void NormalSelected()
    {
        Setting.Set_DifficultyLevel(GameSetting.DifficultyLevel.Normal);
    }

    public void HardSelected()
    {
        Setting.Set_DifficultyLevel(GameSetting.DifficultyLevel.Hard);
    }

    void SetOptionsUI()
    {
        GameSetting.DifficultyLevel difficultyLevel = Setting.Get_DifficultyLevel();
        switch (difficultyLevel)
        {
            case GameSetting.DifficultyLevel.Easy:
                EasyToggle.isOn = true;
                break;
            case GameSetting.DifficultyLevel.Normal:
                NormalToggle.isOn = true;
                break;
            case GameSetting.DifficultyLevel.Hard:
                HardToggle.isOn = true;
                break;
            default:
                break;
        }

        MusicSlider.value = Setting.GetMusicLevel();
        SoundFxSlider.value = Setting.GetSoundFxLevel();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
