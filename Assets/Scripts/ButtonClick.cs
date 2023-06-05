using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public AudioClip clickSoundClip;
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
    }
}
