using UnityEngine;
using System;

[Serializable]
public class SoundEffect
{
    public string name;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Settings")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private SoundEffect[] sounds;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string soundName)
    {
        SoundEffect s = Array.Find(sounds, x => x.name == soundName);

        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }


}
