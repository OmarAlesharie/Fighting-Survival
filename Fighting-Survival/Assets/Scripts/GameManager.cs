using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text InfoText;
    public static GameManager Instance = null;
    public GameSetting Setting;

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
    }

    public void PlayerLost()
    {
        PlayerIsDead = true;
        InfoText.text = "You Lost!";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DisplayWinOrLoseMenu();
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
            DropItem();
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
        Vector3 NewItemPosition = new Vector3(Random.Range(0.0f, 10.0f), 10.0f, Random.Range(0.0f, 10.0f));
        GameObject Item = Instantiate(Items[Random.Range(0, Items.Length)], NewItemPosition, Quaternion.identity);
    }

    void DisplayWinOrLoseMenu()
    {
        WinLostMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
