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

    /// <summary>
    /// Returns boat's full ahead force factor
    /// </summary>
    public static float FullAhead
    {
        get { return playerConfigData.FullAhead; }
    }

    /// <summary>
    /// Returns boat's slow ahead force factor
    /// </summary>
    public static float SlowAhead
    {
        get { return playerConfigData.SlowAhead; }
    }

    /// <summary>
    /// Returns boat's stop force factor
    /// </summary>
    public static float Stop
    {
        get { return playerConfigData.Stop; }
    }

    /// <summary>
    /// Returns boat's slow astern force factor
    /// </summary>
    public static float SlowAstern
    {
        get { return playerConfigData.SlowAstern; }
    }

    /// <summary>
    /// Returns boat's full astern force factor
    /// </summary>
    public static float FullAstern
    {
        get { return playerConfigData.FullAstern; }
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
