using UnityEngine;

public class SetCursorManager 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static void SetCursorState(bool isCursor)
    {
       if(isCursor)
       {
           Cursor.visible = true;
           Cursor.lockState = CursorLockMode.None;
       }
       else
       {
           Cursor.visible = false;
           Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
