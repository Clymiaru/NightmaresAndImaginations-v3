using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactables : MonoBehaviour
{
    public GameObject image;
    public Text text;

    [SerializeField] private LevelLoader lvlLoader;
    [SerializeField] private bool isInsideCollider = false;


    private void Update()
    {
        if (isInsideCollider)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GO TO DREAM WORLD");
                //SceneManager.LoadScene(2);
                lvlLoader.NextScene();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInsideCollider)
        {
            this.image.SetActive(true);
            this.isInsideCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isInsideCollider)
        {
            this.image.SetActive(false);
            this.isInsideCollider = false;
        }
    }

    /*
    void ProcessCollision(GameObject collider)
    {
        if (collider.CompareTag("Player"))
        {
            DebugHitOBJ();
            image.SetActive(true);
        }
    }
    */
}
