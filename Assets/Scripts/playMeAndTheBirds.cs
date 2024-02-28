using UnityEngine;

public class playMeAndTheBirds: MonoBehaviour
{
    public AudioClip song; // Assign the song clip in the Unity Editor
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        // Ensure there's an AudioSource component attached to this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // Ensure the song loops continuously
    }

    void Update()
    {
        // Check if the song is assigned and the player is touching the collider
        if (song != null && isPlaying)
        {
            // Play the song if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.clip = song;
                audioSource.Play();
            }
        }
        else
        {
            // Stop the song if the player is not touching the collider
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlaying = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlaying = false;
        }
    }
}