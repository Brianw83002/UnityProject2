using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadSceneAsync("world");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }



    public void PlayClickSound()
    {
        if (audioSource != null)
        {
            Debug.Log("audioSource Empty");
        }
        audioSource.Play();
    }


}
