using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public AudioClip clickSoundClip;
    public float delay = 0.1f; // Delay in seconds before destroying the old scene
    private static AudioSource audioSource;

    private void Awake()
    {
        if (audioSource == null)
        {
            // Create an AudioSource component if it doesn't exist
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the click sound clip to the static AudioSource
        audioSource.clip = clickSoundClip;

        // Get all the buttons in the scene
        Button[] buttons = FindObjectsOfType<Button>();

        // Subscribe to the click event of each button
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(PlayButtonClickSound);
        }
    }

    private void PlayButtonClickSound()
    {
        // Play the click sound using the static AudioSource
        if (audioSource != null && clickSoundClip != null)
        {
            audioSource.PlayOneShot(clickSoundClip);
        }

        // Delay the destruction of the old scene by the specified duration
        Invoke("DestroyOldScene", delay);
    }

    private void DestroyOldScene()
    {
        // Destroy the game object that holds the old scene
        Destroy(gameObject);
    }
}
