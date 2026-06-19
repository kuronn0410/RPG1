using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// ワールドUIのRaycastを処理するクラス
/// </summary>
public class WorldUIRaycaster : MonoBehaviour
{
    [SerializeField] private float distance = 10f; // Raycastの距離
    [SerializeField] private GraphicRaycaster graphicRaycaster;
    [SerializeField] private EventSystem eventSystem;
     private IWorldUIHover currentHover;
    private Camera eventCamera;

    void Awake()
    {
        Debug.Assert(graphicRaycaster != null, "WorldUIRaycaster: GraphicRaycasterがアタッチされていません");
        Debug.Assert(eventSystem != null, "WorldUIRaycaster: EventSystemがアタッチされていません");
    }
    void Start()
    {
        eventCamera = Camera.main;
    }

    void Update()
    {
         if (GameManager.Instance.IsPause())
            return;

        PointerEventData pointerData = new PointerEventData(eventSystem);
        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerData, results);

        IWorldUIHover hitHover = null;

        foreach (RaycastResult result in results)
        {
            hitHover = result.gameObject.GetComponent<IWorldUIHover>();

            if (hitHover != null)
            {
                break;
            }
        }

        if (currentHover != hitHover)
        {
            currentHover?.OnHoverExit();
            hitHover?.OnHoverEnter();

            currentHover = hitHover;
        }

        if (Input.GetMouseButtonDown(0))
        {
            currentHover?.OnClick();
        }
    }
}
