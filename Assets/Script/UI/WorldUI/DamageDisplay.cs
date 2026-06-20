using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DamageDisplay
{
    public GameObject panel;
    public Text text;

    //•Û‘¶‘ÎÛ‚©‚çŠO‚·
    [System.NonSerialized] public Coroutine hideCoroutine;
}
    