using UnityEngine;

// applies a low pass filter to all audio sources in the scene (level 3) 
// which makes it sound underwater 

public class LowPassFilter : MonoBehaviour
{
    public float cutoffFrequency = 500.0f;
    public float lowpassResonanceQ = 1.0f;

    void Start()
    {
        ApplyLowPassFilterToAllAudioSources();
    }

    private void ApplyLowPassFilterToAllAudioSources()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in audioSources)
        {
            ApplyLowPassFilter(audioSource);
        }
    }

    private void ApplyLowPassFilter(AudioSource audioSource)
    {
        AudioLowPassFilter lowPassFilter = audioSource.GetComponent<AudioLowPassFilter>();

        if (lowPassFilter == null)
        {
            lowPassFilter = audioSource.gameObject.AddComponent<AudioLowPassFilter>();
        }

        lowPassFilter.cutoffFrequency = cutoffFrequency;
        lowPassFilter.lowpassResonanceQ = lowpassResonanceQ;
    }
}
