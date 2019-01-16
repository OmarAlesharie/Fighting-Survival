using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameSetting : ScriptableObject
{
    public enum DifficultyLevel
    {
        Easy,Normal,Hard
    }

    public enum CameraType
    {
        Free,Follow
    }

    private DifficultyLevel difficultyLevel = DifficultyLevel.Easy;
    private CameraType cameraType = CameraType.Free;
    private float MusicLevel = 0.0f;
    private float SoundFxLevel = 0.0f;

    public void SetMusicLevel(float Lvl)
    {
        MusicLevel = Lvl;
    }

    public float GetMusicLevel()
    {
        return MusicLevel;
    }

    public void SetSoundFxLevel(float Lvl)
    {
        SoundFxLevel = Lvl;
    }

    public float GetSoundFxLevel()
    {
        return SoundFxLevel;
    }

    public void Set_DifficultyLevel(DifficultyLevel difficulty)
    {
        difficultyLevel = difficulty;
    }

    public void Set_CameraType(CameraType CamType)
    {
        cameraType = CamType;
    }

    public DifficultyLevel Get_DifficultyLevel()
    {
        return difficultyLevel;
    }

    public CameraType Get_CameraType()
    {
        return cameraType;
    }
}
