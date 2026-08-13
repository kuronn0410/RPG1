using RPG.Enemy;
using RPG.Player;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour,IVolumeControllable
{
    [SerializeField] private AudioClip AttackSwingSE;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip deathSound;

    private AudioSource audioSource;
    private PlayerStatus playerStatus;

    void Awake()
    {
        Debug.Assert(AttackSwingSE != null, "EnemyAudio: AttackSwingSEがアタッチされていません");
        Debug.Assert(damageSound != null, "EnemyAudio: damageSoundがアタッチされていません");
        Debug.Assert(deathSound != null, "EnemyAudio: deathSoundがアタッチされていません");
        audioSource = GetComponent<AudioSource>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    void OnEnable()
    {
        SEManager.Instance.Register(this);
        playerStatus.OnDamageTaken += PlayDamageSound; // プレイヤーがダメージを受けたときに呼ばれるイベントに登録する
    }

    private void OnDisable()
    {
        playerStatus.OnDamageTaken -= PlayDamageSound; // イベント登録を解除する
    }



    public void PlayDamageSound(int damage)
    {
        audioSource.PlayOneShot(damageSound);
    }
    public void PlayAttackSwingSE()
    {
        audioSource.PlayOneShot(AttackSwingSE);
    }


    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
