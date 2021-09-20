using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Interactables : MonoBehaviour
{
    public GameObject image;

    [SerializeField] private LevelLoader lvlLoader;
    [SerializeField] private bool isInsideCollider = false;


    private void Update()
    {
        if (isInsideCollider && image.name == "PopUpImageBed")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GO TO DREAM WORLD");
                lvlLoader.Cutscene3Scene();
            }
        }

        else if (isInsideCollider && image.name == "PopUpImageDoor")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GO TO TUTORIAL");
                lvlLoader.Cutscene1Scene();
            }
        }

        else if (isInsideCollider && image.name == "PopUpImageOutsideDoor")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GO TO SETUP SCENE");
                lvlLoader.SetupScene();
            }
        }

        else if (isInsideCollider && image.name == "PopUpImageQuitGame")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("QUIT GAME");
                lvlLoader.QuitGame();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && image.name == "PlaceHolder") // Tutorial
        {
            lvlLoader.Cutscene2Scene();
        }

        this.image.SetActive(true);
        this.isInsideCollider = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.image.SetActive(false);
        this.isInsideCollider = false;
    }
}

