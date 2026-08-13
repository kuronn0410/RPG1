using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TownAudio : MonoBehaviour, IVolumeControllable, IUISePlayer
{
    [SerializeField] private AudioClip sceneMove;
    [SerializeField] private AudioClip menuSelectSE;
    [SerializeField] private AudioClip purchaseSE;
    [SerializeField] private AudioClip cantPurchaseSE;
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
            case UISeType.MenuSelect:
                PlayMenuSelectSE();
                break;
            case UISeType.Purchase:
                PlayPurchaseSE();
                break;
            case UISeType.CantPurchase:
                PlayCantPurchaseSE();
                break;
            case UISeType.Exit:
                PlayExitSE();
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

    public void PlayMenuSelectSE()
    {
        audioSource.PlayOneShot(menuSelectSE);
    }

    public void PlayPurchaseSE()
    {
        audioSource.PlayOneShot(purchaseSE);
    }

    public void PlayCantPurchaseSE()
    {
        audioSource.PlayOneShot(cantPurchaseSE);
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
