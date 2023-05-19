using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenuUi;
    public GameObject Player; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPause = true; 

            if(gameIsPause)
            {
                Paused();
                //Player.SetActive(false);
            }
            else
            {
                Resume();
            }
        }
    }

    public void Paused()
    {
        Debug.Log("fg");
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        gameIsPause = true;
        //FindObjectOfType<player>().SetPause(true);
    }

    public void Resume()
    {
        Debug.Log("ffreejkgej");
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        gameIsPause = false;
        //FindObjectOfType<player>().SetPause(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        gameIsPause = false;
        SceneManager.LoadScene("main_menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
