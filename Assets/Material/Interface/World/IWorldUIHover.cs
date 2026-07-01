using UnityEngine;

public interface IWorldUIHover
{
    /// <summary>
    /// rayがUIに当たったときの処理
    /// </summary>
    void OnHoverEnter();
    /// <summary>
    /// rayがUIから離れたときの処理
    /// </summary>
    void OnHoverExit();

    void OnClick();

}
