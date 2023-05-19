using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{

    public string levelToLoad;


    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    // Update is called once per frame
 

    public void QuitGame()
    {
        Application.Quit();
    }
}
