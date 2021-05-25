using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audiosource;
    private int musicIndex = 0;
        
    // Start is called before the first frame update
    void Start()
    {
        audiosource.clip = playlist[musicIndex];
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audiosource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audiosource.clip = playlist[musicIndex];
        audiosource.Play();
    }
}
