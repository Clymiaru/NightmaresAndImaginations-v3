using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void PrevScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void SetupScene()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void TutorialScene()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void FollyFloraScene()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void DesertBoxScene()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void PreBossScene()
    {
        StartCoroutine(LoadLevel(4));
    }

    public void BossScene()
    {
        StartCoroutine(LoadLevel(5));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play anim
        transition.SetTrigger("Start");
        // Wait
        yield return new WaitForSeconds(transitionTime);
        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}
