using UnityEngine;

public class RepeatWord : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip sound;

    public void PlaySound()
    {
        audioSource.Play();
    }
}
