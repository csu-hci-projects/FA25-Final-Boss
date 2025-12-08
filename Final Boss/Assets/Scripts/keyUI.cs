using UnityEngine;
using UnityEngine.UI;

public class UIKeyDisplay : MonoBehaviour
{
    public static UIKeyDisplay instance;
    public Image keyIcon;

    void Awake()
    {
        instance = this;
    }

    public void ShowKeyIcon(bool show)
    {
        keyIcon.enabled = show;
    }
}
