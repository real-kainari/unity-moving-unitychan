using UnityEngine;

public class UnitychanAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip jumpVoice;



    private void PlayVoice(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void PlayJumpVoice()
    {
        PlayVoice(jumpVoice);
    }
}