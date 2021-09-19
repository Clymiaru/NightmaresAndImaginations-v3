using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TDS;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelLoader lvlLoader;
    [SerializeField] private StatsComponent playerStats;

    private static GameManager _instance;
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
        DontDestroyOnLoad(transform.gameObject);
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        this.playerStats = GameObject.Find("Player").GetComponent<StatsComponent>();
        if (this.playerStats == null)
            Debug.LogError("Script GameManager, playerStats is null!");

        this.enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) // Level 1
        {
            this.enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        }
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 2) // Level 1
        {
            if (lvlLoader == null)
            {
                lvlLoader = GameObject.FindObjectOfType<LevelLoader>();
            }

            if (playerStats == null)
            {
                playerStats = GameObject.Find("Player").GetComponent<StatsComponent>();
            }

            if (this.playerStats.IsDead)
            {
                this.GameOver();
            }

            if (this.enemyCount == 0)
            {
                this.PlayerWin();
            }
        }
    }


    private void GameOver()
    {
        //do gameover here
        lvlLoader.GameOver();
        //this.enemyCount = 8;
    }

    private void PlayerWin()
    {
        //do win here
        lvlLoader.PlayerWin();
    }
}
