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
                    lvlLoader.FollyFloraScene();
                    
                }
            }

            else if (isInsideCollider && image.name == "PopUpImageDoor")
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("GO TO TUTORIAL");
                    lvlLoader.TutorialScene();
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
                this.image.SetActive(true);
                this.isInsideCollider = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
                this.image.SetActive(false);
                this.isInsideCollider = false;
        }
    }

