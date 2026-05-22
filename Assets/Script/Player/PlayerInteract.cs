using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distance = 10f; // Raycastの距離

    // Update is called once per frame
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }   
    void Update()
    {
        if (GameManager.Instance.IsPause())
            return;


        if (Input.GetMouseButtonDown(0))
        {
           Interact();
        }
    }

    void Interact()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            Debug.Log(hit.collider.name);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            
            // 2. スクリプトが見つかった場合だけ実行する
            if (interactable != null)
            {
                Debug.Log("Interact Success");
                interactable.Interact();
            }
        }
    }
}
