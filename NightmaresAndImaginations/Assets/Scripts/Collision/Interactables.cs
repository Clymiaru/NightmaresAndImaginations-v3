using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


    public class Interactables : MonoBehaviour
    {
        public GameObject image;
        public Text text;

        [SerializeField] private LevelLoader lvlLoader;
        [SerializeField] private bool isInsideCollider = false;
        [SerializeField] private bool is_F_KeyPressed = false;


        private void Update()
        {
            if (isInsideCollider)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("GO TO DREAM WORLD");
                    lvlLoader.NextScene();
                    is_F_KeyPressed = true;
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

