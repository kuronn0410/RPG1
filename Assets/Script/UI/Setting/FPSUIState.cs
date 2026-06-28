using UnityEngine;
using UnityEngine.UI;
public class FPSUIState : MonoBehaviour
{
    [SerializeField] private GameObject fpsButton30;
    private Image fpsButton30Image;
    [SerializeField] private GameObject fpsButton60;
    private Image fpsButton60Image;
    [SerializeField] private GameObject fpsButton120;
    private Image fpsButton120Image;

    void Awake()
    {
        fpsButton30Image = fpsButton30.GetComponent<Image>();
        fpsButton60Image = fpsButton60.GetComponent<Image>();
        fpsButton120Image = fpsButton120.GetComponent<Image>();
    }
    private void Start()
    {
      
    }

    public void UpdateFPSUIState(int fps)
    {
        if(fps == 30)
        {
            ResetFPSUIState();
            
            fpsButton30Image.color = Color.green;
        }
        

        if(fps == 60)
        {
            ResetFPSUIState();
            
            fpsButton60Image.color = Color.green;
        }
      

        if(fps == 120)
        {
            ResetFPSUIState();
           
            fpsButton120Image.color = Color.green;
        }
        
    }

    void ResetFPSUIState()
    {
        fpsButton30Image.color = Color.white;
        fpsButton60Image.color = Color.white;
        fpsButton120Image.color = Color.white;
       
    }
}
