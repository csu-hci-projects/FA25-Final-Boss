using UnityEngine;

public class Voicelines : MonoBehaviour
{
    private AudioSource source;
    public static Voicelines instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Say(VoicelineClip vClip)
    {
        if (vClip == null || vClip.clip == null) return;

        if (source.isPlaying)
            source.Stop();

        source.PlayOneShot(vClip.clip);

        if (VoiceUI.instance != null)
            VoiceUI.instance.SetSubtitle(vClip.subtitle, vClip.clip.length);
    }
}
