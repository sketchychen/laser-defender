using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    /*
    Because LevelManager's methods are already hooked up to buttons in-game,
    turning it into a singleton will be a pain. Soooo we're not gonna.
    */

    [SerializeField] float sceneLoadDelay = 2f;
    Scorekeeper scorekeeper;

    void Awake()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();
    }

    public void LoadGame()
    {
        scorekeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitApplication()
    {
        Debug.Log("Quitting time");
        // this only really works for a standalone application
        // it won't work in a browser
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
