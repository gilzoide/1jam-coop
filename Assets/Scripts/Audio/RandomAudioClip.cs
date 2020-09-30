using UnityEngine;

public class RandomAudioClip : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public bool playOnStart = true;

    void Awake()
    {
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Start()
    {
        if (playOnStart)
        {
            PlayRandomClip();
        }
    }

    public void PlayRandomClip()
    {
        PlayRandomClip(audioSource, audioClips);
    }

    public static void PlayRandomClip(AudioSource audioSource, AudioClip[] clips)
    {
        int index = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[index]);
    }
}
