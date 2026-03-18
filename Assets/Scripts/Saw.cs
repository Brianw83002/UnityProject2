using UnityEngine;
using System.Collections;
using UnityEngine.U2D;

public class Saw : MonoBehaviour
{
    public GameObject ScaryImage;
    public AudioClip scareAudio;
    private AudioSource audioSource;
    private int scareCount;

    private void Start()
    {
        ScaryImage.SetActive(false);
        scareCount = 1;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scareCount > 0)
        {
            scareCount--;
            showSprite(ScaryImage); //If set true then it shows the sprite
            playSound();
            StartCoroutine(WaitTillSoundEnd()); //wait till sound finish
        }

    }

    IEnumerator WaitTillSoundEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        Destroy(gameObject);
    }

    IEnumerator StopAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        audioSource.Stop();
    }

    private void showSprite(GameObject image)
    {
        image.SetActive(true);
    }

    private void playSound()
    {
        if (scareAudio != null)
        {
            audioSource.clip = scareAudio;
            audioSource.Play();
            StartCoroutine(StopAfterTime(1f)); // play only 1 second
        }
    }

}
