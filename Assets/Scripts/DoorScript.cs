using UnityEngine;

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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();


        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        spriteRenderer.sprite = doorClosed; // start closed
        if (prompt != null) prompt.SetActive(false); // hide initially
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

            //Open Door
            OpenDoor();
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

        // close the door
        CloseDoor();
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
}