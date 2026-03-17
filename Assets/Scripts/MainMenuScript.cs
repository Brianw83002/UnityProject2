using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public GameObject PauseScreen;

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadSceneAsync("Level1");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Debug.Log("Go to Main Menu");
        SceneManager.LoadSceneAsync("MainMenu");
    }


    public void Continue()
    {
        PauseScreen.SetActive(false);
    }

    public void PlayClickSound()
    {
        if (audioSource == null)
        {
            Debug.Log("audioSource is null");
            return;
        }
        Debug.Log("audioSource Empty");
        
        audioSource.Play();
    }


}
