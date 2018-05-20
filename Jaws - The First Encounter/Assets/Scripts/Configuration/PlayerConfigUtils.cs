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

    /// <summary>
    /// Returns boat's max hull integrity
    /// </summary>
    public static int HullIntegrity
    {
        get { return playerConfigData.HullIntegrity; }
    }

    /// <summary>
    /// Return max space boat's hull can store
    /// </summary>
    public static int HullCapacity
    {
        get { return playerConfigData.HullCapacity; }
    }

    /// <summary>
    /// Returns max amount of gas boat can store
    /// </summary>
    public static float GasTankSize
    {
        get { return playerConfigData.GasTankSize; }
    }

    /// <summary>
    /// Returns rate at which boat consumes gas
    /// </summary>
    public static float GasConsumptionRate
    {
        get { return playerConfigData.GasConsumptionRate; }
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
