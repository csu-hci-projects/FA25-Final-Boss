using UnityEngine;

public class CursorLock : MonoBehaviour
{
    void Start()
    {
        LockCursor();
    }

    void Update()
    {
        // Press Escape to toggle
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                UnlockCursor();
            }   
            else
            {
                LockCursor();
            }
                
        }
    }
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
