using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
/// <summary>
/// たぶんこれenumのPieceAnimationTypeでいいと思う
/// </summary>
public enum SEType
{
    hit,
    dead,
    evolution,
    put
}

/// <summary>
/// AudioSourceのループ再生を使わずに、SEを再生するためのクラス
/// </summary>
public class SEManager : MonoBehaviour
{
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip dead;
    [SerializeField] AudioClip evolution;
    [SerializeField] AudioClip put;
    AudioSource audioSource;

    //デバックのためにSerializeFeildにしてる
    [SerializeField] bool isHitPlaying = false;
    [SerializeField] bool isDeadPlaying = false;
    [SerializeField] bool isEvolutionPlaying = false;
    [SerializeField] bool isPutPlaying = false;

    private SEType? currentSE;

    public static SEManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
        Debug.Assert(hit != null, "hitがアタッチされていません。");
        Debug.Assert(dead != null, "deadがアタッチされていません。");
        Debug.Assert(evolution != null, "evolutionがアタッチされていません。");
        Debug.Assert(put != null, "putがアタッチされていません。");
    }

    /// <summary>
    /// デバック用
    /// </summary>
#if UNITY_EDITOR
    void Update()
    {
        if (Keyboard.current == null)
            return;
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SEStopandPlay(SEType.hit);
        }
        else if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            SEStopandPlay(SEType.dead);
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SEStopandPlay(SEType.evolution);
        }
        else if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SEStopandPlay(SEType.put);
        }
    }
#endif

    /// <summary>
    /// 
    /// </summary>
    /// <param name="se"></param>
    public void SEStopandPlay(SEType se)
    {
        if (currentSE == se && audioSource.isPlaying)
            return;
        //StopAllSE();
        AudioClip clip = se switch
        {
            SEType.hit => hit,
            SEType.dead => dead,
            SEType.evolution => evolution,
            SEType.put => put,
            _ => null
        };

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();

        currentSE = se;
    }

    /// <summary>
    /// 音を止める用
    /// </summary>
    public void StopAllSE()
    {
        isHitPlaying = false;
        isDeadPlaying = false;
        isEvolutionPlaying = false;
        isPutPlaying = false;
        audioSource.Stop();
    }
}
