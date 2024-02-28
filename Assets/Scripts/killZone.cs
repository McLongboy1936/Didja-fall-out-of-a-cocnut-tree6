using UnityEngine;
using UnityEngine.SceneManagement;

public class killZone : MonoBehaviour
{
    void start()
    {
        Scene scene = SceneManager.GetActiveScene();

    }
    // Called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            // Kill the player
            Destroy(other.gameObject);

            // Restart the level after 3 seconds
            Invoke("RestartLevel", 3f);
        }
    }

    // Function to restart the level
    private void RestartLevel()
    {
        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the current scene by its index
        SceneManager.LoadScene(currentSceneIndex);
    }
}