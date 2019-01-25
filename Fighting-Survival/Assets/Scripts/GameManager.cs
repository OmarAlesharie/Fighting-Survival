using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class GameManager : MonoBehaviour
{
    public Text InfoText;
    public Text DifficultyText;
    public static GameManager Instance = null;
    public GameSetting Setting;

    public ThirdPersonCharacter thirdPersonCharacter;
    public ThirdPersonUserControl thirdPersonUserControl;

    [Header("Enemies Prefabs")]
    public GameObject[] Enemies;
    [Space]
    [Header("Locations where to spawn enemies")]
    public Transform[] SpawnPoints;
    [Space]
    [Header("enemies for each stage")]
    [Header("Number of stages and the number of")]
    [Range(1,7)]
    public int[] Stages;

    [Space]
    public GameObject[] Items;
    public GameObject WinLostMenu;

    public AudioSource NewEnemiesWave;
    public AudioSource NewItemDrop;

    private int CurrentEnemyCount;
    private bool PlayerIsDead;
    private bool PlayerWon;

    private bool Paused;

    GameSetting.DifficultyLevel difficultyLevel;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        PlayerIsDead = false;
        PlayerWon = false;
        StartCoroutine("StartAttackStages");
        WinLostMenu.SetActive(false);
        Paused = false;
        Time.timeScale = 1.0f;
        difficultyLevel = Setting.Get_DifficultyLevel();
        DifficultyText.text = difficultyLevel.ToString();
    }

    public void PlayerLost()
    {
        PlayerIsDead = true;
        InfoText.text = "You Lost!";
        CursorEnable();
        DisplayWinOrLoseMenu();
    }

    void CursorEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CursorDesable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (IsPlayerDead() || IsPlayerWon())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Paused = !Paused;
            if (Paused)
            {
                Time.timeScale = 0.0f;
                WinLostMenu.SetActive(true);
                CursorEnable();
            }
            else
            {
                Time.timeScale = 1.0f;
                WinLostMenu.SetActive(false);
                CursorDesable();
            }
        }
    }

    public bool IsPlayerDead()
    {
        return PlayerIsDead;
    }

    IEnumerator StartAttackStages()
    {
        for (int EnemyCount = 0; EnemyCount < Stages.Length; EnemyCount++)
        {
            CurrentEnemyCount = Stages[EnemyCount];
            for (int i = 0; i < CurrentEnemyCount; i++)
            {

                int EnemyToSpawn = Random.Range(0, Enemies.Length);
                Instantiate(Enemies[EnemyToSpawn], SpawnPoints[i].position, SpawnPoints[i].rotation);
            }

            NewEnemiesWave.Play();

            while (CurrentEnemyCount > 0)
            {
                yield return null;
            }

            if (difficultyLevel == GameSetting.DifficultyLevel.Easy)
            {
                DropItem();
                DropItem();
            }

            if (difficultyLevel == GameSetting.DifficultyLevel.Normal)
            {
                DropItem();
            }
            
        }

        InfoText.text = "You win!";
        PlayerWon = true;
        DisplayWinOrLoseMenu();
    }

    public bool IsPlayerWon()
    {
        return PlayerWon;
    }

    public void OneEnemyKilled()
    {
        CurrentEnemyCount--;
    }

    void DropItem()
    {
        NewItemDrop.Play();
        Vector3 NewItemPosition = new Vector3(Random.Range(0.0f, 7.0f), 7.0f, Random.Range(0.0f, 7.0f));
        GameObject Item = Instantiate(Items[Random.Range(0, Items.Length)], NewItemPosition, Quaternion.identity);
    }

    void DisplayWinOrLoseMenu()
    {
        WinLostMenu.SetActive(true);
        CursorEnable();
    }
}
