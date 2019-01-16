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
