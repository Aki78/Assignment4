using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        print("start volume");
        audioSource = GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>("background");
        audioSource.clip = clip;
        audioSource.loop = true;

        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        print("setting volume");
        audioSource.volume = volume;
    }

}