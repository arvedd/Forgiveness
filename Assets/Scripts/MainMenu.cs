using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
