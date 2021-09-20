using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TDS;

public class PlayerComponentManager : MonoBehaviour
{

    private GameObject player;
    private string currentScene;
    private bool isSetup = false;


    private const string SETUP_SCENE = "SetupScene";
    private const string TUTORIAL_SCENE = "Tutorial";
    private const string DREAM_WORLD_SCENE = "DreamWorldScene";
    private const string LEVEL_2_SCENE = "Level2";
    private const string LEVEL_3_SCENE = "Level3";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        currentScene = SceneManager.GetActiveScene().name;

        
    }

    private void Update()
    {

        if(currentScene != SceneManager.GetActiveScene().name || player == null || player.GetComponent<StatsComponent>().IsDead)
        {
            //Debug.Log("SET UP COMPONENTS!!!!");
            currentScene = SceneManager.GetActiveScene().name;
            player = GameObject.Find("Player");
            isSetup = false;
        }

        if(!isSetup)
        {
            isSetup = true;

            if (currentScene == SETUP_SCENE)
            {
                player.GetComponent<PlayerCombat>().enabled = false;
                player.GetComponent<PlungeAttack>().enabled = false;
                player.GetComponent<ThrowSword>().enabled = false;
                player.GetComponent<Jump>().enabled = false;
                player.GetComponent<Dash>().enabled = false;
            }
            else if (currentScene == TUTORIAL_SCENE)
            {
                player.GetComponent<PlungeAttack>().enabled = false;
                player.GetComponent<ThrowSword>().enabled = false;
                player.GetComponent<Jump>().SetMaxJumps(1);
                player.GetComponent<Dash>().enabled = false;
            }
            else if(currentScene == DREAM_WORLD_SCENE)
            {
                player.GetComponent<ThrowSword>().enabled = false;
                player.GetComponent<PlungeAttack>().enabled = false;
                player.GetComponent<Jump>().SetMaxJumps(1);
            }
            else if(currentScene == LEVEL_2_SCENE)
            {
                player.GetComponent<ThrowSword>().enabled = false;
                player.GetComponent<Jump>().SetMaxJumps(2);
            }
        }
    }


}
