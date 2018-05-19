using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The event manager
/// </summary>
public static class EventManager
{
    #region Fields

    // change speed event support
    static List<BoatMovement> changeSpeedInvokers = new List<BoatMovement>();
    static List<UnityAction<BoatSpeeds>> changeSpeedListeners =
        new List<UnityAction<BoatSpeeds>>();

    #endregion

    #region Methods

    /// <summary>
    /// Adds given script as a change speed invoker
    /// </summary>
    /// <param name="boat"></param>
    public static void AddChangeSpeedInvoker (BoatMovement invoker)
    {
        // add invoker to list and add all listeners to invoker
        changeSpeedInvokers.Add(invoker);
        foreach (UnityAction<BoatSpeeds> listener in changeSpeedListeners)
        {
            invoker.AddChangeSpeedListener(listener);
        }
    }

    /// <summary>
    /// Adds given method as a change speed listener
    /// </summary>
    /// <param name="listener">listening method</param>
    public static void AddChangeSpeedListener(UnityAction<BoatSpeeds> listener)
    {
        // add listener to list and to all invokers
        changeSpeedListeners.Add(listener);
        foreach (BoatMovement invoker in changeSpeedInvokers)
        {
            invoker.AddChangeSpeedListener(listener);
        }
    }

    #endregion
}
