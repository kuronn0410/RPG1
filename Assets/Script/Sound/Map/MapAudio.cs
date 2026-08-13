using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MapAudio : MonoBehaviour, IVolumeControllable, IUISePlayer
{
    [SerializeField] private AudioClip sceneMove;
    [SerializeField] private AudioClip LevelUpSE;
    [SerializeField] private AudioClip exitSE;
    [SerializeField] private AudioClip defaultSE;


    private AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(UISeType type)
    {
        switch (type)
        {
            case UISeType.SceneMove:
                PlaySceneMoveSE();
                break;
            case UISeType.Exit:
                PlayExitSE();
                break;
            case UISeType.LevelUp:
                PlayLevelUpSE();
                break;
            case UISeType.Default:
                PlayDefaultSE();
                break;
        }
    }

    // Update is called once per frame
    public void PlaySceneMoveSE()
    {
        audioSource.PlayOneShot(sceneMove);
    }

    public void PlayLevelUpSE()
    {
        audioSource.PlayOneShot(LevelUpSE);
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
