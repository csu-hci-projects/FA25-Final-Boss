using UnityEngine;
using TMPro;
using System.Collections;

public class VoiceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subtitleText;
    public static VoiceUI instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetSubtitle(string subtitle, float duration)
    {
        if (subtitleText != null)
        {
            subtitleText.text = subtitle;
            StartCoroutine(ClearAfterSeconds(duration));
        }
    }

    private IEnumerator ClearAfterSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);
        subtitleText.text = "";
    }
}
