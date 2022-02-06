using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        // générer un game object 
        GameObject tempGO = new GameObject("TempAudio");
        // changer sa position
        tempGO.transform.position = pos;
        // ajouter une audio source sur l'objet et on stocke le component à ajouter
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        // charger le clip
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        // jouer le son
        audioSource.Play();
        // supprimer l'objet
        Destroy(tempGO, clip.length);
        return audioSource;
    }
}
