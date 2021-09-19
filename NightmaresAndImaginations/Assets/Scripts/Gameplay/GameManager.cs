using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TDS;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelLoader lvlLoader;
    [SerializeField] private StatsComponent playerStats;
    private KeyHolder keyHolder;

    private static GameManager _instance;
    private int enemyCount = 0;
    public bool isAllEnemiesDead = false;

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
        this.keyHolder = GameObject.Find("Player").GetComponent<KeyHolder>();

        if (this.playerStats == null)
            Debug.LogError("Script GameManager, playerStats is null!");

        if (this.keyHolder == null)
            Debug.LogError("Script GameManager, keyHolder is null!");

        this.enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2) // Level 1
        {
            this.enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        }

        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            this.enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        }

        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            this.enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4) // Level 1
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
                isAllEnemiesDead = true;
            }

            else if (this.enemyCount != 0)
            {
                isAllEnemiesDead = false;
            }
        }
    }

    public void GameOver()
    {
        //do gameover here
        if (SceneManager.GetActiveScene().buildIndex == 2) // Level 1
        {
            lvlLoader.FollyFloraScene();
        }

        else if (SceneManager.GetActiveScene().buildIndex == 3) // Level 2
        {
            lvlLoader.DesertBoxScene();
        }

        else if (SceneManager.GetActiveScene().buildIndex == 3) // Level 3
        {
            lvlLoader.PreBossScene();
        }

        else if (SceneManager.GetActiveScene().buildIndex == 4) // Boss Level
        {
            lvlLoader.BossScene();
        }
    }

    public void PlayerWin()
    {
        //do win here
        if (SceneManager.GetActiveScene().buildIndex == 2) // Level 2
        {
            lvlLoader.DesertBoxScene();
        }

        else if (SceneManager.GetActiveScene().buildIndex == 3) // Level 3
        {
            lvlLoader.PreBossScene();
        }

        else if (SceneManager.GetActiveScene().buildIndex == 4) // Boss Level
        {
            lvlLoader.BossScene();
        }
    }
}
