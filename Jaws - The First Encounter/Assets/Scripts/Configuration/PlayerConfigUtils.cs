using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static wrapper providing access to player's configuration data
/// </summary>
public static class PlayerConfigUtils
{
    static PlayerConfigData playerConfigData;

    #region Properties

    /// <summary>
    /// Returns boat's forward force
    /// </summary>
    public static float ForwardForce
    {
        get { return playerConfigData.ForwardForce; }
    }

    /// <summary>
    /// Returns boat's max rotation rate
    /// </summary>
    public static float RotationRate
    {
        get { return playerConfigData.RotationRate; }
    }

    #endregion

    /// <summary>
    /// Initializes use of player config utils
    /// </summary>
    public static void Initialize()
    {
        playerConfigData = new PlayerConfigData();
    }
}
