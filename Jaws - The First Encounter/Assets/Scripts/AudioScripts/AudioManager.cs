using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages audio across entire game
/// </summary>
public static class AudioManager
{
    #region Fields
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();
    #endregion

    #region Properties
    /// <summary>
    /// Gets whether audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Initializes audio manager
    /// </summary>
    /// <param name="source"></param>
    public static void Initialize(AudioSource source)
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
    public static void Play(AudioClipName name)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(audioClips[name]);
        }
    }

    #endregion
}
