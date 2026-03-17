using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    public bool isDoorLocked = false;
    public Sprite doorClosed;
    public Sprite doorOpen;
    public GameObject prompt;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;
    public AudioClip openSound;    // sound when door opens
    public AudioClip closeSound;   // sound when door closes
    public AudioClip lockedSound;   // sound when door is locked

    private bool playerInRange = false; // track if player is overlapping
    private bool isDoorOpen;
    public string GoToLevelName;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        spriteRenderer.sprite = doorClosed; // start closed
        if (prompt != null) prompt.SetActive(false); // hide initially
        isDoorOpen = false;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E");
            
            if (isDoorLocked)
            {
                audioSource.clip = lockedSound;
                audioSource.Play();
            }

            //Open Door if closed and not locked
            if (!isDoorOpen && !isDoorLocked)
            {
                StartCoroutine(OpenDoorAndLoad());
            }
        }
    }


    //If player is in range of door
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (prompt != null) prompt.SetActive(true); // show E prompt
        }
    }

    //If player leaves range of door
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (prompt != null) prompt.SetActive(false); // hide E prompt
        }

        // close the door if open
        if (isDoorOpen)
        {
            CloseDoor();
            isDoorOpen = false;
        }
    }




    //OPENING DOOR
    void OpenDoor()
    {
        if(isDoorLocked)
        {
            return;
        }

        spriteRenderer.sprite = doorOpen;
        if (openSound != null)
        {
            audioSource.clip = openSound;
            audioSource.Play();
        }
    }



    //CLOSING DOOR
    void CloseDoor()
    {
        if (isDoorLocked)
        {
            return;
        }

        spriteRenderer.sprite = doorClosed;
        if (closeSound != null)
        {
            audioSource.clip = closeSound;
            audioSource.Play();
        }
    }




    IEnumerator OpenDoorAndLoad()
    {
        OpenDoor();
        isDoorOpen = true;

        // wait until the door sound finishes
        yield return new WaitWhile(() => audioSource.isPlaying);

        SceneManager.LoadScene(GoToLevelName);
    }
}


