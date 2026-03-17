using UnityEngine;
using UnityEngine.Audio;

public class KeyScript : MonoBehaviour
{   
    private AudioSource audioSource;
    public AudioClip keySound;    // sound for Key

    public DoorScript door;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (keySound != null)
        {
            audioSource.clip = keySound;
            audioSource.Play();
        }
        door.isDoorLocked = false;

        Destroy(gameObject);
    }


}
