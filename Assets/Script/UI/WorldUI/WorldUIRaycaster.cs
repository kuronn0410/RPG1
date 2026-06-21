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
    [SerializeField]private int raycastIntervalFrames = 10;
    private int frameCount;
    private IWorldUIHover currentHover;
    private Camera eventCamera;

    PointerEventData pointerData;
    private readonly List<RaycastResult> results = new List<RaycastResult>();

    void Awake()
    {
        Debug.Assert(graphicRaycaster != null, "WorldUIRaycaster: GraphicRaycasterがアタッチされていません");
        Debug.Assert(eventSystem != null, "WorldUIRaycaster: EventSystemがアタッチされていません");
    }
    void Start()
    {
        eventCamera = Camera.main;
        pointerData = new PointerEventData(eventSystem);
    }

    void Update()
    {
        if (GameManager.Instance.IsPause())
            return;
        frameCount++;

        bool clicked = Input.GetMouseButtonDown(0);

        if (frameCount >= raycastIntervalFrames || clicked)
        {
            frameCount = 0;
            Interact();
        }

        if (clicked)
        {
            currentHover?.OnClick();
        }
    }

    void Interact()
    {
       

        pointerData.position = Input.mousePosition;

        results.Clear();
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
    }
}
