using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TDS;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private StatsComponent playerStats;

    private int enemyCount = 0;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        this.playerStats = GameObject.Find("Player").GetComponent<StatsComponent>();
        if (this.playerStats == null)
            Debug.LogError("Script GameManager, playerStats is null!");

        this.enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
    }

    private void Update()
    {
        if(this.playerStats.IsDead)
        {
            this.GameOver();
        }

        if(this.enemyCount == 0)
        {
            this.PlayerWin();
        }
        //add win condition

    }


    private void GameOver()
    {
        //do gameover here
    }

    private void PlayerWin()
    {
        //do win here
    }
}
