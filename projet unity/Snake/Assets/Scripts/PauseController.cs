using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseController : MonoBehaviour
{
    public static bool Ispaused = false;
    public GameObject PauseMenu;
    public GameObject DeadMenu;
    public Snake Snake;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Ispaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }

        if (Snake.Isdead == true)
        {
            DeadMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Ispaused = false;
    }
    public void pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Ispaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        Snake.Isdead = false;

    }
}