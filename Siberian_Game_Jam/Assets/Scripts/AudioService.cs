using UnityEngine;

public class AudioService : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioSource _musicSource;

    public static AudioService Instance;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if(clip)
            _audioSource.PlayOneShot(clip);
    }

}
