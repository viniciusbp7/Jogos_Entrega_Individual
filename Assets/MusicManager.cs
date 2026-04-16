using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void PararMusica()
    {
        if (audioSource != null)
            audioSource.Stop();
    }

    public void TocarMusica()
    {
        if (audioSource != null && !audioSource.isPlaying)
            audioSource.Play();
    }
}