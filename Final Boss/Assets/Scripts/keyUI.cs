using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public static KeyUI instance;
    public Image keyIcon;

    void Awake()
    {
        instance = this;
        keyIcon.enabled = false;
    }

    public void ShowKeyIcon(bool show)
    {
        keyIcon.enabled = show;
    }
}
