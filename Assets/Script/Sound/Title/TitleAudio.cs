using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class TitleAudio : MonoBehaviour, IVolumeControllable
{
    [SerializeField] private AudioClip gameStartSE;
    [SerializeField] private AudioClip menuSelectSE;
    [SerializeField] private AudioClip exitSE;
    [SerializeField] private AudioClip defaultSE;
    

    private AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    public void PlayGameStartSE()
    {
        audioSource.PlayOneShot(gameStartSE);
    }

    public void PlayMenuSelectSE()
    {
        audioSource.PlayOneShot(menuSelectSE);
    }

    public void PlayExitSE()
    {
        audioSource.PlayOneShot(exitSE);
    }   

    public void PlayDefaultSE()
    {
        audioSource.PlayOneShot(defaultSE);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
