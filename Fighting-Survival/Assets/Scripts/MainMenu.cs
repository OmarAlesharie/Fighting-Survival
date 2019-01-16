using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameSetting Setting;

    public Toggle EasyToggle;
    public Toggle NormalToggle;
    public Toggle HardToggle;

    public Slider MusicSlider;
    public Slider SoundFxSlider;



    private void Awake()
    {
        SetOptionsUI();
        Time.timeScale = 1.0f;
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
