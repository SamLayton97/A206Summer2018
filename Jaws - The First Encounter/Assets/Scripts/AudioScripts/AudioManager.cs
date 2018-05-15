using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages audio across entire game
/// </summary>
public class AudioManager : MonoBehaviour
{
    #region Singleton

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region Fields
    bool initialized = false;
    AudioSource audioSource;
    Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();
    #endregion

    #region Properties
    /// <summary>
    /// Gets whether audio manager has been initialized
    /// </summary>
    public  bool Initialized
    {
        get { return initialized; }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Initializes audio manager
    /// </summary>
    /// <param name="source"></param>
    public void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;

        // loads in all sounds from Resources
        //  audioClips.Add(AudioClipName.Devour, Resources.Load<AudioClip>("______"));
    }

    /// <summary>
    /// Plays audio clip with given name
    /// </summary>
    /// <param name="name">name of sound to play</param>
    public void Play(AudioClipName name)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioClips[name]);
        }
    }

    #endregion
}
