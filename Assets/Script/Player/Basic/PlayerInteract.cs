using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.Player
{
    //[RequireComponent(typeof(Camera))]
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField] private float distance = 10f; // Raycastの距離
        [SerializeField] InteractionPromptUI interactionPromptUI;


                                                    
        private Camera mainCamera;
        float checkTimer = 0f;
        bool isInteracting = false;
        bool isWorldUIInteracting = false;
        IWorldUIDisplayable worldUIDisplayable;

        void Awake()
        {
            Debug.Assert(interactionPromptUI != null, "PlayerInteract: interactionPromptUIがアタッチされていません");
        }
        //private float checkTimer;
        void Start()
        {
            mainCamera = Camera.main;
        }
        void Update()
        {
            if (GameManager.Instance.IsPause())
                return;


            //if (Input.GetMouseButtonDown(0))
            //{
            //    Interact();
            //}


            checkTimer += Time.deltaTime;
            if (checkTimer >= 0.1f)
            {
                checkTimer = 0f;
                Interact();
            }
        }

        void Interact()
        {
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, distance))
            {
                //if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                //{
                //    return;
                //}

                //Debug.Log(hit.collider.name);
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                worldUIDisplayable = hit.collider.GetComponent<IWorldUIDisplayable>();

                //if (interactable != null&& !isInteracting)
                //{
                //    interactionPromptUI.SetInteractionText(interactable.GetInteractionText());
                //    isInteracting = true;
                    
                //}

                if(worldUIDisplayable != null&& !isWorldUIInteracting)
                {
                    interactionPromptUI.SetInteractionText(worldUIDisplayable.GetInteractionText());
                    worldUIDisplayable.ShowWorldUI();
                    isWorldUIInteracting = true;
                }

                //if (Input.GetMouseButtonDown(0))
                //{
                //    if (interactable != null)
                //    {
                //        //Debug.Log("Interact Success");
                //        interactable.Interact();
                //    }
                //}
                
            }
            else
            {
                //if (isInteracting)
                //{
                //    interactionPromptUI.SetInteractionText(string.Empty);
                //    isInteracting = false;
                //}

                if (worldUIDisplayable != null && isWorldUIInteracting)
                {
                    interactionPromptUI.SetInteractionText(string.Empty);
                    worldUIDisplayable.HideWorldUI();
                    isWorldUIInteracting = false;
                }
            }
        }
    }
}

