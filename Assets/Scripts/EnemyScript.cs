using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    private AudioSource audioSource;
    public AudioClip scareAudio;

    public bool renderSpriteOnScare;
    private int scareCount;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        hideSprite(sprite);

        scareCount = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (scareCount > 0)
        {
            scareCount--;
            if (renderSpriteOnScare) showSprite(sprite); //If set true then it shows the sprite
            playSound();
            StartCoroutine(WaitTillSoundEnd()); //wait till sound finish
        }
        
    }

    private void playSound()
    {
        if (scareAudio != null)
        {
            audioSource.clip = scareAudio;
            audioSource.Play();
        }
    }

    private void showSprite(SpriteRenderer sprite)
    {
        sprite.enabled = true;
    }

    private void hideSprite(SpriteRenderer sprite)
    {
        sprite.enabled = false;
    }

    IEnumerator WaitTillSoundEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        Destroy(gameObject);
    } 
       

}
