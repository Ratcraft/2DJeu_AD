using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string leveltoStart;

    public GameObject settingwindows;
    public void StartGame()
    {
        SceneManager.LoadScene(leveltoStart);
    }

    public void Settings()
    {
        settingwindows.SetActive(true);
    }

    public void CloseSettings()
    {
        settingwindows.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
