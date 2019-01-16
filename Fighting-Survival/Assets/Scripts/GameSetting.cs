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
    
    private DifficultyLevel difficultyLevel = DifficultyLevel.Easy;

    [SerializeField]
    private float MusicLevel = 0.0f;
    [SerializeField]

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

    public DifficultyLevel Get_DifficultyLevel()
    {
        return difficultyLevel;
    }
}
