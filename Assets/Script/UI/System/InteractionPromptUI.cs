using UnityEngine;
using UnityEngine.UI;

public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private GameObject interactionPromptPanel;
    [SerializeField] private Text interactionText;

    void Awake()
    {
        Debug.Assert(interactionPromptPanel != null, "Interaction Prompt Panel is not assigned in the inspector.");
        Debug.Assert(interactionText != null, "Interaction Text is not assigned in the inspector.");
    }

    void Start()
    {
        interactionPromptPanel.SetActive(false);
    }

    public void SetInteractionText(string text)
    {
        TogglePrompt();
        interactionText.text = text;
    }


    private void TogglePrompt()
    {
        if(interactionPromptPanel.activeSelf)
        {
            interactionPromptPanel.SetActive(false);

        }
        else
        {
            interactionPromptPanel.SetActive(true);
        }
    }
}
