using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClickSound : MonoBehaviour
{
    public AudioClip clickSoundClip;

    private void Awake()
    {
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlayButtonClickSound(clickSoundClip));
        }
    }

    private void PlayButtonClickSound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
}
