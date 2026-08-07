using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

/// <summary>
/// たぶんこれotherにあるのenumのScenesでいいと思う
/// </summary

/// <summary>
/// AudioSourceのループ再生を使って、BGMを再生するためのクラス
/// </summary>
public class BgmManager : MonoBehaviour
{
    [SerializeField] AudioClip title;
    [SerializeField] AudioClip town;
    [SerializeField] AudioClip battle;
   
    AudioSource audioSource;

    //デバックのためにSerializeFeildにしてる
    [SerializeField] bool isTitlePlaying = false;
    [SerializeField] bool isTownPlaying = false;
    [SerializeField] bool isBattlePlaying = false;

    private BGMType? currentBGM;

    public static BgmManager instance;
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
        Debug.Assert(title != null, "titleがアタッチされていません。");
        Debug.Assert(town != null, "townがアタッチされていません。");
        Debug.Assert(battle != null, "battleがアタッチされていません。");
    }

    void Start()
    {
        audioSource.clip = title;
        BGMStopandPlay(BGMType.title);
    }

    /// <summary>
    /// デバック用
    /// </summary>
#if UNITY_EDITOR
    void Update()
    {
        if (Keyboard.current == null)
            return;
        
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            BGMStopandPlay(BGMType.title);
        }
        else if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            BGMStopandPlay(BGMType.town);
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            BGMStopandPlay(BGMType.battle);
        }
    }
#endif

    /// <summary>
    /// BGMを止めてから再生する同じものが再生中だったらそのままにする
    /// </summary>
    /// <param name="bgm"></param>
    public void BGMStopandPlay(BGMType bgm)
    {
        // 同じBGMが再生中なら何もしない
        if (currentBGM == bgm && audioSource.isPlaying)
            return;
        //StopAllBGM();
        AudioClip clip = bgm switch
        {
            BGMType.title => title,
            BGMType.town => town,
            BGMType.battle => battle,
            //BGMType.result => result,
            _ => null
        };
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();

        currentBGM = bgm;
    }

    /// <summary>
    /// 音を止める用
    /// </summary>
    public void StopAllBGM()
    {
        isBattlePlaying = false;
        isTownPlaying = false;
        isTitlePlaying = false;

        audioSource.Stop();
    }


    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume);
    }
}
