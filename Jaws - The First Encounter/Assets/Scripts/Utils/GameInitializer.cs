using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes utility scripts (utils)
/// </summary>
public class GameInitializer : MonoBehaviour
{
    /// <summary>
    /// Called one frame before Start()
    /// </summary>
    private void Awake()
    {
        // initializes config utils scripts
        PlayerConfigUtils.Initialize();
    }
}
