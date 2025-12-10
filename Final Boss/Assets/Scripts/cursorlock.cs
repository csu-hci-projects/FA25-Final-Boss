using UnityEngine;
using UnityEngine.SceneManagement;

public class Cursorlock : MonoBehaviour
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
            SceneManager.LoadScene(0);

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
