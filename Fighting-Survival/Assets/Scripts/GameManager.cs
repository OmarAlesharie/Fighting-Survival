using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text InfoText;
    public static GameManager Instance = null;

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
    }

    public void PlayerLost()
    {
        PlayerIsDead = true;
        InfoText.text = "You Lost!";
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
            while (CurrentEnemyCount > 0)
            {
                yield return null;
            }
        }

        InfoText.text = "You win!";
        PlayerWon = true;
    }

    public bool IsPlayerWon()
    {
        return PlayerWon;
    }

    public void OneEnemyKilled()
    {
        CurrentEnemyCount--;
    }
}
