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

    public Toggle FreeCameraToggle;
    public Toggle FollowCameraToggle;



    private void Start()
    {
        SetOptionsUI();
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

    public void FreeCameraSelected()
    {
        Setting.Set_CameraType(GameSetting.CameraType.Free);
    }

    public void FollowCameraSelected()
    {
        Setting.Set_CameraType(GameSetting.CameraType.Follow);
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

        GameSetting.CameraType cameraType = Setting.Get_CameraType();
        switch (cameraType)
        {
            case GameSetting.CameraType.Free:
                FreeCameraToggle.isOn = true;
                break;
            case GameSetting.CameraType.Follow:
                FollowCameraToggle.isOn = true;
                break;
            default:
                break;
        }
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
